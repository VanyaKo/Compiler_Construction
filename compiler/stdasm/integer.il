.class public auto ansi beforefieldinit c_Integer
       extends c_Class
{
    .field private int32 f_data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.i4.0 // 0 by default
        stfld int32 c_Integer::f_data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(int32) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldarg.1
        stfld int32 c_Integer::f_data
        ret
    }

    .method public final instance int32 $data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 c_Integer::f_data
        ret
    }

    // Arithmetics 

    .method public newslot virtual instance class c_Integer 
            m_plus(class c_Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        add
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Integer 
            m_minus(class c_Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        sub
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Integer 
            m_mult(class c_Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        mul
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Integer 
            m_divide(class c_Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        div
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class c_Integer 
            m_reminder(class c_Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        rem
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    // Relations

    .method public newslot virtual instance class c_Boolean m_less(class c_Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        clt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_greater(class c_Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        cgt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class c_Boolean m_equal(class c_Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldarg.1
        ldfld int32 c_Integer::f_data
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }

    // Conversions

    .method public newslot virtual instance class c_Boolean m_toBoolean() cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 c_Integer::f_data
        ldc.i4.0
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    // TODO: Implement toReal
}