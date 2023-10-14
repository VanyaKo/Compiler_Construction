using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using OluaParser;
using StarodubOleg.GPPG.Runtime;


namespace OluaLexer
{
    public enum Tokens
    {
        ERROR = 2,
        EOF,
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
        COMMA,
        THEN,
    }

    public class Scanner : ScanBase
    {

        private string _input = string.Empty;
        private int _position = 0;
        public new string yylval { get; private set; } = string.Empty;

        public Scanner() {
            yylloc = new LexLocation(1, 1, 1, 1);
        }

        public void SetSource(string source, int position)
        {
            _input = source;
            _position = position;
        }

        public override int yylex()
        {
            if (_position >= _input.Length) return (int)Tokens.EOF;

            // Define your regex patterns for each token
            var patterns = new List<(Regex, Tokens)>
            {
                (new Regex(@"^//.*\n"), Tokens.ERROR),         // Consume single-line comments
                (new Regex(@"^[ \t\r\n\f]+"), Tokens.ERROR),  // Consume white space
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
                (new Regex(@"^then\b"), Tokens.THEN),
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
                (new Regex(@"^\,"), Tokens.COMMA),
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
                    
                    // Count new lines to determine if we move to a new line
                    var newLines = match.Value.Split('\n').Length - 1;

                    // If there are new lines, adjust yylloc accordingly
                    if (newLines > 0)
                    {
                        yylloc = new LexLocation(yylloc.EndLine, yylloc.EndColumn, yylloc.EndLine + newLines, match.Value.Length - match.Value.LastIndexOf('\n'));
                    }
                    else
                    {
                        yylloc = new LexLocation(yylloc.EndLine, yylloc.EndColumn, yylloc.EndLine, yylloc.EndColumn + match.Length);
                    }

                    return token == Tokens.ERROR ? yylex() : (int)token;
                }
            }

            throw new Exception("Unreacheble");
        }
    }
}
