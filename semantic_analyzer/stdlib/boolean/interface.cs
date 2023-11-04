using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class BooleanInterface : ExtendableClassInterface {
        public BooleanInterface() {
            Name = "Boolean";
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName> { OLT.Boolean },
                // Fields
                new Dictionary<string, TypeName>
                {
                    // Can be added if needed
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversion
                    { "toInteger", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },

                    // Boolean operators
                    { "Or", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "And", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "Xor", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "Not", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
