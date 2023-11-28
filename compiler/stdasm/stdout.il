.class public auto ansi beforefieldinit StdOut
       extends CharOutput
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void CharOutput::.ctor()
        ret
    }

    // olua_avaliable matches the superclass implementation

    // aka System.Write(chr(e))
    .method public virtual instance void 
            olua_writeChar(class Integer) cil managed
    {
        .maxstack 2
        ldarg.1
        callvirt instance int32 Integer::$data()
        call char [mscorlib]System.Convert::ToChar(int32)
        call void [mscorlib]System.Console::Write(char)
        ret
    }

    // TODO
    /*

    // like consequent writeChar on each element of the array
    .method public virtual instance void 
            olua_write(class Array`1<class Integer>) cil managed
    {
    }

    // like consequent writeChar on each element of the array, but add '\n' at the end
    .method public virtual instance void 
            olua_writeLine(class Array`1<class Integer>) cil managed
    {
    }

    */
}