using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class CharInputInterface : ExtendableClassInterface
    {
        public CharInputInterface()
        {
            Name = OLT.CharInput.Identifier;
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
                    // { "avaliable", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } }, // not implemented
                    { "readChar", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "readLine", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Array(OLT.Integer) }  },
                    { "read", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = OLT.Array(OLT.Integer) } }
                }
            );
        }
    }
}
