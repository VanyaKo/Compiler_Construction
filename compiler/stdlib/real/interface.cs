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
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversions
                    { "toInteger", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "toString", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Array(OLT.Integer) } },
                    
                    // Arithmetics
                    { "plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "divide", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    { "reminder", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Real } },
                    
                    // Relations
                    { "less", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "greater", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                    { "equal", new MethodInterface { Parameters = new List<TypeName> { OLT.Real }, ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
