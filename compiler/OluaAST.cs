using Indent;
using MsilVarResprenentation;
using OluaAST;

namespace MsilVarResprenentation
{
    public interface MsilVar
    {
        public TypeName Type { get; }

        // returns msil line that pops the top stack element and assigns to the variable
        string MsilToStore();

        // returns msil line that appends variable value to the top of the stack
        string MsilToGet();
    }

    public class LocalVar : MsilVar
    {
        public int Index { get; }
        public TypeName Type { get; }

        public LocalVar(TypeName type, int index)
        {
            Type = type;
            Index = index;
        }

        public string MsilToStore() => $"stloc.s {Index}";
        public string MsilToGet() => $"ldloc.s {Index}";
    }

    public class ArgVar : MsilVar
    {
        public TypeName Type { get; }
        public int Index { get; }

        public ArgVar(TypeName type, int index)
        {
            Type = type;
            Index = index;
        }

        public string MsilToStore() => $"starg.s {Index}";
        public string MsilToGet() => $"ldarg.s {Index}";
    }
}

namespace OluaAST
{
    public interface Node
    {
        public IStringOrList ToOlua();
    }

    public class TypeName : Node
    {
        public string Identifier { get; set; }
        public TypeName? GenericType { get; set; } // Nullable for non-generic types.

        public TypeName Unwrap()
        {
            return new TypeName
            {
                Identifier = Identifier,
                GenericType = GenericType,
            };
        }

        public override string ToString() => GenericType != null
                                         ? $"{Identifier}[{GenericType}]"
                                         : Identifier;
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public virtual string sMsil() => GenericType != null
                                    ? csMsil()
                                    : "c_" + Identifier;

        public virtual string csMsil() => "class " + (GenericType != null
                                    ? $"c_{Identifier}`1<{GenericType.csMsil()}>"
                                    : "c_" + Identifier);

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TypeName other = (TypeName)obj;
            return Identifier == other.Identifier &&
                EqualityComparer<TypeName>.Default.Equals(GenericType, other.GenericType);
        }

        public static bool operator ==(TypeName typeName1, TypeName typeName2)
        {
            if (ReferenceEquals(typeName1, typeName2))
            {
                return true;
            }

            if (ReferenceEquals(typeName1, null) || ReferenceEquals(typeName2, null))
            {
                return false;
            }

            return typeName1.Equals(typeName2);
        }

