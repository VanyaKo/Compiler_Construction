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
                    // Conversions
                    { "toReal", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Real } },
                    { "toBoolean", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                    
                    // Unary operators
                    { "UnaryMinus", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    
                    // Integer binary arithmetics 
                    { "Plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "Minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "Mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "Div", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "Rem", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    
                    // Relations
                    { "Less", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "LessEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "Greater", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "GreaterEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "Equal", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } }
                }
            );
        }
    }
}
