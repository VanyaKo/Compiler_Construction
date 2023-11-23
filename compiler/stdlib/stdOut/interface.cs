using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class StdOutInterface : ExtendableClassInterface {
        public StdOutInterface() {
            Name = OLT.StdOut.Identifier;
            Inf = new CharOutputInterface().extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    { "writeInteger", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = null } },
                    { "writeReal", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = null } },
                    { "writeBoolean", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = null } },
                    { "writeIntegerLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = null } },
                    { "writeRealLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = null } },
                    { "writeBooleanLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = null } }
                }
            );
        }
    }
}
