using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class CharOutputInterface : ExtendableClassInterface
    {
        public CharOutputInterface()
        {
            Name = OLT.CharOutput.Identifier;
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
                    { "available", new MethodInterface { Parameters = new List<TypeName>(), ReturnType = OLT.Integer } },
                    { "writeChar", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = null } },
                    { "write", new MethodInterface { Parameters = new List<TypeName> { OLT.Array(OLT.Integer) }, ReturnType = null } },
                    { "writeLine", new MethodInterface { Parameters = new List<TypeName> { OLT.Array(OLT.Integer) }, ReturnType = null } }
                }
            );
        }
    }
}
