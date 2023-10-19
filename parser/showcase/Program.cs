using Indent;
using OluaAST;
using OluaLexer;
using OluaParser;

public class Application
{
    const string target = "program.olua";
    public static void Main()
    {
        // Initialize the lexer with the input code
        Scanner scanner = new(File.ReadAllText(target));

        // Initialize the parser with the lexer
        Parser parser = new(scanner);
        bool success = parser.Parse();

        // Parse the input code
        if (success)
        {
            Console.WriteLine("Parsing successful!");
            Indentator idnt = new();
            foreach (ClassDeclaration cls in parser.Program) {
                Console.WriteLine(idnt.Traverse(cls.ToStrings()));
            }
        }
        else
        {
            Console.WriteLine($"Parsing failed at {Path.GetFullPath(target)}({scanner.yylloc.StartLine},{scanner.yylloc.StartColumn})");
        }
    }
}

