%namespace OluaParser
%using OluaLexer

//%union {
//    public string Identifier;
//}

//%token <Identifier> IDENTIFIER
%token EOF
%token CLASS
%token EXTENDS
%token IS
%token METHOD
%token VAR
%token IF
%token ELSE
%token WHILE
%token RETURN
%token THIS
%token END
%token ASSIGN
%token IDENTIFIER
%token COLON
%token SEMICOLON
%token LPAREN
%token RPAREN
%token LBRACKET
%token RBRACKET
%token DOT
%token INTEGER_LITERAL
%token FLOAT_LITERAL
%token LOOP
%token TRUE
%token FALSE
%token COMMA
%token THEN

%right ASSIGN

%start program

%%

program
    : 
    | program classDeclaration
    ;

classDeclaration
    : CLASS IDENTIFIER EXTENDS IDENTIFIER IS classBody END
    | CLASS IDENTIFIER IS classBody END
    ;

classBody
    : 
    | classBody classMember
    ;

classMember
    : methodDeclaration
    | variableDeclaration
    | constructor
    ;

variableDeclaration
    : VAR IDENTIFIER COLON IDENTIFIER ASSIGN expression SEMICOLON
    | VAR IDENTIFIER COLON IDENTIFIER SEMICOLON
    ;

methodDeclaration
    : METHOD IDENTIFIER LPAREN formalParameterList RPAREN COLON IDENTIFIER IS methodBody END
    | METHOD IDENTIFIER LPAREN RPAREN COLON IDENTIFIER IS methodBody END
    ;

constructor
    : THIS LPAREN formalParameterList RPAREN IS methodBody END
    ;

methodBody
    : statementList
    ;

statementList
    : 
    | statementList statement
    ;

statement
    : variableDeclaration
    | assignmentStatement
    | methodCall
    | ifStatement
    | whileStatement
    | returnStatement
    | block
    ;

block
    : IS statementList END
    ;

assignmentStatement
    : IDENTIFIER ASSIGN expression SEMICOLON
    ;

methodCall
    : expression DOT IDENTIFIER LPAREN argumentList RPAREN SEMICOLON
    | expression DOT IDENTIFIER LPAREN RPAREN SEMICOLON
    ;

ifStatement
    : IF expression THEN statementList END
    | IF expression THEN statementList ELSE statementList END
    ;

whileStatement
    : WHILE expression LOOP statementList END
    ;

returnStatement
    : RETURN expression SEMICOLON
    ;

expression
    : IDENTIFIER
    | INTEGER_LITERAL
    | FLOAT_LITERAL
    | TRUE
    | FALSE
    | THIS
    | expression DOT IDENTIFIER
    | expression DOT IDENTIFIER LPAREN argumentList RPAREN
    | expression DOT IDENTIFIER LPAREN RPAREN
    ;

formalParameterList
    : formalParameter
    | formalParameterList COMMA formalParameter
    ;

formalParameter
    : IDENTIFIER COLON IDENTIFIER
    ;

argumentList
    : expression
    | argumentList COMMA expression
    ;

%%

public Parser(Scanner scnr) : base(scnr) { }

