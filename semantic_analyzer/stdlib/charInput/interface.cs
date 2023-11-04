using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class CharInputInterface : ExtendableClassInterface {
        public CharInputInterface() {
            Name = "CharInput";
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(), // Assuming no constructor parameters are needed
                // Fields
                new Dictionary<string, TypeName>
                {
                    // Can be added if needed
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    { "Available", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "Read", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "ReadLine", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = new TypeName { Identifier = "Array", GenericType = new TypeName { Identifier = "Integer",  GenericType = null  } } } },
                    { "Read", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = new TypeName { Identifier = "Array", GenericType = new TypeName { Identifier = "Integer",  GenericType = null  } } } }
                }
            );
        }
    }
}
