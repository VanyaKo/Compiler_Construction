using OluaAST;
using OluaSemanticAnalyzer;

namespace OluaStdLibTypes
{
    public static class OLT
    {
        public static readonly TypeName Class = Analyzer.typeClass;
        public static readonly TypeName Boolean = Analyzer.typeBoolean;
        public static readonly TypeName Integer = Analyzer.typeInteger;
        public static readonly TypeName Real = Analyzer.typeReal;
        public static readonly TypeName CharInput = Analyzer.typeCharInput;
        public static readonly TypeName CharOutput = Analyzer.typeCharOutput;
        public static TypeName Array(TypeName genericType) => Analyzer.typeArray(genericType);
    }
}