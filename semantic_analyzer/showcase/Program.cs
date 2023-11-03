using OluaAST;
using OluaLexer;
using OluaParser;
using OluaSemanticAnalyzer;

public class Application
{
    const string target = "program.olua";
    public static void Main()
    {
        Scanner scanner = new(File.ReadAllText(target));

        Parser parser = new(scanner);
        bool success = parser.Parse();

        if (!success) {
            Console.WriteLine($"Syntax error at {Path.GetFullPath(target)}({scanner.yylloc.StartLine},{scanner.yylloc.StartColumn})");
        }

        Analyzer analyzer = new();

        try {
            analyzer.LinkFromASTAndValidate(parser.Program);
        } catch (InvalidOperationException ex) {
            Console.WriteLine(ex.Message);
        }
    }
}

