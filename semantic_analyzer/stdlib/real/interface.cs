using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class RealInterface : ExtendableClassInterface {
        public RealInterface() {
            Name = OLT.Real.Identifier;
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName> { OLT.Real },
                // Fields
                new Dictionary<string, TypeName>
                {
                    { "Max", OLT.Real },
                    { "Min", OLT.Real },
                    { "Epsilon", OLT.Real }
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversions
                    { "toInteger", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    
                    // Unary operators
                    { "UnaryMinus", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Real } },
                    
                    // Real binary arithmetics
                    { "Plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "Minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "Mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "Div", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "Rem", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    
                    // Relations
                    { "Less", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "LessEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "Greater", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "GreaterEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "Equal", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
