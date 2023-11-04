using OluaAST;
using OluaSemanticAnalyzer;

namespace OluaStdLibTypes {
    public static class OLT
    {
        public static readonly TypeName Class = Analyzer.typeClass;
        public static readonly TypeName Boolean = Analyzer.typeBoolean;
        public static readonly TypeName Integer = new TypeName { Identifier = "Integer", GenericType = null };
        public static readonly TypeName Real = new TypeName { Identifier = "Real", GenericType = null };
    }
}