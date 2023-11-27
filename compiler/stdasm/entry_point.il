.class public abstract auto ansi beforefieldinit EntryPoint
       extends Class
{
    // Abstract main method
    .method public newslot abstract virtual 
            class Integer main(class StdIn, class StdOut, class Array`1<class Array`1<class Integer>>) cil managed
    {
    }
}

.method public static int32 main() cil managed
{
    .entrypoint
    .maxstack 8

    newobj instance void Main::.ctor()
    dup

    // Example: StdIn, StdOut, Array of Array of Integers
    // TODO
    ldnull // For StdIn
    ldnull // For StdOut
    ldnull // for args

    call instance class Integer Main::main(class StdIn, class StdOut, class Array`1<class Array`1<class Integer>>)

    ret
}