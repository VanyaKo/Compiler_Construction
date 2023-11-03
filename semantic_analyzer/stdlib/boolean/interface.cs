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
                    // TODO: complete
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // TODO: complete
                }
            );
        }
    }
}
