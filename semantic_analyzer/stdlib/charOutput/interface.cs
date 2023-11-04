using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class CharOutputInterface : ExtendableClassInterface {
        public CharOutputInterface() {
            Name = "CharOutput";
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>
                {
                    // Can be added if needed
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    { "Available", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "WriteChar", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = new TypeName("Output", new List<TypeName> { OLT.Integer }) } },
                    { "Write", new MethodInterface { Parameters = new List<TypeName> { new TypeName { Identifier = "Array", GenericType = new TypeName { Identifier = "Integer",  GenericType = null  } } }, ReturnType = OLT.CharOutput } },
                    { "WriteLine", new MethodInterface { Parameters = new List<TypeName> { new TypeName { Identifier = "Array", GenericType = new TypeName { Identifier = "Integer",  GenericType = null  } } }, ReturnType = OLT.CharOutput } }
                }
            );
        }
    }
}
