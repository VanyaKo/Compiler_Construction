using OluaAST;
using OluaSemanticAnalyzer;

namespace OluaStdLibTypes {
    public static class OLT
    {
        public static readonly TypeName Class = Analyzer.typeClass;
        public static readonly TypeName Boolean = Analyzer.typeBoolean;
        public static readonly TypeName Integer = Analyzer.typeInteger;
        public static readonly TypeName Real = Analyzer.typeReal;
        public static readonly TypeName StdIn = Analyzer.typeStdIn;
        public static readonly TypeName StdOut = Analyzer.typeStdOut;
        public static readonly TypeName CharInput = new TypeName { Identifier = "CharInput", GenericType = null };
        public static readonly TypeName CharOutput = new TypeName { Identifier = "CharOutput", GenericType = null };
    }
}