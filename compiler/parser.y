%namespace OluaParser
%using OluaLexer
%using OluaAST;

%union  
{
    public string sVal;
    public int iVal;
    public float fVal;
    public bool bVal;

    public Node Node;
    public TypeName TypeName;
    public AttributeObject AttributeObject;
    public OluaObject Object;
    public OluaObjectList ObjectList;
    public List<ClassDeclaration> ClassDeclarationList;
    public ClassDeclaration ClassDeclaration;
    public List<ClassMember> ClassMemberList;
    public ClassMember ClassMember;
    public ParameterList ParameterList;
    public Parameter Parameter;
    public VariableDeclaration VariableDeclaration;
    public Scope Scope;
    public MethodDeclaration MethodDeclaration;
    public ConstructorDeclaration ConstructorDeclaration;
    public StatementList StatementList;
    public Statement Statement;
    public Assignment Assignment;
    public If If;
    public While While;
    public Return Return;
    public MethodInvocation MethodInvocation;
    public ConstructorInvocation ConstructorInvocation;
}

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
%token VOID
%token END
%token ASSIGN
%token <sVal> IDENTIFIER
%token COLON
%token LPAREN
%token RPAREN
%token LBRACKET
%token RBRACKET
%token DOT
%token <iVal> INTEGER_LITERAL
%token <fVal> FLOAT_LITERAL
%token <bVal> BOOL_LITERAL
%token LOOP
%token COMMA
%token THEN
%token UNDEFINED

%type <TypeName> typename
%type <ConstructorInvocation> constructorInvocation
%type <MethodInvocation> methodInvocation
%type <Object> object
%type <ObjectList> argumentList
%type <AttributeObject> attribute
%type <ClassDeclarationList> classDeclarationList
%type <ClassDeclaration> classDeclaration
%type <ClassMemberList> classMemberList
%type <ClassMember> classMember
%type <Parameter> parameter
%type <ParameterList> parameterList
%type <VariableDeclaration> variableDeclaration
%type <Scope> scope, voidRetScope
%type <MethodDeclaration> methodDeclaration
%type <ConstructorDeclaration> constructorDeclaration
%type <StatementList> statementList, voidRetStatementList
%type <Statement> statement, voidRetStatement
%type <Assignment> assignment
%type <If> if, voidRetIf
%type <While> while, voidRetWhile
%type <Return> return, voidReturn

%start classDeclarationList

%%

typename
    : IDENTIFIER { $$ = new TypeName { Identifier = $1 }; }
    | IDENTIFIER LBRACKET typename RBRACKET { $$ = new TypeName { Identifier = $1, GenericType = $3 }; }
    ;

constructorInvocation
    : typename LPAREN argumentList RPAREN { $$ = new ConstructorInvocation { Type = $1, Arguments = $3 }; }
    ;

methodInvocation
    : attribute LPAREN argumentList RPAREN { $$ = new MethodInvocation { Method = $1, Arguments = $3 }; }
    ;

attribute
    : object DOT IDENTIFIER { $$ = new AttributeObject { Parent = $1, Identifier = $3 }; }
    ;

object
    : IDENTIFIER { $$ = new ObjectIdentifier { Identifier = $1 }; }
    | INTEGER_LITERAL { $$ = new Literal<int> { Value = $1 }; }
    | FLOAT_LITERAL { $$ = new Literal<float> { Value = $1 }; }
    | BOOL_LITERAL { $$ = new Literal<bool> { Value = $1 }; }
    | THIS { $$ = new ThisIdentifier(); }
    | attribute { $$ = $1; }
    | constructorInvocation { $$ = $1; }
    | methodInvocation { $$ = $1; }
    ;

classDeclarationList
    : { Program = new List<ClassDeclaration>(); }
    | classDeclarationList classDeclaration { Program.Add($2); }
    ;

classDeclaration
    : CLASS IDENTIFIER EXTENDS typename IS classMemberList END { $$ = new ClassDeclaration { Name = $2, BaseClass = $4, Members = $6 }; }
    | CLASS IDENTIFIER IS classMemberList END { $$ = new ClassDeclaration { Name = $2, Members = $4 }; }
    ;

classMemberList
    : { $$ = new List<ClassMember>(); }
    | classMemberList classMember { $1.Add($2); $$ = $1; }
    ;

