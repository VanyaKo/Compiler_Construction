.class public auto ansi beforefieldinit StdIn
       extends CharInput
{
    .method public virtual instance class Integer 
            olua_avaliable() cil managed
    {
        .maxstack 3
        ldarg.0
        ldc.i4 2147483646
        newobj instance void Integer::.ctor(int32)
        ret
    }

    // Read a character from stdin and returning Integer(ord(char))
    .method public virtual instance class Integer 
            olua_readChar() cil managed
    {
        .maxstack 3
        call class [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey()
        callvirt instance char [mscorlib]System.ConsoleKeyInfo::get_KeyChar()
        call int32 [mscorlib]System.Convert::ToInt32(char)
        newobj instance void Integer::.ctor(int32)
        ret
    }

    // TODO

    /*

    // Read a line from stdin and returning Integer(ord(chars))
    .method public virtual instance class Array`1<class Integer> 
            olua_readLine() cil managed
    {
        .maxstack 4
        .locals (int32, string, class Integer[])

        // Use Console.ReadLine to read a line
        call string [mscorlib]System.Console::ReadLine()

        // Get the length of the string
        callvirt instance int32 [mscorlib]System.String::get_Length()
        stloc.0

        // Create an array to store the ASCII values
        ldloc.0
        newarr class Integer

        // Loop through each character in the string
        ldarg.0
        ldloc.0
        ldc.i4.0
        callvirt instance string [mscorlib]System.Console::ReadLine(int32, int32)
        stloc.1

        // Iterate through the characters
        ldc.i4.0
        stloc.2
        br.s IL_003f

        IL_002b:
            ldloc.1
            ldloc.2
            callvirt instance char [mscorlib]System.String::get_Chars(int32)
            call int32 [mscorlib]System.Convert::ToInt32(char)
            newobj instance void Integer::.ctor(int32)
            stelem.ref

        IL_003f:
            ldloc.2
            ldloc.0
            blt.s IL_002b

        // Return the array of Integer objects
        ldloc.2
        newobj instance void Array`1<class Integer>::.ctor(!0[])
        ret
    }

    // Read n characters from stdin and returning their integer values
    .method public virtual instance class Array`1<class Integer> 
            olua_read(class Integer n) cil managed
    {
        .maxstack 4
        .locals (int32, int32, class Integer[])

        // Get the value of n
        ldarg.1
        callvirt instance int32 Integer::$data()
        stloc.0

        // Create an array to store the ASCII values
        ldloc.0
        newarr class Integer
        stloc.2

        // Loop to read n characters
        ldloc.0
        stloc.1
        brfalse.s IL_002f

        IL_001b:
            ldarg.0
            callvirt instance class Integer StdIn::readChar()
            ldloc.1
            ldc.i4.1
            sub
            stelem.ref
            ldloc.1
            ldc.i4.1
            sub
            stloc.1
            brtrue.s IL_001b

        IL_002f:

        // Return the array of Integer objects
        ldloc.2
        newobj instance void Array`1<class Integer>::.ctor(!0[])
        ret
    }

    */
}