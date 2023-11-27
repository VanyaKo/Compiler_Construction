.class public auto ansi beforefieldinit StdOut
       extends CharOutput
{
    // avaliable() implementation
    .method public virtual instance class Integer 
            avaliable() cil managed
    {
        ldarg.0
        ldc.i4 2147483646
        newobj instance void Integer::.ctor(int32)
        ret
    }

    // writeChar(e: Integer) implementation
    .method public virtual instance void 
            writeChar(class Integer) cil managed
    {
        // Implement System.Write(chr(e))
    }

    // write(s: Array[Integer]) implementation
    .method public virtual instance void 
            write(class Array`1<class Integer>) cil managed
    {
        // Implement like consequent writeChar on each element of the array
    }

    // writeLine(s: Array[Integer]) implementation
    .method public virtual instance void 
            writeLine(class Array`1<class Integer>) cil managed
    {
        // Implement like consequent writeChar on each element of the array, but add '\n' at the end
    }
}