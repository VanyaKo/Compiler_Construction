using System;
using OluaLexer;

public class Application
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the code to parse:");
        string code = Console.ReadLine();

        // Initialize the lexer with the input code
        Scanner scanner = new Scanner(new System.IO.StringReader(code));

        // Initialize the parser with the lexer
        Parser parser = new Parser(scanner);

        // Parse the input code
        var success = parser.Parse();

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
