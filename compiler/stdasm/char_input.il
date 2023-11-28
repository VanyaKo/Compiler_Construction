.class public auto ansi beforefieldinit CharInput
       extends Class
{
    .method public newslot virtual 
            instance class Integer olua_avaliable() cil managed
    {
        .maxstack 1
        ldc.i4 2147483646
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual 
            instance class Integer olua_readChar() cil managed
    {
        .maxstack 1
        newobj instance void Integer::.ctor()
        ret
    }

    .method public newslot virtual 
            instance class Array`1<class Integer> olua_readLine() cil managed
    {
        .maxstack 2
        newobj instance void Integer::.ctor()
        newobj instance void class Array`1<class Integer>::.ctor(class Integer)
        ret
    }

    .method public newslot virtual 
            instance class Array`1<class Integer> olua_read(class Integer) cil managed
    {
        .maxstack 2
        newobj instance void Integer::.ctor()
        newobj instance void class Array`1<class Integer>::.ctor(class Integer)
        ret
    }
}