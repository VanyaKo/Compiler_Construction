using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class BooleanInterface : ExtendableClassInterface
    {
        public BooleanInterface()
        {
            Name = OLT.Boolean.Identifier;
            Inf = Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>
                {
                    // Can be added if needed
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // Conversion
                    { "toInteger", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "toString", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Array(OLT.Integer) } },

                    // Boolean operators
                    { "or", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "and", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "not", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
