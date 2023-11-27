.class public auto ansi beforefieldinit StdOut
       extends CharOutput
{
    .method public virtual instance class Integer 
            avaliable() cil managed
    {
        ldarg.0
        ldc.i4 2147483646
        newobj instance void Integer::.ctor(int32)
        ret
    }

    // aka System.Write(chr(e))
    .method public virtual instance void 
            writeChar(class Integer) cil managed
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
            write(class Array`1<class Integer>) cil managed
    {
    }

    // like consequent writeChar on each element of the array, but add '\n' at the end
    .method public virtual instance void 
            writeLine(class Array`1<class Integer>) cil managed
    {
    }

    */
}