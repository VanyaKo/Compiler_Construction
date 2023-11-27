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

        List<ClassDeclaration> oclasses;
        Indentator idnt = new();
        try
        {
            oclasses = analyzer.LinkValidateAndOptimize(parser.Program);
            Console.WriteLine("Program is valid");

            foreach (ClassDeclaration cls in oclasses)
            {
                Console.WriteLine(idnt.Traverse(cls.ToOlua()));
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        // generate il
        using (StreamWriter writer = new StreamWriter("program.il"))
        {
            writer.WriteLine(".assembly extern mscorlib {}");

            // link stdasm
            foreach (string file in Directory.GetFiles("../stdasm"))
            {
                writer.WriteLine(File.ReadAllText(file) + "\n");
            }

            // link user code
            idnt.identator = "    ";
            foreach (ClassDeclaration cls in oclasses)
            {
                writer.WriteLine(idnt.Traverse(cls.ToMsil()));
            }
        }

        // TODO: ilasm program.il /output=program.exe
    }
}

