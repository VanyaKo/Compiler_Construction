using OluaAST;
using OluaLexer;
using OluaParser;
using OluaSemanticAnalyzer;
using OluaStdLibInterfaces;
using Indent;


public class Application
{
    const string target = "program.olua";
    public static void Main()
    {
        Scanner scanner = new(File.ReadAllText(target));

        Parser parser = new(scanner);
        bool success = parser.Parse();

        if (!success)
        {
            Console.WriteLine($"Syntax error at {Path.GetFullPath(target)}({scanner.yylloc.StartLine},{scanner.yylloc.StartColumn})");
            return;
        }

        Analyzer analyzer = new();

        // link stdlib classes
        {
            List<ExtendableClassInterface> stdlibClasses = new List<ExtendableClassInterface>
            {
                new IntegerInterface(),
                new BooleanInterface(),
                new RealInterface(),
                new CharInputInterface(),
                new CharOutputInterface(),
                new StdInInterface(),
                new StdOutInterface(),
            };

            foreach (var cls in stdlibClasses)
                analyzer.LinkClass(cls.Name, cls.Inf);
        }

        // link the only stdlib generic class - Array
        analyzer.LinkGeneric("Array", new ArrayGeneric());

        try
        {
            var oclasses = analyzer.LinkValidateAndOptimize(parser.Program);
            Console.WriteLine("Program is valid");

            Indentator idnt = new();
            foreach (ClassDeclaration cls in oclasses)
            {
                Console.WriteLine(idnt.Traverse(cls.ToStrings()));
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        // generate code
        OluaCodegenerator codegen = new OluaCodegenerator();

        // TODO: first link stdlib classes
        // smth like
        // t = ArrayImpl.defineType(codegen.mod, codegen.typeTable)
        // ArrayImpl.impl(t, codegen.typeTable)

        codegen.Generate(oclasses);
    }
}

