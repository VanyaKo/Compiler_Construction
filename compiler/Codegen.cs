using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using OluaAST;


namespace Codegen
{
    public class TypeTable
    {
        public Dictionary<string, TypeBuilder> typeMap { get; set; }

        public TypeTable()
        {
            typeMap = new Dictionary<string, TypeBuilder>();
        }

        public Type ResolveType(TypeName typeName)
        {
            // Check if the type is a generic type.
            if (typeName.GenericType != null)
            {
                Type genericTypeDef = typeMap[typeName.Identifier].AsType();
                Type[] typeArgs = { ResolveType(typeName.GenericType) };
                return genericTypeDef.MakeGenericType(typeArgs);
            }
            else
            {
                return typeMap[typeName.Identifier].AsType();
            }
        }
    }
    public class OluaCodegenerator
    {
        public AssemblyBuilder asm { get; set; }
        public ModuleBuilder mod { get; set; }
        public TypeTable typeTable { get; set; }

        public OluaCodegenerator()
        {
            asm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Output"), AssemblyBuilderAccess.Run);
            mod = asm.DefineDynamicModule("Output.exe");
            typeTable = new TypeTable();
        }

        // TODO: link all the stdlib classes externally
        // TODO: wrap into custom main class with the default msil entry point, pseudocode:
        // class _TheVeryMainEntryPoint
        // {
        //     void Main()
        //     {
        //         stdin = { create ConsoleStdInAdapter }
        //         stdout = { create ConsoleStdOutAdapter }
        //         stderr = { create ConsoleStdErrorAdapter }
        //         args = { Array([arg.fromStrToIntsArray() for arg in arguments]) }
        //
        //         exec_program = FoundEntryPointClass(stdin, stdout, stderr, args)
        //         return exec_program.exitCode;
        //     }
        // }

        public void Generate(List<ClassDeclaration> clses)
        {
            // First pass: Define types
            foreach (ClassDeclaration c in clses)
            {
                c.DefineType(mod, typeTable);
            }

            // Second pass: Generate classes
            foreach (ClassDeclaration c in clses)
            {
                c.GenerateClass(typeTable);
            }

            // TODO: find entry point
            // NOTE: save is prohibited, run right here
            // asm.SetEntryPoint(main);
            // asm.Save("Output.exe");
        }
    }
}
