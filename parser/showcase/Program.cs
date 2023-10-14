using OluaLexer;
using OluaParser;

public class Application
{
    public static void Main()
    {
        // Initialize the lexer with the input code
        Scanner scanner = new();
        scanner.SetSource(File.ReadAllText("program.olua"), 0);

        // Initialize the parser with the lexer
        Parser parser = new(scanner);
        bool success = parser.Parse();

        // Parse the input code
        if (success)
        {
            Console.WriteLine("Parsing successful!");
            // TODO: Do something with the parsed result (e.g., create an AST, evaluate expressions, etc.)
        }
        else
        {
            Console.WriteLine("Parsing failed!");
        }
    }
}
