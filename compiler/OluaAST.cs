using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using Codegen;
using Indent;

namespace OluaAST
{
    public interface Node
    {
        public IStringOrList ToStrings();
    }

    public class TypeName : Node
    {
        public string Identifier { get; set; }
        public TypeName? GenericType { get; set; } // Nullable for non-generic types.

        public override string ToString() => GenericType != null
                                         ? $"{Identifier}[{GenericType}]"
                                         : Identifier;
        public IStringOrList ToStrings() => new StringWrapper(ToString());

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
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
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class ConstructorInvocation : OluaObject
    {
        public TypeName Type { get; set; }

        public override string ToString() => $"new {Type}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class MethodInvocation : OluaObject, Statement
    {
        public AttributeObject Method { get; set; }
        public OluaObjectList Arguments { get; set; }

        public override string ToString() => $"{Method}({Arguments})";
        public IStringOrList ToStrings() => new StringWrapper(ToString());

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class AttributeObject : OluaAssignableObject
    {
        public OluaObject Parent { get; set; } // The object on which the attribute is accessed.
        public string Identifier { get; set; }

        public override string ToString() => $"{Parent}.{Identifier}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public interface OluaObject : Node { }

    public interface OluaAssignableObject : OluaObject { }

    public class ThisIdentifier : OluaObject
    {
        public override string ToString() => $"this";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class ObjectIdentifier : OluaAssignableObject
    {
        public string Identifier { get; set; }

        public override string ToString() => $"{Identifier}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class Literal<T> : OluaObject
    {
        public T Value { get; set; }

        public override string ToString() => $"{Value}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }


    public class ClassDeclaration : Node
    {
        public string Name { get; set; }
        public TypeName? BaseClass { get; set; } // Nullable if the class doesn't extend another.
        public List<ClassMember> Members { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"class {Name} {(BaseClass == null ? "" : $"extends {BaseClass} ")}is"));
            ListWrapper scope = new();
            for (int i = 0; i < Members.Count; i++)
            {
                scope.AddExpanding(Members[i].ToStrings());
                if (i < Members.Count - 1)
                {
                    scope.Values.Add(new StringWrapper(""));
                }
            }
            res.Values.Add(scope);
            res.Values.Add(new StringWrapper("end"));
            return res;
        }

        // call it on all the classes before GenerateClass on any of them since type map must be populated fully before
        public void DefineType(ModuleBuilder mod, TypeTable types)
        {
            // Add static type (as it cannot be generic)
            // TODO: only the array type is built as generic
            TypeBuilder t = mod.DefineType(Name, TypeAttributes.Class);
            types.typeMap[Name] = t;
            // TODO: foratch class memebers and complete the class inteface
        }

        public void GenerateClass(TypeTable types)
        {
            TypeBuilder type = types.typeMap[Name];
            // TODO: default constructor that intializes fields? (if it is not implicitly gemnerated by the reflection.emit when defining fields)
            // TODO: inherit from the base class
            foreach (ClassMember cm in Members)
            {
                cm.GenerateClassMember(type, types);
            }
            type.CreateType(); // finalize il generation
        }
    }

    public interface ClassMember : Node
    {
        public void GenerateClassMember(TypeBuilder type, TypeTable types);
    }

    public class VariableDeclaration : ClassMember, Statement
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }
        public OluaObject InitialValue { get; set; }

        public void GenerateClassMember(TypeBuilder type, TypeTable types)
        {
            // TODO: build field for the variable declaration in class
        }

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO: build field for the variable declaration in body
        }

        public override string ToString() => $"var {Name} : {Type} := {InitialValue}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class ParameterList : Node
    {
        public List<Parameter> List { get; set; }

        public override string ToString() => string.Join(", ", List.Select(e => e.ToString()));
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class MethodDeclaration : ClassMember
    {
        public string Name { get; set; }
        public ParameterList Parameters { get; set; }
        public TypeName? ReturnType { get; set; } // null if void return type
        public StatementList Statements { get; set; }

        public void GenerateClassMember(TypeBuilder type, TypeTable types)
        {
            // Create an array to hold the parameter types.
            Type[] parameterTypes = new Type[Parameters.List.Count];
            for (int i = 0; i < Parameters.List.Count; i++)
            {
                parameterTypes[i] = types.ResolveType(Parameters.List[i].Type);
            }

            // Define the method with the specified name and public visibility.
            MethodBuilder method = type.DefineMethod(
                Name,
                MethodAttributes.Public,
                ReturnType != null ? types.ResolveType(ReturnType) : typeof(void),
                parameterTypes
            );

            // Generate the method body.
            ILGenerator il = method.GetILGenerator();
            foreach (Statement e in Statements.List)
            {
                e.GenerateStatement(il, types);
            }
        }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"method {Name}({Parameters}) : {ReturnType} is"));
            res.Values.Add(Statements.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class Scope : Statement
    {
        public StatementList Statements { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"is"));
            res.Values.Add(Statements.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public interface Statement : Node
    {
        public void GenerateStatement(ILGenerator il, TypeTable types);
    }

    public class Assignment : Statement
    {
        public OluaAssignableObject Variable { get; set; }
        public OluaObject Value { get; set; }

        public override string ToString() => $"{Variable} := {Value}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class StatementList : Node
    {
        public List<Statement> List { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            foreach (Statement e in List)
            {
                res.AddExpanding(e.ToStrings());
            }
            return res;
        }

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class If : Statement
    {
        public OluaObject Cond { get; set; }
        public StatementList Then { get; set; }
        public StatementList? Else { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"if {Cond} then"));
            res.Values.Add(Then.ToStrings());
            if (Else != null)
            {
                res.Values.Add(new StringWrapper($"else"));
                res.Values.Add(Else.ToStrings());
            }
            res.Values.Add(new StringWrapper("end"));
            return res;
        }

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class While : Statement
    {
        public OluaObject Cond { get; set; }
        public StatementList Body { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"while {Cond} loop"));
            res.Values.Add(Body.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class Return : Statement
    {
        public OluaObject? Object { get; set; }

        public override string ToString() => $"return {Object}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());

        public void GenerateStatement(ILGenerator il, TypeTable types)
        {
            // TODO
        }
    }

    public class Parameter : Node
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }

        public override string ToString() => $"{Name} : {Type}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }
}