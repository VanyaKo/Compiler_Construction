.class public auto ansi beforefieldinit c_CharOutput
       extends c_Class
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_Class::.ctor()
        ret
    }
    
    .method public newslot virtual 
            instance class c_Integer m_avaliable() cil managed
    {
        .maxstack 1
        ldc.i4 2147483646
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual 
            instance void m_writeChar(class c_Integer) cil managed
    {
        .maxstack 1
        ret
    }

    .method public newslot virtual 
            instance void m_write(class c_Array`1<class c_Integer>) cil managed
    {
        .maxstack 1
        ret
    }

    .method public newslot virtual 
            instance void m_writeLine(class c_Array`1<class c_Integer>) cil managed
    {
        .maxstack 1
        ret
    }
}