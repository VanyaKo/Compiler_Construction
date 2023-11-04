using OluaAST;

namespace OluaSemanticAnalyzer
{
    public class MethodInterface
    {
        public List<TypeName> Parameters { get; set; }
        public TypeName? ReturnType { get; set; }

        public static MethodInterface FromMethodDeclaration(MethodDeclaration decl) =>
            new MethodInterface
            {
                Parameters = decl.Parameters.List.Select(e => e.Type).ToList(),
                ReturnType = decl.ReturnType
            };
    }

    public interface IGenericFactory
    {
        public ClassInterface Gen(TypeName typeName);
    }

    public class ClassInterface
    {
        public string? BaseClass { get; set; }
        public List<TypeName> ConstructorParameters { get; set; }
        public Dictionary<string, TypeName> Fields { get; set; }
        public Dictionary<string, MethodInterface> Methods { get; set; }

        public static ClassInterface FromDecl(
            List<ClassMember> Members,
            string? baseClass,
            Dictionary<string, TypeName> baseClassFields,
            Dictionary<string, MethodInterface> baseClassMethods
        )
        {
            var classInterface = new ClassInterface
            {
                BaseClass = baseClass,
                Fields = new Dictionary<string, TypeName>(baseClassFields),
                Methods = new Dictionary<string, MethodInterface>(baseClassMethods),
                ConstructorParameters = new List<TypeName>()
            };

            bool constructorFound = false;

            foreach (var member in Members)
            {
                switch (member)
                {
                    case ConstructorDeclaration constructor:
                        if (constructorFound)
                            throw new Exception("There must be exactly one constructor");
                        classInterface.ConstructorParameters = 
                            constructor.Parameters.List.Select(e => e.Type).ToList();
                        constructorFound = true;
                        break;

                    case VariableDeclaration variable:
                        if (classInterface.Fields.ContainsKey(variable.Name))
                            throw new Exception($"Field {variable.Name} was already declared");
                        classInterface.Fields[variable.Name] = variable.Type;
                        break;

                    case MethodDeclaration method:
                        if (classInterface.Methods.ContainsKey(method.Name))
                            throw new Exception($"Method {method.Name} was already declared");
                        classInterface.Methods[method.Name] = MethodInterface.FromMethodDeclaration(method);
                        break;

                    default:
                        throw new Exception($"Unknown member type: {member.GetType()}");
                }
            }

            if (!constructorFound)
                throw new Exception("No constructor found");

            return classInterface;
        }
    }

    public class ExtendableClassInterface {
        public string Name { get; set; }
        public ClassInterface Inf { get; set; }

