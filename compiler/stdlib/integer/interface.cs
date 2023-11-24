using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class IntegerInterface : ExtendableClassInterface
    {
        public IntegerInterface()
        {
            Name = OLT.Integer.Identifier;
            Inf = Analyzer.theVeryBaseClass.extend(
                // Fields
                new Dictionary<string, TypeName>
                {
                    { "max", OLT.Integer },
                    { "min", OLT.Integer }
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversions
                    { "toReal", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Real } },
                    { "toBoolean", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                    
                    // Unary operators
                    { "unaryMinus", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    
                    // Integer binary arithmetics 
                    { "plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "div", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "rem", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    
                    // Relations
                    { "less", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "lessEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "greater", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "greaterEqual", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } },
                    { "equal", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Boolean } }
                }
            );
        }
    }
}