        public static bool operator !=(TypeName typeName1, TypeName typeName2)
        {
            return !(typeName1 == typeName2);
        }
    }

    public class OluaObjectList : Node
    {
        public List<OluaObject> List { get; set; }

        public override string ToString() => string.Join(", ", List.Select(e => e.ToString()));
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public ListWrapper MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            for (int i = 0; i < List.Count; i++)
            {
                res.AddExpanding(List[i].MsilToGet(locals));
            }
            return res;
        }
    }

    public class ConstructorInvocation : OluaObject
    {
        public List<TypeName> ConsumingTypes { get; set; } // augmented by analyzer
        public OluaObjectList Arguments { get; set; }
        public TypeName Type { get; set; }

        public override string ToString() => $"{Type}({Arguments})";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(Arguments.MsilToGet(locals));
            res.AddExpanding(new StringWrapper($"newobj instance void {Type.sMsil()}::.ctor({string.Join(", ", ConsumingTypes.Select(e => e.csMsil()))})"));
            return res;
        }

        public TypeName ResultingType(Dictionary<string, MsilVar> locals) => Type;
    }

    public class MethodInvocation : OluaObject, Statement
    {
        public TypeName? ReturnType { get; set; } // null if void result  // augmented by analyzer
        public List<TypeName> ConsumingTypes { get; set; } // augmented by analyzer

        public AttributeObject Method { get; set; }
        public OluaObjectList Arguments { get; set; }

        public override string ToString() => $"{Method}({Arguments})";

        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            ListWrapper res = new();
            res.AddExpanding(MsilToGet(locals));
            if (ReturnType != null)
            {
                res.AddExpanding(new StringWrapper("pop"));
            }
            return res;
        }

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(Method.Parent.MsilToGet(locals));
            res.AddExpanding(Arguments.MsilToGet(locals));
            res.AddExpanding(new StringWrapper($"callvirt instance {(ReturnType == null ? "void" : ReturnType.csMsil())} {Method.Parent.ResultingType(locals).sMsil()}::m_{Method.Identifier}({string.Join(", ", ConsumingTypes.Select(e => e.csMsil()))})"));
            return res;
        }

        public TypeName ResultingType(Dictionary<string, MsilVar> locals) => ReturnType.Unwrap();
    }

    public class AttributeObject : OluaAssignableObject
    {
        public TypeName? AttributeType { get; set; } // augmented by analyzer
        public OluaObject Parent { get; set; } // The object on which the attribute is accessed.
        public string Identifier { get; set; }

        public override string ToString() => $"{Parent}.{Identifier}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToAssign(OluaObject value, Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(Parent.MsilToGet(locals));
            res.AddExpanding(value.MsilToGet(locals));
            res.AddExpanding(new StringWrapper($"stfld {AttributeType.Unwrap().csMsil()} {Parent.ResultingType(locals).sMsil()}::f_{Identifier}"));
            return res;
        }

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(Parent.MsilToGet(locals));
            res.AddExpanding(new StringWrapper($"ldfld {AttributeType.Unwrap().csMsil()} {Parent.ResultingType(locals).sMsil()}::f_{Identifier}"));
            return res;
        }

        public TypeName ResultingType(Dictionary<string, MsilVar> locals) => AttributeType.Unwrap();
    }

    public interface OluaObject : Node
    {
        public TypeName ResultingType(Dictionary<string, MsilVar> locals);

        // returns msil lines that pushes the value on top of the stack
        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals);
    }

    public interface OluaAssignableObject : OluaObject
    {
        // returns msil lines that pulls value from the stack
        public IStringOrList MsilToAssign(OluaObject value, Dictionary<string, MsilVar> locals);
    }

    public class ThisIdentifier : OluaObject
    {
        public TypeName? Type { get; set; } //  augemented in analyzer
        public override string ToString() => $"this";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals) => new StringWrapper("ldarg.0");

        public TypeName ResultingType(Dictionary<string, MsilVar> locals) => Type;
    }

    public class ObjectIdentifier : OluaAssignableObject
    {
        public string Identifier { get; set; }

        public override string ToString() => $"{Identifier}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToAssign(OluaObject value, Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(value.MsilToGet(locals));
            res.AddExpanding(new StringWrapper(locals[Identifier].MsilToStore()));
            return res;
        }

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            res.AddExpanding(new StringWrapper(locals[Identifier].MsilToGet()));
            return res;
        }

        public TypeName ResultingType(Dictionary<string, MsilVar> locals) => locals[Identifier].Type;
    }

    public class Literal<T> : OluaObject
    {
        public T Value { get; set; }

        public override string ToString() => $"{Value}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public TypeName ResultingType(Dictionary<string, MsilVar> locals)
        {
            if (Value is float)
            {
                return new TypeName { Identifier = "Real", GenericType = null };
            }
            else if (Value is int)
            {
                return new TypeName { Identifier = "Integer", GenericType = null };
            }
            else if (Value is bool)
            {
                return new TypeName { Identifier = "Boolean", GenericType = null };
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IStringOrList MsilToGet(Dictionary<string, MsilVar> locals)
        {
            ListWrapper res = new();
            if (Value is float)
            {
                res.AddExpanding(new StringWrapper($"ldc.r4 {Value}"));
                res.AddExpanding(new StringWrapper($"newobj instance void {ResultingType(locals).sMsil()}::.ctor(float32)"));
            }
            else if (Value is int)
            {
                res.AddExpanding(new StringWrapper($"ldc.i4 {Value}"));
                res.AddExpanding(new StringWrapper($"newobj instance void {ResultingType(locals).sMsil()}::.ctor(int32)"));
            }
            else if (Value is bool)
            {
                res.AddExpanding(new StringWrapper((Value.ToString() == "True") ? "ldc.i4.1" : $"ldc.i4.0"));
                res.AddExpanding(new StringWrapper($"newobj instance void {ResultingType(locals).sMsil()}::.ctor(bool)"));
            }
            else
            {
                throw new ArgumentException();
            }
            return res;
        }
    }


    public class ClassDeclaration : Node
    {
        public string Name { get; set; }
        public TypeName? BaseClass { get; set; } // Nullable if the class doesn't extend another.
        public List<ClassMember> Members { get; set; }

        public IStringOrList ToMsil()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($".class public auto ansi beforefieldinit c_{Name} extends " + (BaseClass == null ? "c_Class" : BaseClass.sMsil()) + " {"));
            ListWrapper scope = new();

            // constructor
            {
                scope.Values.Add(new StringWrapper(".method public hidebysig specialname rtspecialname instance void .ctor() cil managed {"));

                ListWrapper body = new();
                {
                    body.AddExpanding(new StringWrapper(".maxstack 30")); // TODO: dynamically decide

                    body.Values.Add(new StringWrapper("ldarg.0"));
                    body.Values.Add(new StringWrapper($"call instance void {(BaseClass == null ? "c_Class" : BaseClass.sMsil())}::.ctor()"));

                    foreach (ClassMember e in Members)
                    {
                        IStringOrList? initializer = e.MsilInitialize(Name);
                        if (initializer != null)
                        {
                            body.AddExpanding(initializer);
                        }
                    }
                    body.AddExpanding(new StringWrapper("ret"));
                }
                scope.Values.Add(body);

                scope.Values.Add(new StringWrapper("}"));
            }

            scope.Values.Add(new StringWrapper(""));

            for (int i = 0; i < Members.Count; i++)
            {
                scope.AddExpanding(Members[i].DeclareClassMemberMsil());
                if (i < Members.Count - 1)
                {
                    scope.Values.Add(new StringWrapper(""));
                }
            }
            res.Values.Add(scope);
            res.Values.Add(new StringWrapper("}"));
            return res;
        }

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"class {Name} {(BaseClass == null ? "" : $"extends {BaseClass} ")}is"));
            ListWrapper scope = new();
            for (int i = 0; i < Members.Count; i++)
            {
                scope.AddExpanding(Members[i].ToOlua());
                if (i < Members.Count - 1)
                {
                    scope.Values.Add(new StringWrapper(""));
                }
            }
            res.Values.Add(scope);
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public interface ClassMember : Node
    {
        public IStringOrList DeclareClassMemberMsil();
        public IStringOrList? MsilInitialize(string belongingClass);
    }

    public class VariableDeclaration : ClassMember, Statement
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }
        public OluaObject InitialValue { get; set; }

        public override string ToString() => $"var {Name} : {Type} := {InitialValue}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList DeclareClassMemberMsil() => new StringWrapper($".field private {Type.csMsil()} f_{Name}");

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            LocalVar new_var = new(Type, accum.Count);

            // assign initial value
            ListWrapper res = new();
            res.AddExpanding(InitialValue.MsilToGet(locals));
            res.AddExpanding(new StringWrapper(new_var.MsilToStore()));

            // remember
            locals[Name] = new_var;
            accum.Add(Type);

            return res;
        }

        public IStringOrList MsilInitialize(string belongingClass)
        {
            ListWrapper res = new();
            res.AddExpanding(new StringWrapper("ldarg.0"));
            res.AddExpanding(InitialValue.MsilToGet(new Dictionary<string, MsilVar>()));
            res.AddExpanding(new StringWrapper($"stfld {Type.csMsil()} c_{belongingClass}::f_{Name}"));
            return res;
        }
    }

    public class ParameterList : Node
    {
        public List<Parameter> List { get; set; }

        public override string ToString() => string.Join(", ", List.Select(e => e.ToString()));
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public string TypesMsil() => string.Join(", ", List.Select(e => e.Type.csMsil()));
    }

    public class MethodDeclaration : ClassMember
    {
        public string Name { get; set; }
        public ParameterList Parameters { get; set; }
        public TypeName? ReturnType { get; set; } // null if void return type
        public StatementList Statements { get; set; }

        public IStringOrList DeclareClassMemberMsil()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper(".method public virtual instance " + (ReturnType == null ? "void" : ReturnType.csMsil()) + $" m_{Name}({Parameters.TypesMsil()}) cil managed {{"));

            List<TypeName> accum = new();
            Dictionary<string, MsilVar> locals = new();
            for (int i = 0; i < Parameters.List.Count; i++)
            {
                Parameter p = Parameters.List[i];
                locals[p.Name] = new ArgVar(p.Type, i + 1); // i+1 since 0 is for this
            }

            IStringOrList stmts_msil = Statements.MsilToExecute(locals, accum);

            ListWrapper scope = new();
            {
                scope.AddExpanding(new StringWrapper(".maxstack 30")); // TODO: dynamically decide
                if (accum.Count > 0)
                {
                    scope.AddExpanding(new StringWrapper(".locals (" + string.Join(", ", accum.Select(e => e.csMsil())) + ")"));
                }
                scope.AddExpanding(stmts_msil);
                // return default value for sure
                // NOTE: for array it's empty array (even thou it's empty constructor is not acessable via olua)
                if (ReturnType != null)
                {
                    scope.AddExpanding(new StringWrapper($"newobj instance void {ReturnType.sMsil()}::.ctor()"));
                }
                scope.AddExpanding(new StringWrapper("ret"));
            }
            res.Values.Add(scope);

            res.Values.Add(new StringWrapper("}"));
            return res;
        }

        public IStringOrList? MsilInitialize(string belongingClass)
        {
            return null;
        }

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"method {Name}({Parameters}) : {ReturnType} is"));
            res.Values.Add(Statements.ToOlua());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class Scope : Statement
    {
        public StatementList Statements { get; set; }

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        => Statements.MsilToExecute(locals, accum);

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"is"));
            res.Values.Add(Statements.ToOlua());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public interface Statement : Node
    {
        // msil lines that execute the statement
        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum);
    }

    public class Assignment : Statement
    {
        public OluaAssignableObject Variable { get; set; }
        public OluaObject Value { get; set; }

        public override string ToString() => $"{Variable} := {Value}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        // returns msil lines that reads the value from the top of the stack
        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum) => Variable.MsilToAssign(Value, locals);
    }

    public class StatementList : Node
    {
        public List<Statement> List { get; set; }

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            foreach (Statement e in List)
            {
                res.AddExpanding(e.ToOlua());
            }
            return res;
        }

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            locals = new Dictionary<string, MsilVar>(locals); // shallow copy
            ListWrapper res = new();
            foreach (Statement e in List)
            {
                res.AddExpanding(e.MsilToExecute(locals, accum));
            }
            return res;
        }
    }

    public class If : Statement
    {
        public OluaObject Cond { get; set; }
        public StatementList Then { get; set; }
        public StatementList? Else { get; set; }

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            string id = RandomStringGenerator.GenerateRandomString(32);
            string else_label = "ELSE_" + id;
            string endif_label = "END_IF_" + id;

            ListWrapper res = new();
            res.AddExpanding(Cond.MsilToGet(locals)); // Boolean on the stack top as the result
            res.AddExpanding(new StringWrapper("callvirt instance bool c_Boolean::p_m_data()")); // Unwrap bool
            res.AddExpanding(new StringWrapper("brfalse.s " + (Else == null ? endif_label : else_label)));
            res.AddExpanding(Then.MsilToExecute(locals, accum));
            if (Else != null)
            {
                res.AddExpanding(new StringWrapper("br.s " + endif_label));
                res.AddExpanding(new StringWrapper(else_label + ":"));
                res.AddExpanding(Else.MsilToExecute(locals, accum));
            }
            res.AddExpanding(new StringWrapper(endif_label + ":"));
            return res;
        }

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"if {Cond} then"));
            res.Values.Add(Then.ToOlua());
            if (Else != null)
            {
                res.Values.Add(new StringWrapper($"else"));
                res.Values.Add(Else.ToOlua());
            }
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class While : Statement
    {
        public OluaObject Cond { get; set; }
        public StatementList Body { get; set; }

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            string id = RandomStringGenerator.GenerateRandomString(32);
            string start_label = "WHILE_" + id;
            string end_label = "END_WHILE_" + id;

            ListWrapper res = new();
            res.AddExpanding(new StringWrapper(start_label + ":"));
            res.AddExpanding(Cond.MsilToGet(locals));
            res.AddExpanding(new StringWrapper("callvirt instance bool c_Boolean::p_m_data()"));
            res.AddExpanding(new StringWrapper("brfalse.s " + end_label));
            res.AddExpanding(Body.MsilToExecute(locals, accum));
            res.AddExpanding(new StringWrapper(end_label + ":"));
            return res;
        }

        public IStringOrList ToOlua()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"while {Cond} loop"));
            res.Values.Add(Body.ToOlua());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class Return : Statement
    {
        public OluaObject? Object { get; set; }

        public override string ToString() => $"return {Object}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());

        public IStringOrList MsilToExecute(Dictionary<string, MsilVar> locals, List<TypeName> accum)
        {
            ListWrapper res = new();
            if (Object != null)
            {
                res.AddExpanding(Object.MsilToGet(locals));
            }
            res.AddExpanding(new StringWrapper("ret"));
            return res;
        }
    }

    public class Parameter : Node
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }

        public override string ToString() => $"{Name} : {Type}";
        public IStringOrList ToOlua() => new StringWrapper(ToString());
    }
}