        public ClassInterface extend(
            List<TypeName> newConstructorParameters,
            Dictionary<string, TypeName> newFields,
            Dictionary<string, MethodInterface> newMethods)
        {
            return new ClassInterface
            {
                BaseClass = Name,
                ConstructorParameters = newConstructorParameters,
                Fields = this.Inf.Fields.Concat(newFields.Where(kvp => !this.Inf.Fields.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                Methods = this.Inf.Methods.Concat(newMethods.Where(kvp => !this.Inf.Methods.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
            };
        }
    }

    class Analyzer {
        Dictionary<string, IGenericFactory> linkGenerics = new Dictionary<string, IGenericFactory>();
        Dictionary<string, ClassInterface> linkClasses = new Dictionary<string, ClassInterface>();

        public static TypeName typeArray(TypeName genericType)
        {
            return new TypeName
            {
                Identifier = "Array",
                GenericType = genericType
            };
        }
        public static readonly TypeName typeEntryPoint = new TypeName { Identifier = "EntryPoint", GenericType = null };
        public static readonly TypeName typeClass = new TypeName { Identifier = "Class", GenericType = null };
        public static readonly TypeName typeBoolean = new TypeName { Identifier = "Boolean", GenericType = null };
        public static readonly TypeName typeInteger = new TypeName { Identifier = "Integer", GenericType = null };
        public static readonly TypeName typeReal = new TypeName { Identifier = "Real", GenericType = null };
        public static readonly TypeName typeStdIn = new TypeName { Identifier = "StdIn", GenericType = null };
        public static readonly TypeName typeStdOut = new TypeName { Identifier = "StdOut", GenericType = null };

        private static readonly MethodInterface methodSameRef = new MethodInterface
        {
            Parameters = new List<TypeName> { typeClass },
            ReturnType = typeBoolean
        };

        public static readonly ExtendableClassInterface theVeryBaseClass = new ExtendableClassInterface
        {
            Name = typeClass.Identifier,
            Inf = new ClassInterface
            {
                BaseClass = null,
                ConstructorParameters = new List<TypeName>(),
                Fields = new Dictionary<string, TypeName>(),
                Methods = new Dictionary<string, MethodInterface>
                {
                    { "sameRef", methodSameRef }
                }
            }
        };

        public Analyzer()
        {
            linkClasses[typeClass.Identifier] = theVeryBaseClass.Inf;
            linkClasses[typeEntryPoint.Identifier] = theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName> {
                    { "exit_code", typeInteger }
                },
                // Methods
                new Dictionary<string, MethodInterface>()
            );
        }

        void checkNotPresentType(string name) {
            if (linkClasses.ContainsKey(name) || linkGenerics.ContainsKey(name))
                throw new InvalidOperationException($"Name collision of class {name}");
        }

        public void LinkGeneric(string name, IGenericFactory f)
        {
            checkNotPresentType(name);
            linkGenerics[name] = f;
        }

        public void LinkClass(string name, ClassInterface iface)
        {
            checkNotPresentType(name);
            linkClasses[name] = iface;
        }

        // null aka void is considered valid
        void ValidType(TypeName? type)
        {
            TypeName? curType = type;
            while (curType != null)
            {
                if (linkClasses.ContainsKey(curType.Identifier)) {
                    if (curType.GenericType != null) {
                        throw new InvalidOperationException($"{curType.Identifier} cannot have generic");
                    }
                    break;
                }                
                else if (linkGenerics.ContainsKey(curType.Identifier)) {
                    if (curType.GenericType == null) {
                        throw new InvalidOperationException($"{curType.Identifier} must have generic");
                    }
                    curType = curType.GenericType;
                }
                else {
                    throw new InvalidOperationException($"There is no class {curType.Identifier}");
                }
            }
        }

        bool IsValidSubtype(TypeName originT, TypeName? subT)
        {
            if (originT.GenericType != null || subT?.GenericType != null)
            {
                return subT == originT;
            }

            string? curType = subT?.Identifier;
            while (curType != null)
            {
                if (curType == originT.Identifier) return true;
                curType = linkClasses[curType].BaseClass;
            }
            return false;
        }

        void ValidSubtype(TypeName originT, TypeName? subT)
        {
            if (!IsValidSubtype(originT, subT))
                throw new InvalidOperationException($"{(subT != null ? subT.ToString() : "void")} is not a subtype of {originT}");
        }

        ClassInterface GetInterface(TypeName t)
        {
            ValidType(t);
            return t.GenericType != null ? linkGenerics[t.Identifier].Gen(t.GenericType) : linkClasses[t.Identifier];
        }

        MethodInterface ResolveMethod(TypeName? @this, Dictionary<string, TypeName> variables, AttributeObject attribute)
        {
            TypeName t = InferType(@this, variables, attribute.Parent);
            ClassInterface inf = GetInterface(t);
            if (!inf.Methods.ContainsKey(attribute.Identifier))
                throw new InvalidOperationException("Unknown method");
            return inf.Methods[attribute.Identifier];
        }

        void CheckParamSubmission(
            TypeName? @this,
            Dictionary<string, TypeName> variables,
            List<OluaObject> arguments,
            List<TypeName> parameters
        )
        {
            if (parameters.Count != arguments.Count)
                throw new InvalidOperationException("Invalid parameters count");
            for (int i = 0; i < arguments.Count; i++)
            {
                TypeName t = InferType(@this, variables, arguments[i]);
                if (!IsValidSubtype(parameters[i], t))
                    throw new InvalidOperationException($"{t} is not a subtype of {parameters[i]}");
            }
        }


        // inferes type with all the type checks at the same time
        // also inferred type is always a valid type
        // returns null for void type
        TypeName? InferType(TypeName? @this, Dictionary<string, TypeName> variables, OluaObject obj)
        {
            switch (obj)
            {
                case ThisIdentifier thisIdentifier:
                    return @this;

                case ObjectIdentifier objectIdentifier:
                    if (!variables.ContainsKey(objectIdentifier.Identifier))
                        throw new InvalidOperationException($"Undeclared variable {objectIdentifier.Identifier}");
                    return variables[objectIdentifier.Identifier];

                case Literal<int>:
                    return typeInteger; 

                case Literal<float>:
                    return typeReal; 

                case Literal<bool>:
                    return typeBoolean; 

                case AttributeObject attributeObject:
                    TypeName t = InferType(@this, variables, attributeObject.Parent);
                    ClassInterface inf = GetInterface(t);
                    if (!inf.Fields.ContainsKey(attributeObject.Identifier))
                        throw new InvalidOperationException($"Unknown attribute {attributeObject.Identifier}");
                    return inf.Fields[attributeObject.Identifier];

                case ConstructorInvocation constructorInvocation:
                    TypeName cnstrT = constructorInvocation.Type;
                    ClassInterface cinf = GetInterface(cnstrT);
                    CheckParamSubmission(
                        @this,
                        variables,
                        constructorInvocation.Arguments.List,
                        cinf.ConstructorParameters
                    );
                    return cnstrT;

                case MethodInvocation methodInvocation:
                    MethodInterface mi = ResolveMethod(@this, variables, methodInvocation.Method);
                    CheckParamSubmission(
                        @this,
                        variables,
                        methodInvocation.Arguments.List,
                        mi.Parameters
                    );
                    return mi.ReturnType;

                default:
                    throw new Exception($"Unknown object type: {obj.GetType().Name}");
            }
        }

        void ValidScope(
            TypeName? @this,
            Dictionary<string, TypeName> variables, // mapping from variable name to its type
            TypeName? returnType,
            List<Statement> statementList
        )
        {
            variables = new Dictionary<string, TypeName>(variables); // creates a copy of the variables dictionary
            foreach (var statement in statementList)
            {
                switch (statement)
                {
                    case Scope scope:
                        ValidScope(@this, variables, returnType, scope.Statements.List);
                        break;

                    case Assignment assignment:
                        TypeName? argT = InferType(@this, variables, assignment.Value);
                        if (argT == null)
                            throw new InvalidOperationException("Cannot assign void");
                        TypeName paramT = InferType(@this, variables, assignment.Variable) ?? throw new InvalidOperationException("Variable type cannot be null");
                        ValidSubtype(paramT, argT);
                        break;

                    case If @if:
                        TypeName? argTIf = InferType(@this, variables, @if.Cond);
                        ValidSubtype(typeBoolean, argTIf);
                        ValidScope(@this, variables, returnType, @if.Then.List);
                        if (@if.Else != null)
                            ValidScope(@this, variables, returnType, @if.Else.List);
                        break;

                    case While @while:
                        TypeName? argTWhile = InferType(@this, variables, @while.Cond);
                        ValidSubtype(typeBoolean, argTWhile);
                        ValidScope(@this, variables, returnType, @while.Body.List);
                        break;

                    case Return @return:
                        TypeName? argTReturn = InferType(@this, variables, @return.Object);
                        if (returnType == null && argTReturn != null)
                            throw new InvalidOperationException("Method requires void return type");
                        ValidSubtype(returnType, argTReturn);
                        break;

                    case MethodInvocation methodInvocation:
                        CheckParamSubmission(
                            @this,
                            variables,
                            methodInvocation.Arguments.List,
                            ResolveMethod(@this, variables, methodInvocation.Method).Parameters
                        );
                        break;

                    case VariableDeclaration variableDeclaration:
                        TypeName? argTVarDecl = InferType(@this, variables, variableDeclaration.InitialValue);
                        ValidSubtype(variableDeclaration.Type, argTVarDecl);
                        variables[variableDeclaration.Name] = variableDeclaration.Type;
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown statement type: {statement.GetType().Name}");
                }
            }
        }

        // classes from ast
        // linkClasses to link extenally provided classes, usually the runtime library classes
        // NOTE: all inheritance must be done inside the provided bunch of classes
        public void LinkFromASTAndValidate(List<ClassDeclaration> classes)
        {
            // 0. patrial validations that does not require back looking (ClassInterface.fromDecl)
            var tclasses = new List<ClassDeclaration>(classes);  // Shallow copy
            while (true)
            {
                bool end = true;
                foreach (var @class in tclasses.ToList())  // ToList creates a copy to allow modification during iteration
                {
                    string? BaseClass = @class.BaseClass.Identifier;
                    if (@class.BaseClass.GenericType != null)
                        throw new InvalidOperationException("Prohibited to extend generic");

                    if (BaseClass != null && !linkClasses.ContainsKey(BaseClass)) continue;
                    end = false;

                    if (BaseClass == null) {
                        BaseClass = typeClass.Identifier;
                    }

                    checkNotPresentType(@class.Name);

                    var BaseClassFields = new Dictionary<string, TypeName>();
                    var BaseClassMethods = new Dictionary<string, MethodInterface>();

                    if (BaseClass != null)
                    {
                        var baseClassInterface = linkClasses[BaseClass];
                        BaseClassFields = new Dictionary<string, TypeName>(baseClassInterface.Fields);
                        BaseClassMethods = new Dictionary<string, MethodInterface>(baseClassInterface.Methods);
                    }
                    try
                    {
                        linkClasses[@class.Name] = ClassInterface.FromDecl(@class.Members, BaseClass, BaseClassFields, BaseClassMethods);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString() + " caused by " + @class.Name);
                    }
                    tclasses.Remove(@class);
                }
                if (end) break;
            }

            if (tclasses.Count != 0)
            {
                throw new InvalidOperationException("Unresolved base classes : " + string.Join(", ", tclasses.Select(e => e.BaseClass)));
            }

            // 1. basic validation of type existence and EntryPoint usage
            {
                bool entryPoint = false;
                foreach (var kvp in linkClasses)
                {
                    var name = kvp.Key;
                    var cls = kvp.Value;

                    if (cls.BaseClass != null)
                    {
                        if (cls.BaseClass == name)
                            throw new InvalidOperationException("Cannot extend from itself");
                        if (!linkClasses.ContainsKey(cls.BaseClass))
                            throw new InvalidOperationException($"Base class of class {name} is invalid");

                        if (cls.BaseClass == typeEntryPoint.Identifier)
                        {
                            if (entryPoint)
                                throw new InvalidOperationException("There must be exactly one class that extends EntryPoint");
                            entryPoint = true;

                            var requiredParameters = new List<TypeName>
                            {
                                typeStdIn,
                                typeStdOut,
                                typeStdOut,
                                typeArray(typeArray(typeInteger))
                            };

                            if (cls.ConstructorParameters.Count != 4)
                                throw new InvalidOperationException("Invalid entry point parameter count");

                            for (int i = 0; i < cls.ConstructorParameters.Count; i++)
                            {
                                if (!cls.ConstructorParameters[i].Equals(requiredParameters[i]))
                                    throw new InvalidOperationException("EntryPoint constructor parameter type mismatch");
                            }
                        }
                    }

                    foreach (var paramT in cls.ConstructorParameters)
                        ValidType(paramT);

                    foreach (var type in cls.Fields.Values)
                        ValidType(type);

                    foreach (var mi in cls.Methods.Values)
                    {
                        foreach (var paramT in mi.Parameters)
                            ValidType(paramT);
                        ValidType(mi.ReturnType);
                    }
                }
                if (!entryPoint)
                    throw new InvalidOperationException("No entry point defined");
            }

            // 2. validate bodies
            foreach (var cls in classes)
            {
                var thisType = new TypeName { Identifier = cls.Name, GenericType = null };
                foreach (var member in cls.Members)
                {
                    switch (member)
                    {
                        case ConstructorDeclaration constructor:
                            var variables = new Dictionary<string, TypeName>();

                            foreach (var p in constructor.Parameters.List)
                                variables[p.Name] = p.Type;

                            ValidScope(thisType, variables, null, constructor.Statements.List);
                            break;

                        case VariableDeclaration variable:
                            var argT = InferType(null, new Dictionary<string, TypeName>(), variable.InitialValue);
                            ValidSubtype(variable.Type, argT);
                            break;

                        case MethodDeclaration method:
                            var variablesMethod = new Dictionary<string, TypeName>();

                            foreach (var p in method.Parameters.List)
                                variablesMethod[p.Name] = p.Type;

                            ValidScope(thisType, variablesMethod, method.ReturnType, method.Statements.List);
                            break;

                        default:
                            throw new InvalidOperationException($"Unknown member type: {member.GetType().Name}");
                    }
                }
            }
        }
    }
}
