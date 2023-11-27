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
                    { "toReal", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Real } },
                    { "toBoolean", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                    
                    // Arithmetics 
                    { "plus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "minus", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "mult", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "divide", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    { "reminder", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Integer } },
                    
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
