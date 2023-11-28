.class public auto ansi beforefieldinit c_EntryPoint
       extends c_Class
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_Class::.ctor()
        ret
    }

    .method public newslot virtual 
            class c_Integer m_main(class c_StdIn, class c_StdOut, class c_Array`1<class c_Array`1<class c_Integer>>) cil managed
    {
        .maxstack 1
        newobj instance void c_Integer::.ctor()
        ret
    }
}

.method public static int32 main() cil managed
{
    .entrypoint
    .maxstack 8

    newobj instance void Main::.ctor()

    newobj instance void c_StdIn::.ctor()
    newobj instance void c_StdOut::.ctor()
    ldnull // TODO: args

    call instance class c_Integer Main::m_main(class c_StdIn, class c_StdOut, class c_Array`1<class c_Array`1<class c_Integer>>)

    callvirt instance int32 c_Integer::$data()

    ret
}