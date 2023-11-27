using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class RealInterface : ExtendableClassInterface
    {
        public RealInterface()
        {
            Name = OLT.Real.Identifier;
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>
                {
                    { "max", OLT.Real },
                    { "min", OLT.Real },
                    { "epsilon", OLT.Real }
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversions
                    { "toInteger", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    
                    // Unary operators
                    { "unaryMinus", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Real } },
                    
                    // Real binary arithmetics
                    { "plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "div", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "rem", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    
                    // Relations
                    { "less", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "lessEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "greater", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "greaterEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "equal", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
