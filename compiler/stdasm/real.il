.class public auto ansi beforefieldinit c_Real
       extends c_Class
{
    .field private float64 f_data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.r8 0.0 // 0.0 by default
        stfld float64 c_Real::f_data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(float64) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldarg.1
        stfld float64 c_Real::f_data
        ret
    }

    .method public final instance float64 $data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld float64 c_Real::f_data
        ret
    }
    
    // Conversion
    
    .method public newslot virtual instance class c_Integer m_toInteger() cil managed
    {
        .maxstack 8
        newobj instance void c_Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        conv.i4
        ret
    }

    // Arithmetics
    
    .method public newslot virtual instance class c_Real 
            m_plus(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        add
        ret
    }

    .method public newslot virtual instance class c_Real 
            m_minus(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        sub
        ret
    }

    .method public newslot virtual instance class c_Real 
            m_mult(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        mul
        ret
    }

    .method public newslot virtual instance class c_Real 
            m_div(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        div
        ret
    }

    .method public newslot virtual instance class c_Real 
            m_rem(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        rem
        ret
    }

    // Relations

    .method public newslot virtual instance class c_Boolean m_less(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        clt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_greater(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        cgt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_equal(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_lessEqual(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        clt
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_greaterEqual(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        cgt
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
}