using OluaLexer;

public class Showcase 
{
    public static void Main() 
    {
        var lexer = new Scanner();
        lexer.SetSource(File.ReadAllText("program.olua"), 0);
        
        int token;
        while ((token = lexer.yylex()) != (int)Tokens.EOF) 
        {
            Console.WriteLine($"Token: {token}, Value: {lexer.yylval}");
        }
    }
}
