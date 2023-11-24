using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class StdInInterface : ExtendableClassInterface
    {
        public StdInInterface()
        {
            Name = OLT.StdIn.Identifier;
            Inf = new CharInputInterface().extend(
                // Fields
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    // add if needed
                }
            );
        }
    }
}