classMember
    : methodDeclaration { $$ = $1; }
    | variableDeclaration { $$ = $1; }
    | constructorDeclaration { $$ = $1; }
    ;

variableDeclaration
    : VAR IDENTIFIER COLON typename ASSIGN object { $$ = new VariableDeclaration { Name = $2, Type = $4, InitialValue = $6 }; }
    ;

methodDeclaration
    : METHOD IDENTIFIER LPAREN parameterList RPAREN COLON typename scope { $$ = new MethodDeclaration { Name = $2, Parameters = $4, ReturnType = $7, Statements = $8.Statements }; }
    | METHOD IDENTIFIER LPAREN parameterList RPAREN COLON VOID voidRetScope { $$ = new MethodDeclaration { Name = $2, Parameters = $4, ReturnType = null, Statements = $8.Statements }; }
    ;

constructorDeclaration
    : THIS LPAREN parameterList RPAREN voidRetScope { $$ = new ConstructorDeclaration { Parameters = $3, Statements = $5.Statements }; }
    ;

scope
    : IS statementList END { $$ = new Scope { Statements = $2 }; }
    ;

voidRetScope
    : IS voidRetStatementList END { $$ = new Scope { Statements = $2 }; }
    ;

statementList
    : { $$ = new StatementList { List = new List<Statement>() }; }
    | statementList statement { $1.List.Add($2); $$ = $1; }
    ;

statement
    : variableDeclaration { $$ = $1; }
    | assignment { $$ = $1; }
    | methodInvocation { $$ = $1; }
    | if { $$ = $1; }
    | while { $$ = $1; }
    | return { $$ = $1; }
    | scope { $$ = $1; }
    ;

voidRetStatementList
    : { $$ = new StatementList { List = new List<Statement>() }; }
    | voidRetStatementList voidRetStatement { $1.List.Add($2); $$ = $1; }
    ;

voidRetStatement
    : variableDeclaration { $$ = $1; }
    | assignment { $$ = $1; }
    | methodInvocation { $$ = $1; }
    | voidRetIf { $$ = $1; }
    | voidRetWhile { $$ = $1; }
    | voidRetScope { $$ = $1; }
    | voidReturn { $$ = $1; }
    ;

assignment
    : IDENTIFIER ASSIGN object { $$ = new Assignment { Variable = new ObjectIdentifier { Identifier = $1 }, Value = $3 }; }
    | attribute ASSIGN object { $$ = new Assignment { Variable = $1, Value = $3 }; }
    ;

if
    : IF object THEN statementList END { $$ = new If { Cond = $2, Then = $4 }; }
    | IF object THEN statementList ELSE statementList END { $$ = new If { Cond = $2, Then = $4, Else = $6 }; }
    ;

voidRetIf
    : IF object THEN voidRetStatementList END { $$ = new If { Cond = $2, Then = $4 }; }
    | IF object THEN voidRetStatementList ELSE voidRetStatementList END { $$ = new If { Cond = $2, Then = $4, Else = $6 }; }
    ;

while
    : WHILE object LOOP statementList END { $$ = new While { Cond = $2, Body = $4 }; }
    ;

voidRetWhile
    : WHILE object LOOP voidRetStatementList END { $$ = new While { Cond = $2, Body = $4 }; }
    ;

return
    : RETURN object { $$ = new Return { Object = $2 }; }
    ;

voidReturn
    : RETURN { $$ = new Return { Object = null }; }
    ;

parameterList
    : { $$ = new ParameterList { List = new List<Parameter>() }; }
    | parameter { ParameterList p = new ParameterList { List = new List<Parameter>() };; p.List.Add($1); $$ = p; }
    | parameterList COMMA parameter { $1.List.Add($3); $$ = $1; }
    ;

parameter
    : IDENTIFIER COLON typename { $$ = new Parameter { Name = $1, Type = $3 }; }
    ;

argumentList
    : { $$ = new OluaObjectList { List = new List<OluaObject>() }; }
    | object { OluaObjectList l = new OluaObjectList { List = new List<OluaObject>() }; l.List.Add($1); $$ = l; }
    | argumentList COMMA object { $1.List.Add($3); $$ = $1; }
    ;

%%

public Parser(Scanner scnr) : base(scnr) { }
public List<ClassDeclaration> Program;
