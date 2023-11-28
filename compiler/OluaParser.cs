// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.2.1.0
// Machine:  PC
// DateTime: 28.11.2023 8:35:41
// Input file <parser.y - 27.11.2023 7:12:33>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using StarodubOleg.GPPG.Runtime;
using OluaLexer;
using OluaAST;

namespace OluaParser
{
public enum Tokens {error=2,EOF=3,CLASS=4,EXTENDS=5,IS=6,
    METHOD=7,VAR=8,IF=9,ELSE=10,WHILE=11,RETURN=12,
    THIS=13,VOID=14,END=15,ASSIGN=16,IDENTIFIER=17,COLON=18,
    LPAREN=19,RPAREN=20,LBRACKET=21,RBRACKET=22,DOT=23,INTEGER_LITERAL=24,
    FLOAT_LITERAL=25,BOOL_LITERAL=26,LOOP=27,COMMA=28,THEN=29,UNDEFINED=30};

public struct ValueType
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
    public StatementList StatementList;
    public Statement Statement;
    public Assignment Assignment;
    public If If;
    public While While;
    public Return Return;
    public MethodInvocation MethodInvocation;
    public ConstructorInvocation ConstructorInvocation;
}
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.2.1.0")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.2.1.0")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.2.1.0")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[63];
  private static State[] states = new State[121];
  private static string[] nonTerms = new string[] {
      "typename", "constructorInvocation", "methodInvocation", "object", "argumentList", 
      "attribute", "classDeclarationList", "classDeclaration", "classMemberList", 
      "classMember", "parameter", "parameterList", "variableDeclaration", "scope", 
      "voidRetScope", "methodDeclaration", "statementList", "voidRetStatementList", 
      "statement", "voidRetStatement", "assignment", "if", "voidRetIf", "while", 
      "voidRetWhile", "return", "voidReturn", "$accept", };

  static Parser() {
    states[0] = new State(-15,new int[]{-7,1});
    states[1] = new State(new int[]{3,2,4,4},new int[]{-8,3});
    states[2] = new State(-1);
    states[3] = new State(-16);
    states[4] = new State(new int[]{17,5});
    states[5] = new State(new int[]{5,6,6,118});
    states[6] = new State(new int[]{17,38},new int[]{-1,7});
    states[7] = new State(new int[]{6,8});
    states[8] = new State(-19,new int[]{-9,9});
    states[9] = new State(new int[]{15,10,7,13,8,26},new int[]{-10,11,-16,12,-13,117});
    states[10] = new State(-17);
    states[11] = new State(-20);
    states[12] = new State(-21);
    states[13] = new State(new int[]{17,14});
    states[14] = new State(new int[]{19,15});
    states[15] = new State(new int[]{17,113,20,-56,28,-56},new int[]{-12,16,-11,116});
    states[16] = new State(new int[]{20,17,28,111});
    states[17] = new State(new int[]{18,18});
    states[18] = new State(new int[]{14,84,17,38},new int[]{-1,19});
    states[19] = new State(new int[]{6,21},new int[]{-14,20});
    states[20] = new State(-24);
    states[21] = new State(-28,new int[]{-17,22});
    states[22] = new State(new int[]{15,23,8,26,17,57,24,39,25,40,26,41,13,42,9,66,11,75,12,81,6,21},new int[]{-19,24,-13,25,-21,56,-6,60,-4,63,-2,49,-1,50,-3,64,-22,65,-24,74,-26,80,-14,83});
    states[23] = new State(-26);
    states[24] = new State(-29);
    states[25] = new State(-30);
    states[26] = new State(new int[]{17,27});
    states[27] = new State(new int[]{18,28});
    states[28] = new State(new int[]{17,38},new int[]{-1,29});
    states[29] = new State(new int[]{16,30});
    states[30] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,31,-6,43,-2,49,-1,50,-3,55});
    states[31] = new State(new int[]{23,32,15,-23,7,-23,8,-23,17,-23,24,-23,25,-23,26,-23,13,-23,9,-23,11,-23,12,-23,6,-23,10,-23});
    states[32] = new State(new int[]{17,33});
    states[33] = new State(-6);
    states[34] = new State(new int[]{21,35,23,-7,15,-7,7,-7,8,-7,17,-7,24,-7,25,-7,26,-7,13,-7,9,-7,11,-7,12,-7,6,-7,10,-7,20,-7,28,-7,29,-7,27,-7,19,-2});
    states[35] = new State(new int[]{17,38},new int[]{-1,36});
    states[36] = new State(new int[]{22,37});
    states[37] = new State(-3);
    states[38] = new State(new int[]{21,35,6,-2,16,-2,22,-2,20,-2,28,-2});
    states[39] = new State(-8);
    states[40] = new State(-9);
    states[41] = new State(-10);
    states[42] = new State(-11);
    states[43] = new State(new int[]{19,44,23,-12,15,-12,7,-12,8,-12,17,-12,24,-12,25,-12,26,-12,13,-12,9,-12,11,-12,12,-12,6,-12,10,-12,20,-12,28,-12,29,-12,27,-12});
    states[44] = new State(new int[]{17,34,24,39,25,40,26,41,13,42,20,-60,28,-60},new int[]{-5,45,-4,54,-6,43,-2,49,-1,50,-3,55});
    states[45] = new State(new int[]{20,46,28,47});
    states[46] = new State(-5);
    states[47] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,48,-6,43,-2,49,-1,50,-3,55});
    states[48] = new State(new int[]{23,32,20,-62,28,-62});
    states[49] = new State(-13);
    states[50] = new State(new int[]{19,51});
    states[51] = new State(new int[]{17,34,24,39,25,40,26,41,13,42,20,-60,28,-60},new int[]{-5,52,-4,54,-6,43,-2,49,-1,50,-3,55});
    states[52] = new State(new int[]{20,53,28,47});
    states[53] = new State(-4);
    states[54] = new State(new int[]{23,32,20,-61,28,-61});
    states[55] = new State(-14);
    states[56] = new State(-31);
    states[57] = new State(new int[]{16,58,21,35,23,-7,19,-2});
    states[58] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,59,-6,43,-2,49,-1,50,-3,55});
    states[59] = new State(new int[]{23,32,15,-46,8,-46,17,-46,24,-46,25,-46,26,-46,13,-46,9,-46,11,-46,12,-46,6,-46,10,-46});
    states[60] = new State(new int[]{16,61,19,44,23,-12});
    states[61] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,62,-6,43,-2,49,-1,50,-3,55});
    states[62] = new State(new int[]{23,32,15,-47,8,-47,17,-47,24,-47,25,-47,26,-47,13,-47,9,-47,11,-47,12,-47,6,-47,10,-47});
    states[63] = new State(new int[]{23,32});
    states[64] = new State(new int[]{23,-14,15,-32,8,-32,17,-32,24,-32,25,-32,26,-32,13,-32,9,-32,11,-32,12,-32,6,-32,10,-32});
    states[65] = new State(-33);
    states[66] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,67,-6,43,-2,49,-1,50,-3,55});
    states[67] = new State(new int[]{29,68,23,32});
    states[68] = new State(-28,new int[]{-17,69});
    states[69] = new State(new int[]{15,70,10,71,8,26,17,57,24,39,25,40,26,41,13,42,9,66,11,75,12,81,6,21},new int[]{-19,24,-13,25,-21,56,-6,60,-4,63,-2,49,-1,50,-3,64,-22,65,-24,74,-26,80,-14,83});
    states[70] = new State(-48);
    states[71] = new State(-28,new int[]{-17,72});
    states[72] = new State(new int[]{15,73,8,26,17,57,24,39,25,40,26,41,13,42,9,66,11,75,12,81,6,21},new int[]{-19,24,-13,25,-21,56,-6,60,-4,63,-2,49,-1,50,-3,64,-22,65,-24,74,-26,80,-14,83});
    states[73] = new State(-49);
    states[74] = new State(-34);
    states[75] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,76,-6,43,-2,49,-1,50,-3,55});
    states[76] = new State(new int[]{27,77,23,32});
    states[77] = new State(-28,new int[]{-17,78});
    states[78] = new State(new int[]{15,79,8,26,17,57,24,39,25,40,26,41,13,42,9,66,11,75,12,81,6,21},new int[]{-19,24,-13,25,-21,56,-6,60,-4,63,-2,49,-1,50,-3,64,-22,65,-24,74,-26,80,-14,83});
    states[79] = new State(-52);
    states[80] = new State(-35);
    states[81] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,82,-6,43,-2,49,-1,50,-3,55});
    states[82] = new State(new int[]{23,32,15,-54,8,-54,17,-54,24,-54,25,-54,26,-54,13,-54,9,-54,11,-54,12,-54,6,-54,10,-54});
    states[83] = new State(-36);
    states[84] = new State(new int[]{6,86},new int[]{-15,85});
    states[85] = new State(-25);
    states[86] = new State(-37,new int[]{-18,87});
    states[87] = new State(new int[]{15,88,8,26,17,57,24,39,25,40,26,41,13,42,9,94,11,103,6,86,12,110},new int[]{-20,89,-13,90,-21,91,-6,60,-4,63,-2,49,-1,50,-3,92,-23,93,-25,102,-15,108,-27,109});
    states[88] = new State(-27);
    states[89] = new State(-38);
    states[90] = new State(-39);
    states[91] = new State(-40);
    states[92] = new State(new int[]{23,-14,15,-41,8,-41,17,-41,24,-41,25,-41,26,-41,13,-41,9,-41,11,-41,6,-41,12,-41,10,-41});
    states[93] = new State(-42);
    states[94] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,95,-6,43,-2,49,-1,50,-3,55});
    states[95] = new State(new int[]{29,96,23,32});
    states[96] = new State(-37,new int[]{-18,97});
    states[97] = new State(new int[]{15,98,10,99,8,26,17,57,24,39,25,40,26,41,13,42,9,94,11,103,6,86,12,110},new int[]{-20,89,-13,90,-21,91,-6,60,-4,63,-2,49,-1,50,-3,92,-23,93,-25,102,-15,108,-27,109});
    states[98] = new State(-50);
    states[99] = new State(-37,new int[]{-18,100});
    states[100] = new State(new int[]{15,101,8,26,17,57,24,39,25,40,26,41,13,42,9,94,11,103,6,86,12,110},new int[]{-20,89,-13,90,-21,91,-6,60,-4,63,-2,49,-1,50,-3,92,-23,93,-25,102,-15,108,-27,109});
    states[101] = new State(-51);
    states[102] = new State(-43);
    states[103] = new State(new int[]{17,34,24,39,25,40,26,41,13,42},new int[]{-4,104,-6,43,-2,49,-1,50,-3,55});
    states[104] = new State(new int[]{27,105,23,32});
    states[105] = new State(-37,new int[]{-18,106});
    states[106] = new State(new int[]{15,107,8,26,17,57,24,39,25,40,26,41,13,42,9,94,11,103,6,86,12,110},new int[]{-20,89,-13,90,-21,91,-6,60,-4,63,-2,49,-1,50,-3,92,-23,93,-25,102,-15,108,-27,109});
    states[107] = new State(-53);
    states[108] = new State(-44);
    states[109] = new State(-45);
    states[110] = new State(-55);
    states[111] = new State(new int[]{17,113},new int[]{-11,112});
    states[112] = new State(-58);
    states[113] = new State(new int[]{18,114});
    states[114] = new State(new int[]{17,38},new int[]{-1,115});
    states[115] = new State(-59);
    states[116] = new State(-57);
    states[117] = new State(-22);
    states[118] = new State(-19,new int[]{-9,119});
    states[119] = new State(new int[]{15,120,7,13,8,26},new int[]{-10,11,-16,12,-13,117});
    states[120] = new State(-18);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-28, new int[]{-7,3});
    rules[2] = new Rule(-1, new int[]{17});
    rules[3] = new Rule(-1, new int[]{17,21,-1,22});
    rules[4] = new Rule(-2, new int[]{-1,19,-5,20});
    rules[5] = new Rule(-3, new int[]{-6,19,-5,20});
    rules[6] = new Rule(-6, new int[]{-4,23,17});
    rules[7] = new Rule(-4, new int[]{17});
    rules[8] = new Rule(-4, new int[]{24});
    rules[9] = new Rule(-4, new int[]{25});
    rules[10] = new Rule(-4, new int[]{26});
    rules[11] = new Rule(-4, new int[]{13});
    rules[12] = new Rule(-4, new int[]{-6});
    rules[13] = new Rule(-4, new int[]{-2});
    rules[14] = new Rule(-4, new int[]{-3});
    rules[15] = new Rule(-7, new int[]{});
    rules[16] = new Rule(-7, new int[]{-7,-8});
    rules[17] = new Rule(-8, new int[]{4,17,5,-1,6,-9,15});
    rules[18] = new Rule(-8, new int[]{4,17,6,-9,15});
    rules[19] = new Rule(-9, new int[]{});
    rules[20] = new Rule(-9, new int[]{-9,-10});
    rules[21] = new Rule(-10, new int[]{-16});
    rules[22] = new Rule(-10, new int[]{-13});
    rules[23] = new Rule(-13, new int[]{8,17,18,-1,16,-4});
    rules[24] = new Rule(-16, new int[]{7,17,19,-12,20,18,-1,-14});
    rules[25] = new Rule(-16, new int[]{7,17,19,-12,20,18,14,-15});
    rules[26] = new Rule(-14, new int[]{6,-17,15});
    rules[27] = new Rule(-15, new int[]{6,-18,15});
    rules[28] = new Rule(-17, new int[]{});
    rules[29] = new Rule(-17, new int[]{-17,-19});
    rules[30] = new Rule(-19, new int[]{-13});
    rules[31] = new Rule(-19, new int[]{-21});
    rules[32] = new Rule(-19, new int[]{-3});
    rules[33] = new Rule(-19, new int[]{-22});
    rules[34] = new Rule(-19, new int[]{-24});
    rules[35] = new Rule(-19, new int[]{-26});
    rules[36] = new Rule(-19, new int[]{-14});
    rules[37] = new Rule(-18, new int[]{});
    rules[38] = new Rule(-18, new int[]{-18,-20});
    rules[39] = new Rule(-20, new int[]{-13});
    rules[40] = new Rule(-20, new int[]{-21});
    rules[41] = new Rule(-20, new int[]{-3});
    rules[42] = new Rule(-20, new int[]{-23});
    rules[43] = new Rule(-20, new int[]{-25});
    rules[44] = new Rule(-20, new int[]{-15});
    rules[45] = new Rule(-20, new int[]{-27});
    rules[46] = new Rule(-21, new int[]{17,16,-4});
    rules[47] = new Rule(-21, new int[]{-6,16,-4});
    rules[48] = new Rule(-22, new int[]{9,-4,29,-17,15});
    rules[49] = new Rule(-22, new int[]{9,-4,29,-17,10,-17,15});
    rules[50] = new Rule(-23, new int[]{9,-4,29,-18,15});
    rules[51] = new Rule(-23, new int[]{9,-4,29,-18,10,-18,15});
    rules[52] = new Rule(-24, new int[]{11,-4,27,-17,15});
    rules[53] = new Rule(-25, new int[]{11,-4,27,-18,15});
    rules[54] = new Rule(-26, new int[]{12,-4});
    rules[55] = new Rule(-27, new int[]{12});
    rules[56] = new Rule(-12, new int[]{});
    rules[57] = new Rule(-12, new int[]{-11});
    rules[58] = new Rule(-12, new int[]{-12,28,-11});
    rules[59] = new Rule(-11, new int[]{17,18,-1});
    rules[60] = new Rule(-5, new int[]{});
    rules[61] = new Rule(-5, new int[]{-4});
    rules[62] = new Rule(-5, new int[]{-5,28,-4});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // typename -> IDENTIFIER
{ CurrentSemanticValue.TypeName = new TypeName { Identifier = ValueStack[ValueStack.Depth-1].sVal }; }
        break;
      case 3: // typename -> IDENTIFIER, LBRACKET, typename, RBRACKET
{ CurrentSemanticValue.TypeName = new TypeName { Identifier = ValueStack[ValueStack.Depth-4].sVal, GenericType = ValueStack[ValueStack.Depth-2].TypeName }; }
        break;
      case 4: // constructorInvocation -> typename, LPAREN, argumentList, RPAREN
{ CurrentSemanticValue.ConstructorInvocation = new ConstructorInvocation { Type = ValueStack[ValueStack.Depth-4].TypeName, Arguments = ValueStack[ValueStack.Depth-2].ObjectList }; }
        break;
      case 5: // methodInvocation -> attribute, LPAREN, argumentList, RPAREN
{ CurrentSemanticValue.MethodInvocation = new MethodInvocation { Method = ValueStack[ValueStack.Depth-4].AttributeObject, Arguments = ValueStack[ValueStack.Depth-2].ObjectList }; }
        break;
      case 6: // attribute -> object, DOT, IDENTIFIER
{ CurrentSemanticValue.AttributeObject = new AttributeObject { Parent = ValueStack[ValueStack.Depth-3].Object, Identifier = ValueStack[ValueStack.Depth-1].sVal }; }
        break;
      case 7: // object -> IDENTIFIER
{ CurrentSemanticValue.Object = new ObjectIdentifier { Identifier = ValueStack[ValueStack.Depth-1].sVal }; }
        break;
      case 8: // object -> INTEGER_LITERAL
{ CurrentSemanticValue.Object = new Literal<int> { Value = ValueStack[ValueStack.Depth-1].iVal }; }
        break;
      case 9: // object -> FLOAT_LITERAL
{ CurrentSemanticValue.Object = new Literal<float> { Value = ValueStack[ValueStack.Depth-1].fVal }; }
        break;
      case 10: // object -> BOOL_LITERAL
{ CurrentSemanticValue.Object = new Literal<bool> { Value = ValueStack[ValueStack.Depth-1].bVal }; }
        break;
      case 11: // object -> THIS
{ CurrentSemanticValue.Object = new ThisIdentifier(); }
        break;
      case 12: // object -> attribute
{ CurrentSemanticValue.Object = ValueStack[ValueStack.Depth-1].AttributeObject; }
        break;
      case 13: // object -> constructorInvocation
{ CurrentSemanticValue.Object = ValueStack[ValueStack.Depth-1].ConstructorInvocation; }
        break;
      case 14: // object -> methodInvocation
{ CurrentSemanticValue.Object = ValueStack[ValueStack.Depth-1].MethodInvocation; }
        break;
      case 15: // classDeclarationList -> /* empty */
{ Program = new List<ClassDeclaration>(); }
        break;
      case 16: // classDeclarationList -> classDeclarationList, classDeclaration
{ Program.Add(ValueStack[ValueStack.Depth-1].ClassDeclaration); }
        break;
      case 17: // classDeclaration -> CLASS, IDENTIFIER, EXTENDS, typename, IS, classMemberList, 
               //                     END
{ CurrentSemanticValue.ClassDeclaration = new ClassDeclaration { Name = ValueStack[ValueStack.Depth-6].sVal, BaseClass = ValueStack[ValueStack.Depth-4].TypeName, Members = ValueStack[ValueStack.Depth-2].ClassMemberList }; }
        break;
      case 18: // classDeclaration -> CLASS, IDENTIFIER, IS, classMemberList, END
{ CurrentSemanticValue.ClassDeclaration = new ClassDeclaration { Name = ValueStack[ValueStack.Depth-4].sVal, Members = ValueStack[ValueStack.Depth-2].ClassMemberList }; }
        break;
      case 19: // classMemberList -> /* empty */
{ CurrentSemanticValue.ClassMemberList = new List<ClassMember>(); }
        break;
      case 20: // classMemberList -> classMemberList, classMember
{ ValueStack[ValueStack.Depth-2].ClassMemberList.Add(ValueStack[ValueStack.Depth-1].ClassMember); CurrentSemanticValue.ClassMemberList = ValueStack[ValueStack.Depth-2].ClassMemberList; }
        break;
      case 21: // classMember -> methodDeclaration
{ CurrentSemanticValue.ClassMember = ValueStack[ValueStack.Depth-1].MethodDeclaration; }
        break;
      case 22: // classMember -> variableDeclaration
{ CurrentSemanticValue.ClassMember = ValueStack[ValueStack.Depth-1].VariableDeclaration; }
        break;
      case 23: // variableDeclaration -> VAR, IDENTIFIER, COLON, typename, ASSIGN, object
{ CurrentSemanticValue.VariableDeclaration = new VariableDeclaration { Name = ValueStack[ValueStack.Depth-5].sVal, Type = ValueStack[ValueStack.Depth-3].TypeName, InitialValue = ValueStack[ValueStack.Depth-1].Object }; }
        break;
      case 24: // methodDeclaration -> METHOD, IDENTIFIER, LPAREN, parameterList, RPAREN, COLON, 
               //                      typename, scope
{ CurrentSemanticValue.MethodDeclaration = new MethodDeclaration { Name = ValueStack[ValueStack.Depth-7].sVal, Parameters = ValueStack[ValueStack.Depth-5].ParameterList, ReturnType = ValueStack[ValueStack.Depth-2].TypeName, Statements = ValueStack[ValueStack.Depth-1].Scope.Statements }; }
        break;
      case 25: // methodDeclaration -> METHOD, IDENTIFIER, LPAREN, parameterList, RPAREN, COLON, 
               //                      VOID, voidRetScope
{ CurrentSemanticValue.MethodDeclaration = new MethodDeclaration { Name = ValueStack[ValueStack.Depth-7].sVal, Parameters = ValueStack[ValueStack.Depth-5].ParameterList, ReturnType = null, Statements = ValueStack[ValueStack.Depth-1].Scope.Statements }; }
        break;
      case 26: // scope -> IS, statementList, END
{ CurrentSemanticValue.Scope = new Scope { Statements = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 27: // voidRetScope -> IS, voidRetStatementList, END
{ CurrentSemanticValue.Scope = new Scope { Statements = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 28: // statementList -> /* empty */
{ CurrentSemanticValue.StatementList = new StatementList { List = new List<Statement>() }; }
        break;
      case 29: // statementList -> statementList, statement
{ ValueStack[ValueStack.Depth-2].StatementList.List.Add(ValueStack[ValueStack.Depth-1].Statement); CurrentSemanticValue.StatementList = ValueStack[ValueStack.Depth-2].StatementList; }
        break;
      case 30: // statement -> variableDeclaration
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].VariableDeclaration; }
        break;
      case 31: // statement -> assignment
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Assignment; }
        break;
      case 32: // statement -> methodInvocation
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].MethodInvocation; }
        break;
      case 33: // statement -> if
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].If; }
        break;
      case 34: // statement -> while
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].While; }
        break;
      case 35: // statement -> return
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Return; }
        break;
      case 36: // statement -> scope
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Scope; }
        break;
      case 37: // voidRetStatementList -> /* empty */
{ CurrentSemanticValue.StatementList = new StatementList { List = new List<Statement>() }; }
        break;
      case 38: // voidRetStatementList -> voidRetStatementList, voidRetStatement
{ ValueStack[ValueStack.Depth-2].StatementList.List.Add(ValueStack[ValueStack.Depth-1].Statement); CurrentSemanticValue.StatementList = ValueStack[ValueStack.Depth-2].StatementList; }
        break;
      case 39: // voidRetStatement -> variableDeclaration
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].VariableDeclaration; }
        break;
      case 40: // voidRetStatement -> assignment
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Assignment; }
        break;
      case 41: // voidRetStatement -> methodInvocation
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].MethodInvocation; }
        break;
      case 42: // voidRetStatement -> voidRetIf
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].If; }
        break;
      case 43: // voidRetStatement -> voidRetWhile
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].While; }
        break;
      case 44: // voidRetStatement -> voidRetScope
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Scope; }
        break;
      case 45: // voidRetStatement -> voidReturn
{ CurrentSemanticValue.Statement = ValueStack[ValueStack.Depth-1].Return; }
        break;
      case 46: // assignment -> IDENTIFIER, ASSIGN, object
{ CurrentSemanticValue.Assignment = new Assignment { Variable = new ObjectIdentifier { Identifier = ValueStack[ValueStack.Depth-3].sVal }, Value = ValueStack[ValueStack.Depth-1].Object }; }
        break;
      case 47: // assignment -> attribute, ASSIGN, object
{ CurrentSemanticValue.Assignment = new Assignment { Variable = ValueStack[ValueStack.Depth-3].AttributeObject, Value = ValueStack[ValueStack.Depth-1].Object }; }
        break;
      case 48: // if -> IF, object, THEN, statementList, END
{ CurrentSemanticValue.If = new If { Cond = ValueStack[ValueStack.Depth-4].Object, Then = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 49: // if -> IF, object, THEN, statementList, ELSE, statementList, END
{ CurrentSemanticValue.If = new If { Cond = ValueStack[ValueStack.Depth-6].Object, Then = ValueStack[ValueStack.Depth-4].StatementList, Else = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 50: // voidRetIf -> IF, object, THEN, voidRetStatementList, END
{ CurrentSemanticValue.If = new If { Cond = ValueStack[ValueStack.Depth-4].Object, Then = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 51: // voidRetIf -> IF, object, THEN, voidRetStatementList, ELSE, voidRetStatementList, 
               //              END
{ CurrentSemanticValue.If = new If { Cond = ValueStack[ValueStack.Depth-6].Object, Then = ValueStack[ValueStack.Depth-4].StatementList, Else = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 52: // while -> WHILE, object, LOOP, statementList, END
{ CurrentSemanticValue.While = new While { Cond = ValueStack[ValueStack.Depth-4].Object, Body = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 53: // voidRetWhile -> WHILE, object, LOOP, voidRetStatementList, END
{ CurrentSemanticValue.While = new While { Cond = ValueStack[ValueStack.Depth-4].Object, Body = ValueStack[ValueStack.Depth-2].StatementList }; }
        break;
      case 54: // return -> RETURN, object
{ CurrentSemanticValue.Return = new Return { Object = ValueStack[ValueStack.Depth-1].Object }; }
        break;
      case 55: // voidReturn -> RETURN
{ CurrentSemanticValue.Return = new Return { Object = null }; }
        break;
      case 56: // parameterList -> /* empty */
{ CurrentSemanticValue.ParameterList = new ParameterList { List = new List<Parameter>() }; }
        break;
      case 57: // parameterList -> parameter
{ ParameterList p = new ParameterList { List = new List<Parameter>() };; p.List.Add(ValueStack[ValueStack.Depth-1].Parameter); CurrentSemanticValue.ParameterList = p; }
        break;
      case 58: // parameterList -> parameterList, COMMA, parameter
{ ValueStack[ValueStack.Depth-3].ParameterList.List.Add(ValueStack[ValueStack.Depth-1].Parameter); CurrentSemanticValue.ParameterList = ValueStack[ValueStack.Depth-3].ParameterList; }
        break;
      case 59: // parameter -> IDENTIFIER, COLON, typename
{ CurrentSemanticValue.Parameter = new Parameter { Name = ValueStack[ValueStack.Depth-3].sVal, Type = ValueStack[ValueStack.Depth-1].TypeName }; }
        break;
      case 60: // argumentList -> /* empty */
{ CurrentSemanticValue.ObjectList = new OluaObjectList { List = new List<OluaObject>() }; }
        break;
      case 61: // argumentList -> object
{ OluaObjectList l = new OluaObjectList { List = new List<OluaObject>() }; l.List.Add(ValueStack[ValueStack.Depth-1].Object); CurrentSemanticValue.ObjectList = l; }
        break;
      case 62: // argumentList -> argumentList, COMMA, object
{ ValueStack[ValueStack.Depth-3].ObjectList.List.Add(ValueStack[ValueStack.Depth-1].Object); CurrentSemanticValue.ObjectList = ValueStack[ValueStack.Depth-3].ObjectList; }
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }


public Parser(Scanner scnr) : base(scnr) { }
public List<ClassDeclaration> Program;
}
}
