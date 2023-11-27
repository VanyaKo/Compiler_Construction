.assembly extern mscorlib { }

// =================================================================
// Standart Library
// =================================================================

.class public auto ansi beforefieldinit Class
       extends [mscorlib]System.Object
{
    .method public specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void [mscorlib]System.Object::.ctor()
        ret
    }

    .method public instance bool sameRef(class Class o) cil managed
    {
        .maxstack 2
        ldarg.0   // Load the current object reference
        ldarg.1   // Load the reference to the object passed as a parameter
        ceq       // Compare the two references
        ret       // Return the result of the comparison
    }
}

.class public auto ansi beforefieldinit Boolean
       extends Class
{
    .field private bool data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldc.i4.0 // false by default
        stfld bool Boolean::data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(bool val) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        stfld bool Boolean::data
        ret
    }

    .method public final instance bool $data() cil managed
    {
        ldarg.0
        ldfld bool Boolean::data
        ret
    }

    // TODO: Implement other functions...
}

.class public auto ansi beforefieldinit Integer
       extends Class
{
    .field private int32 data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldc.i4.0 // 0 by default
        stfld int32 Integer::data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(int32 val) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        stfld int32 Integer::data
        ret
    }

    .method public final instance int32 $data() cil managed
    {
        ldarg.0
        ldfld int32 Integer::data
        ret
    }

    .method public instance class Integer 
            plus(class Integer other) cil managed
    {
        .maxstack 2
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        add
        ret
    }

    // TODO: Implement minus, mult, div, rem etc similarly...
}

.class public auto ansi beforefieldinit Array`1<T>
       extends Class
{
    .field private class Integer length
    .field private !T[] items

    .method public specialname rtspecialname 
            instance void .ctor(class Integer len) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        callvirt instance int32 Integer::$data
        newarr !!T
        stfld !!T[] Array`1::items
        ldarg.0
        ldarg.1
        stfld class Integer Array`1::length
        ret
    }

    .method public instance class Integer 
            len() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld class Integer Array`1::length
        ret
    }

    .method public instance !!T 
            get(class Integer i) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld !!T[] Array`1::items
        ldarg.1
        callvirt instance int32 Integer::$data
        ldelem !!T
        ret
    }

    .method public instance void 
            set(class Integer i, !!T data) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld !!T[] Array`1::items
        ldarg.1
        callvirt instance int32 Integer::$data
        ldarg.2
        stelem !!T
        ret
    }
}

.class public abstract auto ansi beforefieldinit CharInput
       extends Class
{
    // Abstract Methods
    .method public newslot abstract virtual 
            instance class Integer avaliable() cil managed
    {
    }

    .method public newslot abstract virtual 
            instance class Integer readChar() cil managed
    {
    }

    .method public newslot abstract virtual 
            instance class Array`1<class Integer> readLine() cil managed
    {
    }

    .method public newslot abstract virtual 
            instance class Array`1<class Integer> read(class Integer n) cil managed
    {
    }
}


.class public abstract auto ansi beforefieldinit CharOutput
       extends Class
{
    // Abstract Methods
    .method public newslot abstract virtual 
            instance class Integer avaliable() cil managed
    {
    }

    .method public newslot abstract virtual 
            instance void writeChar(class Integer e) cil managed
    {
    }

    .method public newslot abstract virtual 
            instance void write(class Array`1<class Integer> s) cil managed
    {
    }

    .method public newslot abstract virtual 
            instance void writeLine(class Array`1<class Integer> s) cil managed
    {
    }
}

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
            read(class Integer n) cil managed
    {
        // Implement reading n characters from stdin and returning their integer values
    }
}

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
            writeChar(class Integer e) cil managed
    {
        // Implement System.Write(chr(e))
    }

    // write(s: Array[Integer]) implementation
    .method public virtual instance void 
            write(class Array`1<class Integer> s) cil managed
    {
        // Implement like consequent writeChar on each element of the array
    }

    // writeLine(s: Array[Integer]) implementation
    .method public virtual instance void 
            writeLine(class Array`1<class Integer> s) cil managed
    {
        // Implement like consequent writeChar on each element of the array, but add '\n' at the end
    }
}


.class public abstract auto ansi beforefieldinit EntryPoint
       extends Class
{
    // Abstract main method
    .method public newslot abstract virtual 
            static class Integer main(class StdIn stdin, class StdOut stdout, class StdOut stderr, class Array`1<class Array`1<class Integer>> args) cil managed
    {
    }
}

// =================================================================
// Entry Point
// =================================================================

.method public static int32 main() cil managed
{
    .entrypoint
    .maxstack 8

    // Create an instance of the Factorial class
    newobj instance void Main::.ctor()
    dup

    // Create the arguments for the Factorial.main method
    // Example: StdIn, StdOut, StdOut, Array of Array of Integers
    // TODO
    ldnull // For StdIn
    ldnull // For StdOut
    ldnull // For StdErr
    ldnull // for args

    // Call the Factorial.main method with prepared arguments
    call instance class Integer Main::main(class StdIn, class StdOut, class StdOut, class Array`1<class Array`1<class Integer>>)

    ret
}

// =================================================================
// User code
// =================================================================

