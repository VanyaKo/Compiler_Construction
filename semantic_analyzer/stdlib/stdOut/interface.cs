using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class StdOutInterface : CharOutputInterface {
        public StdOutInterface() {
            Name = "StdOut";
            Inf = Analyzer.BaseClass.extend( // не знаю правильно ли написал
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    { "WriteInteger", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.CharOutput } },
                    { "WriteReal", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.CharOutput } },
                    { "WriteBoolean", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.CharOutput } },
                    { "WriteIntegerLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.CharOutput } },
                    { "WriteRealLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.CharOutput } },
                    { "WriteBooleanLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.CharOutput } }
                }
            );
        }
    }
}
