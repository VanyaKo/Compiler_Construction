%namespace OluaLexer
%option summary, noparser

%%

// Whitespace & Comments
[ \t\r\n\f]+                  { /* Consume whitespace */ }
"//".*                        { /* Consume single-line comments */ }

// Keywords
"class"                       { return (int)Tokens.CLASS; }
"extends"                     { return (int)Tokens.EXTENDS; }
"is"                          { return (int)Tokens.IS; }
"method"                      { return (int)Tokens.METHOD; }
"var"                         { return (int)Tokens.VAR; }
"if"                          { return (int)Tokens.IF; }
"else"                        { return (int)Tokens.ELSE; }
"while"                       { return (int)Tokens.WHILE; }
"return"                      { return (int)Tokens.RETURN; }
"this"                        { return (int)Tokens.THIS; }
"end"                         { return (int)Tokens.END; }
"loop"                        { return (int)Tokens.LOOP; }
"true"                        { return (int)Tokens.TRUE; }
"false"                       { return (int)Tokens.FALSE; }

// Operators and Delimiters
":="                          { return (int)Tokens.ASSIGN; }
":"                           { return (int)Tokens.COLON; }
";"                           { return (int)Tokens.SEMICOLON; }
"("                           { return (int)Tokens.LPAREN; }
")"                           { return (int)Tokens.RPAREN; }
"["                           { return (int)Tokens.LBRACKET; }
"]"                           { return (int)Tokens.RBRACKET; }
"."                           { return (int)Tokens.DOT; }

// Literals and Identifiers
[0-9]*"."[0-9]+([eE][+-]?[0-9]+)? { return (int)Tokens.FLOAT_LITERAL; }
[0-9]+                        { return (int)Tokens.INTEGER_LITERAL; }
[A-Za-z_][A-Za-z_0-9]*        { return (int)Tokens.IDENTIFIER; }

// Catch all for any other character
.                             { return (int)Tokens.ERROR; }

%%

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
