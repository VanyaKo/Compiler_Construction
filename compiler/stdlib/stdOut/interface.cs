using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces
{
    public class StdOutInterface : ExtendableClassInterface
    {
        public StdOutInterface()
        {
            Name = OLT.StdOut.Identifier;
            Inf = new CharOutputInterface().extend(
                // Constructor parameters
                new List<TypeName>(),
                // Fields
                new Dictionary<string, TypeName>(),
                // Methods
                new Dictionary<string, MethodInterface>
                { }
            );
        }
    }
}
