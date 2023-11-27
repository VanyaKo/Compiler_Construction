.class public auto ansi beforefieldinit StdIn
       extends CharInput
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

    // readChar() implementation
    .method public virtual instance class Integer 
            readChar() cil managed
    {
        // Implement reading a character from stdin and returning Integer(ord(char))
    }

    // readLine() implementation
    .method public virtual instance class Array`1<class Integer> 
            readLine() cil managed
    {
        // Implement reading a line from stdin and returning Integer(ord(chars))
    }

    // read(n: Integer) implementation
    .method public virtual instance class Array`1<class Integer> 
            read(class Integer) cil managed
    {
        // Implement reading n characters from stdin and returning their integer values
    }
}