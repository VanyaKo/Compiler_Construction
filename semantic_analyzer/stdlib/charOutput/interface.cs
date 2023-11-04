using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class CharOutputInterface : ExtendableClassInterface {
        public CharOutputInterface() {
            Name = OLT.CharOutput.Identifier;
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
                    { "WriteChar", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = null } },
                    { "Write", new MethodInterface { Parameters = new List<TypeName> { OLT.Array(OLT.Integer) }, ReturnType = null } },
                    { "WriteLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Array(OLT.Integer) }, ReturnType = null } }
                }
            );
        }
    }
}
