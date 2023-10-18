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
%token VOID
%token COMMA
%token THEN
%token UNDEFINED

%right ASSIGN

%start program

%%

typename
    : IDENTIFIER
    | generic
    ;

generic
    : IDENTIFIER LBRACKET typename RBRACKET
    ;

constructorInvocation
    : typename LPAREN RPAREN
    | typename LPAREN argumentList RPAREN
    ;

methodInvocation
    : attribute LPAREN argumentList RPAREN
    | attribute LPAREN RPAREN
    ;

attribute
    : object DOT IDENTIFIER
    ;

object
    : IDENTIFIER
    | INTEGER_LITERAL
    | FLOAT_LITERAL
    | TRUE
    | FALSE
    | THIS
    | attribute
    | constructorInvocation
    | methodInvocation
    ;

program
    : 
    | classDeclaration program
    ;

classDeclaration
    : CLASS IDENTIFIER EXTENDS typename IS classBody END
    | CLASS IDENTIFIER IS classBody END
    ;

classBody
    : 
    | classMember classBody
    ;

classMember
    : methodDeclaration
    | variableDeclaration
    | constructorDeclaration
    ;

variableDeclaration
    : VAR IDENTIFIER COLON typename ASSIGN object
    ;

methodDeclaration
    : METHOD IDENTIFIER LPAREN parameterList RPAREN COLON typename scope
    | METHOD IDENTIFIER LPAREN RPAREN COLON typename scope
    | METHOD IDENTIFIER LPAREN parameterList RPAREN COLON VOID noReturnScope
    | METHOD IDENTIFIER LPAREN RPAREN COLON VOID noReturnScope
    ;

constructorDeclaration
    : THIS LPAREN parameterList RPAREN noReturnScope
    ;

scope
    : IS statementList END
    ;

statementList
    : 
    | statement statementList
    ;

statement
    : variableDeclaration
    | assignment
    | methodInvocation
    | if
    | while
    | return
    | scope
    ;

noReturnScope
    : IS noReturnStatementList END
    ;

noReturnStatementList
    : 
    | noReturnStatement noReturnStatementList
    ;

noReturnStatement
    : variableDeclaration
    | assignment
    | methodInvocation
    | noReturnIf
    | noReturnWhile
    | noReturnScope
    ;

assignment
    : IDENTIFIER ASSIGN object
    | attribute ASSIGN object
    ;

if
    : IF object THEN statementList END
    | IF object THEN statementList ELSE statementList END
    ;

noReturnIf
    : IF object THEN noReturnStatementList END
    | IF object THEN noReturnStatementList ELSE noReturnStatementList END
    ;

while
    : WHILE object LOOP noReturnStatementList END
    ;

noReturnWhile
    : WHILE object LOOP noReturnStatementList END
    ;

return
    : RETURN object
    ;

parameterList
    : parameter
    | parameter COMMA parameterList
    ;

parameter
    : IDENTIFIER COLON typename
    ;

argumentList
    : object
    | object COMMA argumentList
    ;

%%

public Parser(Scanner scnr) : base(scnr) { }

