.class public auto ansi beforefieldinit CharOutput
       extends Class
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void Class::.ctor()
        ret
    }
    
    .method public newslot virtual 
            instance class Integer olua_avaliable() cil managed
    {
        .maxstack 1
        ldc.i4 2147483646
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual 
            instance void olua_writeChar(class Integer) cil managed
    {
        .maxstack 1
        ret
    }

    .method public newslot virtual 
            instance void olua_write(class Array`1<class Integer>) cil managed
    {
        .maxstack 1
        ret
    }

    .method public newslot virtual 
            instance void olua_writeLine(class Array`1<class Integer>) cil managed
    {
        .maxstack 1
        ret
    }
}