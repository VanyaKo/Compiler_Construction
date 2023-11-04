using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class StdInInterface : CharInputInterface {
        public StdInInterface() {
            Name = "StdIn";
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // add if needed
                }
            );
        }
    }
}
