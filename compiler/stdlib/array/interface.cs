using OluaAST;
using OluaStdLibTypes;
using OluaSemanticAnalyzer;

namespace OluaStdLibInterfaces {
    public class ArrayGeneric : IGenericFactory {
        public ClassInterface Gen(TypeName typeName) {
            return Analyzer.theVeryBaseClass.extend(
                // Constructor parameters
                new List<TypeName> { OLT.Integer },
                // Fields
                new Dictionary<string, TypeName>
                {
                    // Can be added if needed
                },
                // Methods
                new Dictionary<string, MethodInterface>
                {
                    { "len", new MethodInterface { Parameters = new List<TypeName> { }, ReturnType = OLT.Integer } },
                    { "get", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer }, ReturnType = typeName } },
                    { "set", new MethodInterface { Parameters = new List<TypeName> { OLT.Integer, typeName }, ReturnType = null } },
                }
            );
        }
    }
}
