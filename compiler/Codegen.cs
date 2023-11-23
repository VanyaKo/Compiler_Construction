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
        //     // TODO: link stdlib classes
        //     // TODO: create instances of some stdlib classes (stdin/stdout/stderr/program args)
        //     // TODO: find entrypoint
        //     // TODO: pass entrypoint IO parameters (stdin, stdout, stderr)
        //     // TODO: pass entrypoint program arguments
        //     // TODO: handle exit code
        // }
    }
}
