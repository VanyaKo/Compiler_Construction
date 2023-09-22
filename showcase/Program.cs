using System;
using OluaLexer;

public class Showcase 
{
    public static void Main(string[] args) 
    {
        var lexer = new OluaLexer.Scanner();
        lexer.SetSource(System.IO.File.ReadAllText("program.olua"), 0);
        
        int token;
        while ((token = lexer.yylex()) != (int)OluaLexer.Tokens.EOF) 
        {
            System.Console.WriteLine($"Token: {token}, Value: {lexer.yylval}");
        }
    }
}
