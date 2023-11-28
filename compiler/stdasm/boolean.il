.class public auto ansi beforefieldinit c_Boolean
       extends c_Class
{
    .field private bool p_f_data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.i4.0 // false by default
        stfld bool c_Boolean::p_f_data
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
        stfld bool c_Boolean::p_f_data
        ret
    }

    .method public final instance bool p_m_data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::p_f_data
        ret
    }

    .method public newslot virtual instance class c_Integer m_toInteger() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::p_f_data
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_or(class c_Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::p_f_data
        ldarg.1
        ldfld bool c_Boolean::p_f_data
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_and(class c_Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::p_f_data
        ldarg.1
        ldfld bool c_Boolean::p_f_data
        and
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_not() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool c_Boolean::p_f_data
        ldc.i4.0
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual 
          instance class c_Array`1<class c_Integer> 
          m_toString() cil managed
    {
        // Code size       26 (0x1a)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      bool c_Boolean::p_f_data
        IL_0006:  brtrue.s   IL_000f

        IL_0008:  ldstr      "false"
        IL_000d:  br.s       IL_0014

        IL_000f:  ldstr      "true"
        IL_0014:  call       class c_Array`1<class c_Integer> strToArray(string)
        IL_0019:  ret
    }
}