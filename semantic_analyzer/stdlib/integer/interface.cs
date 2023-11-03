using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class IntegerInterface : ExtendableClassInterface {
        public IntegerInterface() {
            Name = "Integer";
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName> { OLT.Integer },
                // Fields
                new Dictionary<string, TypeName>
                {
                    { "Max", OLT.Integer },
                    { "Min", OLT.Integer }
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
