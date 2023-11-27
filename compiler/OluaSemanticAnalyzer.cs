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
            var Fields = new Dictionary<string, TypeName>();
            var Methods = new Dictionary<string, MethodInterface>();

            foreach (var member in Members)
            {
                switch (member)
                {
                    case VariableDeclaration variable:
                        if (Fields.ContainsKey(variable.Name))
                            throw new InvalidOperationException($"Field {variable.Name} was already declared");
                        Fields[variable.Name] = variable.Type;
                        break;

                    case MethodDeclaration method:
                        if (Methods.ContainsKey(method.Name))
                            throw new InvalidOperationException($"Method {method.Name} was already declared");
                        Methods[method.Name] = MethodInterface.FromMethodDeclaration(method);
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown member type: {member.GetType()}");
                }
            }

            // check overloaded methods have the same signature
            foreach (var method in Methods)
            {
                var name = method.Key;
                var newSignature = method.Value;
                if (baseClassMethods.ContainsKey(name))
                {
                    var oldSignature = baseClassMethods[name];

                    if (oldSignature.ReturnType != newSignature.ReturnType)
                        throw new InvalidOperationException("Overloaded method " + name + " return type mismatch");

                    if (newSignature.Parameters.Count != oldSignature.Parameters.Count)
                        throw new InvalidOperationException("Overloaded method " + name + " parameter count mismatch");

                    for (int i = 0; i < newSignature.Parameters.Count; i++)
                    {
                        if (!newSignature.Parameters[i].Equals(oldSignature.Parameters[i]))
                            throw new InvalidOperationException($"Overloaded method {name} parameter {i} type mismatch");
                    }
                }
            }

            // check overloaded fields have the same types
            foreach (var field in Fields)
            {
                var name = field.Key;
                var newType = field.Value;
                if (baseClassFields.ContainsKey(name))
                {
                    var oldType = baseClassFields[name];

                    if (newType != oldType)
                        throw new InvalidOperationException("Overloaded field " + name + " type mismatch");
                }
            }


            return new ClassInterface
            {
                BaseClass = baseClass,
                ConstructorParameters = new List<TypeName>(),
                Fields = baseClassFields.Concat(Fields.Where(kvp => !baseClassFields.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                Methods = baseClassMethods.Concat(Methods.Where(kvp => !baseClassMethods.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
            };
        }
    }

    public class ExtendableClassInterface
    {
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
                Fields = Inf.Fields.Concat(newFields.Where(kvp => !Inf.Fields.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                Methods = Inf.Methods.Concat(newMethods.Where(kvp => !Inf.Methods.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
            };
        }
    }

    class Analyzer
    {
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
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface> {
                    {
                        "main",
                        new MethodInterface{
                            Parameters = new List<TypeName>
                            {
                                typeStdIn,
                                typeStdOut,
                                typeStdOut,
                                typeArray(typeArray(typeInteger))
                            },
                            ReturnType = typeInteger,
                        }
                    }
                }
            );
        }

        void checkNotPresentType(string name)
        {
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
                if (linkClasses.ContainsKey(curType.Identifier))
                {
                    if (curType.GenericType != null)
                    {
                        throw new InvalidOperationException($"{curType.Identifier} cannot have generic");
                    }
                    break;
                }
                else if (linkGenerics.ContainsKey(curType.Identifier))
                {
                    if (curType.GenericType == null)
                    {
                        throw new InvalidOperationException($"{curType.Identifier} must have generic");
                    }
                    curType = curType.GenericType;
                }
                else
                {
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
            TypeName? t = InferType(@this, variables, attribute.Parent);
            if (t == null)
                throw new InvalidOperationException($"Unknown or void resulting type of {attribute.Parent}");
            ClassInterface inf = GetInterface(t);
            if (!inf.Methods.ContainsKey(attribute.Identifier))
                throw new InvalidOperationException($"Unknown method {attribute.Identifier}");
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
                TypeName? t = InferType(@this, variables, arguments[i]);
                ValidSubtype(parameters[i], t);
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
                    thisIdentifier.Type = @this;
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
                    TypeName? t = InferType(@this, variables, attributeObject.Parent);
                    if (t == null)
                        throw new InvalidOperationException($"Unknown or void resulting type of {attributeObject.Parent}");
                    ClassInterface inf = GetInterface(t);
                    if (!inf.Fields.ContainsKey(attributeObject.Identifier))
                        throw new InvalidOperationException($"Unknown attribute {attributeObject.Identifier}");
                    attributeObject.AttributeType = inf.Fields[attributeObject.Identifier];
                    return attributeObject.AttributeType;

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
                    methodInvocation.ReturnType = mi.ReturnType;
                    return mi.ReturnType;

                default:
                    throw new InvalidOperationException($"Unknown object type: {obj.GetType().Name}");
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
                        MethodInterface mi = ResolveMethod(@this, variables, methodInvocation.Method);
                        CheckParamSubmission(
                            @this,
                            variables,
                            methodInvocation.Arguments.List,
                            mi.Parameters
                        );
                        methodInvocation.ReturnType = mi.ReturnType;
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
        public List<ClassDeclaration> LinkValidateAndOptimize(List<ClassDeclaration> classes)
        {
            // 0. patrial validations that does not require back looking (ClassInterface.fromDecl)
            var tclasses = new List<ClassDeclaration>(classes);  // Shallow copy
            while (true)
            {
                bool end = true;
                foreach (var @class in tclasses.ToList())  // ToList creates a copy to allow modification during iteration
                {
                    if (@class.BaseClass != null && @class.BaseClass.GenericType != null)
                        throw new InvalidOperationException("Prohibited to extend generic");

                    string? BaseClass = @class.BaseClass == null ? null : @class.BaseClass.Identifier;

                    if (BaseClass != null && !linkClasses.ContainsKey(BaseClass)) continue;
                    end = false;

                    if (BaseClass == null)
                    {
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
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException("Error in class " + @class.Name + " : " + ex.Message);
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
                            if (name != "Main")
                                throw new InvalidOperationException("A class that extends EntryPoint must be named Main");
                            entryPoint = true;
                        }
                    }

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

            // 3. optimize bodies

            foreach (var cls in classes)
            {
                var updatedMembers = new List<ClassMember>(cls.Members);

                foreach (var member in cls.Members.ToList()) // ToList to avoid modifying the collection while iterating
                {
                    Console.WriteLine($"Current member is {member}");
                    switch (member)
                    {
                        case MethodDeclaration method:
                            updatedMembers = OptimizeScope(method.Statements.List, new HashSet<string>(), updatedMembers);
                            break;
                    }
                }

                // Remove unused variable declarations
                Console.WriteLine("Removing code lines with unused variables");

                cls.Members = updatedMembers; // Update the members of the class
            }

            return classes;
        }

        private List<ClassMember> OptimizeScope(List<Statement> statements, HashSet<string> usedVariables, List<ClassMember> members)
        {
            var localVariables = new HashSet<string>();
            var assignmentsToVariables = new List<Assignment>();

            foreach (var statement in statements)
            {
                switch (statement)
                {
                    case Assignment assignment:
                        Console.WriteLine($"\tAssignment: {assignment}, variable: {assignment.Variable}, value: {assignment.Value}");
                        assignmentsToVariables.Add(assignment);
                        MarkVariableAsUsed(assignment.Variable, usedVariables, localVariables);
                        MarkVariableAsUsed(assignment.Value, usedVariables, localVariables);
                        break;
                    case If @if:
                        MarkVariableAsUsed(@if.Cond, usedVariables, localVariables);
                        OptimizeScope(@if.Then.List, usedVariables, members);
                        if (@if.Else != null) OptimizeScope(@if.Else.List, usedVariables, members);
                        break;
                    case While @while:
                        Console.WriteLine($"\tWhile loop: {@while}");
                        MarkVariableAsUsed(@while.Cond, usedVariables, localVariables);
                        OptimizeScope(@while.Body.List, usedVariables, members);
                        break;
                    case Return @return:
                        if (@return.Object is ObjectIdentifier identifier)
                        {
                            MarkVariableAsUsed(identifier, usedVariables, localVariables);
                        }
                        break;
                    case Scope nestedScope:
                        // Handle nested scopes
                        Console.WriteLine($"\tScope: {nestedScope}");
                        OptimizeScope(nestedScope.Statements.List, usedVariables, members);

                        // Additionally, check for usages of outer scope variables in the nested scope
                        foreach (var nestedStatement in nestedScope.Statements.List)
                        {
                            CheckForOuterScopeVariableUsage(nestedStatement, localVariables, usedVariables);
                        }
                        break;
                    case VariableDeclaration variableDeclaration:
                        Console.WriteLine($"\tVariableDeclaration: {variableDeclaration}");
                        localVariables.Add(variableDeclaration.Name);
                        break;
                    case MethodInvocation methodInvocation:
                        MarkVariableAsUsed(methodInvocation.Method, usedVariables, localVariables);
                        foreach (var arg in methodInvocation.Arguments.List)
                        {
                            MarkVariableAsUsed(arg, usedVariables, localVariables);
                        }
                        break;
                        // Add other statement types as necessary
                }
            }

            Console.WriteLine($"\tlocalVariables are:");

            foreach (var variableName in localVariables)
            {
                Console.WriteLine($"\t\t{variableName}");

                if (!usedVariables.Contains(variableName))
                {
                    Console.WriteLine($"\t\tRecognized unused variable: {variableName}");

                    // Print the variable declaration
                    var unusedVarDeclaration = statements.OfType<VariableDeclaration>()
                                                .FirstOrDefault(v => v.Name == variableName);
                    if (unusedVarDeclaration != null)
                    {
                        Console.WriteLine($"\t\tUnused variable declaration: {unusedVarDeclaration}");
                        statements.Remove(unusedVarDeclaration);
                    }

                    // Print assignments to the unused variable
                    var unusedAssignments = assignmentsToVariables
                                            .Where(a => a.Variable.ToString() == variableName);
                    foreach (var assignment in unusedAssignments)
                    {
                        Console.WriteLine($"\t\tUnused variable assignment: {assignment}");
                        statements.Remove(assignment);
                    }
                }
            }

            return members;
        }

        private void CheckForOuterScopeVariableUsage(Statement statement, HashSet<string> localVariables, HashSet<string> usedVariables)
        {
            switch (statement)
            {
                case Assignment assignment:
                    MarkVariableAsUsed(assignment.Variable, usedVariables, localVariables);
                    MarkVariableAsUsed(assignment.Value, usedVariables, localVariables);
                    break;
                case MethodInvocation methodInvocation:
                    // Check the method invocation for usage of local variables
                    MarkVariableAsUsed(methodInvocation.Method, usedVariables, localVariables);
                    foreach (var arg in methodInvocation.Arguments.List)
                    {
                        MarkVariableAsUsed(arg, usedVariables, localVariables);
                    }
                    break;
                case While @while:
                    MarkVariableAsUsed(@while.Cond, usedVariables, localVariables);
                    foreach (var whileStatement in @while.Body.List)
                    {
                        CheckForOuterScopeVariableUsage(whileStatement, localVariables, usedVariables);
                    }
                    break;
                case If @if:
                    MarkVariableAsUsed(@if.Cond, usedVariables, localVariables);
                    foreach (var thenStatement in @if.Then.List)
                    {
                        CheckForOuterScopeVariableUsage(thenStatement, localVariables, usedVariables);
                    }
                    if (@if.Else != null)
                    {
                        foreach (var elseStatement in @if.Else.List)
                        {
                            CheckForOuterScopeVariableUsage(elseStatement, localVariables, usedVariables);
                        }
                    }
                    break;
            }
        }

        private void MarkVariableAsUsed(OluaObject variable, HashSet<string> usedVariables, HashSet<string> localVariables)
        {
            if (variable is ObjectIdentifier objectIdentifier)
            {
                if (localVariables.Contains(objectIdentifier.Identifier))
                {
                    Console.WriteLine($"    ObjectIdentifier variable added: {objectIdentifier.Identifier}");
                    usedVariables.Add(objectIdentifier.Identifier);
                }
            }
            else if (variable is AttributeObject attributeObject)
            {
                // Mark the attribute's identifier as used if it is a local variable
                if (localVariables.Contains(attributeObject.Identifier))
                {
                    // Console.WriteLine($"    AttributeObject variable added: {attributeObject.Identifier}");
                    usedVariables.Add(attributeObject.Identifier);
                }

                // Continue to check the parent object
                // Console.WriteLine($"    Checking parent of AttributeObject: {attributeObject.Parent}");
                MarkVariableAsUsed(attributeObject.Parent, usedVariables, localVariables);
            }
            else if (variable is MethodInvocation methodInvocation)
            {
                // If the method is called on an attribute object, check the attribute
                if (methodInvocation.Method is AttributeObject methodAttributeObject)
                {
                    MarkVariableAsUsed(methodAttributeObject, usedVariables, localVariables);
                }

                // Check each argument in the method call
                foreach (var arg in methodInvocation.Arguments.List)
                {
                    // Console.WriteLine($"    MethodInvocation variable here: {arg}");
                    MarkVariableAsUsed(arg, usedVariables, localVariables);
                }
            }
            // Handle other OluaObject types as necessary
        }
    }
}