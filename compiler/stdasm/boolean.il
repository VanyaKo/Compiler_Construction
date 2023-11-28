.class public auto ansi beforefieldinit c_Boolean
       extends c_Class
{
    .field private bool f_data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.i4.0 // false by default
        stfld bool c_Boolean::f_data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(bool) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldarg.1
        stfld bool c_Boolean::f_data
        ret
    }

    .method public final instance bool $f_data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::f_data
        ret
    }

    .method public newslot virtual instance class c_Integer m_toInteger() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::f_data
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_or(class c_Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::f_data
        ldarg.1
        ldfld bool c_Boolean::f_data
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_and(class c_Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::f_data
        ldarg.1
        ldfld bool c_Boolean::f_data
        and
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_not() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::f_data
        ldc.i4.0
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
}