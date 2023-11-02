using Indent;

namespace OluaAST
{
    public interface Node {
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
        public OluaObjectList Arguments { get; set; }

        public override string ToString() => $"{Type}({Arguments})";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class MethodInvocation : OluaObject, Statement
    {
        public AttributeObject Method { get; set; }
        public OluaObjectList Arguments { get; set; }

        public override string ToString() => $"{Method}({Arguments})";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class AttributeObject : OluaObject
    {
        public OluaObject Parent { get; set; } // The object on which the attribute is accessed.
        public string Identifier { get; set; }

        public override string ToString() => $"{Parent}.{Identifier}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public interface OluaObject : Node {}

    public class ThisItentifier : OluaObject
    {
        public override string ToString() => $"this";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class ObjectIndentifier : OluaObject
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

        public IStringOrList ToStrings() {
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
    }

    public interface ClassMember : Node {}

    public class VariableDeclaration : ClassMember, Statement
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }
        public OluaObject InitialValue { get; set; }

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

        public IStringOrList ToStrings() {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"{Name}({Parameters}) : {ReturnType} is"));
            res.Values.Add(Statements.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class ConstructorDeclaration : ClassMember
    {
        public ParameterList Parameters { get; set; }
        public StatementList Statements { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"this({Parameters}) is"));
            res.Values.Add(Statements.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public class Scope : Statement {
        public StatementList Statements { get; set; }

        public IStringOrList ToStrings()
        {
            ListWrapper res = new();
            res.Values.Add(new StringWrapper($"is"));
            res.Values.Add(Statements.ToStrings());
            res.Values.Add(new StringWrapper("end"));
            return res;
        }
    }

    public interface Statement : Node {}

    public class Assignment : Statement
    {
        public OluaObject Variable { get; set; }
        public OluaObject Value { get; set; }

        public override string ToString() => $"{Variable} := {Value}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class StatementList : Node
    {
        public List<Statement> List { get; set; }

        public IStringOrList ToStrings() {
            ListWrapper res = new();
            foreach (Statement e in List)
            {
                res.AddExpanding(e.ToStrings());
            }
            return res;
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
            if (Else != null) {
                res.Values.Add(new StringWrapper($"else"));
                res.Values.Add(Else.ToStrings());
            }
            res.Values.Add(new StringWrapper("end"));
            return res;
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
    }

    public class Return : Statement
    {
        public OluaObject Object { get; set; }

        public override string ToString() => $"return {Object}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }

    public class Parameter : Node
    {
        public string Name { get; set; }
        public TypeName Type { get; set; }

        public override string ToString() => $"{Name} : {Type}";
        public IStringOrList ToStrings() => new StringWrapper(ToString());
    }
}