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

                    // Boolean operators
                    { "disjunct", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "conjunct", new MethodInterface { Parameters = new List<TypeName> { OLT.Boolean }, ReturnType = OLT.Boolean } },
                    { "negate", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Boolean } },
                }
            );
        }
    }
}
