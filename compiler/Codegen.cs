using System.Text;

namespace Codegen
{
    class OluaCodegenerator
    {
        AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("Output"),
                AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder mod = asm.DefineDynamicModule("Output.exe", "Output.exe");

        // public void Link(List<ClassDeclaration> clss)
        // {
        // TODO: wrap into custom main class with the default msil entry point, pseudocode:
        // class TheVeryMainEntryPoint // NOTE: redefining this name in the user code may produce unexpected behaviour
        // {
        //     void Main()
        //     {
        //         stdin = { create ConsoleStdInAdapter }
        //         stdout = { create ConsoleStdOutAdapter }
        //         stderr = { create ConsoleStdErrorAdapter }
        //         args = { Array([arg.fromStrToIntsArray() for arg in arguments]) }

        //         exec_program = FoundEntryPointClass(stdin, stdout, stderr, args)
        //         return exec_program.exitCode;
        //     }
        // }
        //     // TODO: link stdlib classes
        //     // TODO: create instances of some stdlib classes (stdin/stdout/stderr/program args)
        //     // TODO: find entrypoint
        //     // TODO: pass entrypoint IO parameters (stdin, stdout, stderr)
        //     // TODO: pass entrypoint program arguments
        //     // TODO: handle exit code
        // }
    }
}
