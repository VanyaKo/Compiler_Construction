using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OluaLexer
{
    public enum Tokens
    {
        EOF = -1,
        ERROR = 0,
        CLASS,
        EXTENDS,
        IS,
        METHOD,
        VAR,
        IF,
        ELSE,
        WHILE,
        RETURN,
        THIS,
        END,
        ASSIGN,
        IDENTIFIER,
        COLON,
        SEMICOLON,
        LPAREN,
        RPAREN,
        LBRACKET,
        RBRACKET,
        DOT,
        INTEGER_LITERAL,
        FLOAT_LITERAL,
        LOOP,
        TRUE,
        FALSE,
    }

    public class Scanner
    {

        private string _input = string.Empty;
        private int _position = 0;
        public string yylval { get; private set; } = string.Empty;

        public void SetSource(string source, int position)
        {
            _input = source;
            _position = position;
        }

        public int yylex()
        {
            if (_position >= _input.Length) return (int)Tokens.EOF;

            // Define your regex patterns for each token
            var patterns = new List<(Regex, Tokens)>
            {
                (new Regex(@"^[ \t\r\n\f]+"), Tokens.ERROR),  // Consume white space
                (new Regex(@"^//.*"), Tokens.ERROR),         // Consume single-line comments
                (new Regex(@"^class\b"), Tokens.CLASS),
                (new Regex(@"^extends\b"), Tokens.EXTENDS),
                (new Regex(@"^is\b"), Tokens.IS),
                (new Regex(@"^method\b"), Tokens.METHOD),
                (new Regex(@"^var\b"), Tokens.VAR),
                (new Regex(@"^if\b"), Tokens.IF),
                (new Regex(@"^else\b"), Tokens.ELSE),
                (new Regex(@"^while\b"), Tokens.WHILE),
                (new Regex(@"^return\b"), Tokens.RETURN),
                (new Regex(@"^this\b"), Tokens.THIS),
                (new Regex(@"^end\b"), Tokens.END),
                (new Regex(@"^loop\b"), Tokens.LOOP),
                (new Regex(@"^true\b"), Tokens.TRUE),
                (new Regex(@"^false\b"), Tokens.FALSE),
                (new Regex(@"^:="), Tokens.ASSIGN),
                (new Regex(@"^:"), Tokens.COLON),
                (new Regex(@"^;"), Tokens.SEMICOLON),
                (new Regex(@"^\("), Tokens.LPAREN),
                (new Regex(@"^\)"), Tokens.RPAREN),
                (new Regex(@"^\["), Tokens.LBRACKET),
                (new Regex(@"^\]"), Tokens.RBRACKET),
                (new Regex(@"^\."), Tokens.DOT),
                (new Regex(@"^[0-9]*\.[0-9]+([eE][+-]?[0-9]+)?"), Tokens.FLOAT_LITERAL),
                (new Regex(@"^[0-9]+"), Tokens.INTEGER_LITERAL),
                (new Regex(@"^[A-Za-z_][A-Za-z_0-9]*"), Tokens.IDENTIFIER),
            };

            foreach (var (regex, token) in patterns)
            {
                var match = regex.Match(_input.Substring(_position));
                if (match.Success)
                {
                    yylval = match.Value;
                    _position += match.Length;
                    return token == Tokens.ERROR ? yylex() : (int)token;
                }
            }

            _position++;  // Move past unrecognized character
            return (int)Tokens.ERROR;  // Default to error for unrecognized patterns
        }
    }
}
