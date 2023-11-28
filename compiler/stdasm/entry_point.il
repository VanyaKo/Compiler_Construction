.class public auto ansi beforefieldinit EntryPoint
       extends Class
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 2
        ldarg.0
        call instance void Class::.ctor()
        ret
    }

    .method public newslot virtual 
            class Integer olua_main(class StdIn, class StdOut, class Array`1<class Array`1<class Integer>>) cil managed
    {
        .maxstack 1
        newobj instance void Integer::.ctor()
        ret
    }
}

.method public static int32 main() cil managed
{
    .entrypoint
    .maxstack 8

    newobj instance void Main::.ctor()

    // Example: StdIn, StdOut, Array of Array of Integers
    // TODO
    ldnull // For StdIn
    ldnull // For StdOut
    ldnull // for args

    call instance class Integer Main::olua_main(class StdIn, class StdOut, class Array`1<class Array`1<class Integer>>)

    ret
}