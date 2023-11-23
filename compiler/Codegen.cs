using System.Text;
using OluaAST;


namespace Codegen
{
    class TypeTable
    {
        public Dictionary<string, Type> typeMap { get; set; }

        private Type Resolve(TypeName typeName)
        {
            // Check if the type is a generic type.
            if (typeName.GenericType != null)
            {
                Type genericTypeDef = typeMap[typeName.Identifier]; // Get the generic type definition.
                Type[] typeArgs = { Resolve(typeName.GenericType) }; // Resolve type arguments.
                return genericTypeDef.MakeGenericType(typeArgs);
            }
            else
            {
                return typeMap[typeName.Identifier];
            }
        }
    }
    class OluaCodegenerator
    {
        public AssemblyBuilder asm { get; set; }
        public ModuleBuilder mod { get; set; }
        public TypeTable typeTable { get; set; }

        public OluaCodegenerator()
        {
            asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Output"), AssemblyBuilderAccess.RunAndSave);
            mod = asm.DefineDynamicModule("Output.exe", "Output.exe")
            typeTable = = new TypeTable();
        }

        // TODO: link all the stdlib classes externally
        // TODO: wrap into custom main class with the default msil entry point, pseudocode:
        // class TheVeryMainEntryPoint // NOTE: redefining this name in the user code may produce unexpected behaviour
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
            // know the classnames
            List<TypeBuilder>[] typeBldrs = new List<TypeBuilder>[clses.Count];
            foreach (ClassDeclaration cls in clses)
            {
                typeBldrs.Add(cls.DefineType(mod, typeTable););
            }

            foreach (TypeBuilder t, ClassDeclaration cls in zip(typeBldrs, clses)) {
                cls.GenerateClass(t, typeTable);
            }

            // TODO: find entry point
            asm.SetEntryPoint(main);
            asm.Save("Output.exe");
        }
    }
}
