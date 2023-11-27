
.class public auto ansi beforefieldinit Real
       extends Class
{
    .field private float64 data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldc.r8 0.0 // 0.0 by default
        stfld float64 Real::data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(float64) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        stfld float64 Real::data
        ret
    }

    .method public final instance float64 $data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld float64 Real::data
        ret
    }

    // TODO: Commented for now, see the example of inetger and adopt
    /*

    .method public newslot virtual instance class Integer olua_toInteger() cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld float64 Real::data
        conv.i4
        ret
    }

    .method public newslot virtual instance class Real 
            olua_plus(class Real other) cil managed
    {
        .maxstack 8
        newobj instance void Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 Real::data
        ldarg.1
        ldfld float64 Real::data
        add
        ret
    }

    .method public newslot virtual instance class Real 
            olua_minus(class Real other) cil managed
    {
        .maxstack 8
        newobj instance void Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 Real::data
        ldarg.1
        ldfld float64 Real::data
        sub
        ret
    }

    .method public newslot virtual instance class Real 
            olua_mult(class Real other) cil managed
    {
        .maxstack 8
        newobj instance void Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 Real::data
        ldarg.1
        ldfld float64 Real::data
        mul
        ret
    }

    .method public newslot virtual instance class Real 
            olua_div(class Real other) cil managed
    {
        .maxstack 8
        newobj instance void Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 Real::data
        ldarg.1
        ldfld float64 Real::data
        div
        ret
    }

    .method public newslot virtual instance class Real 
            olua_rem(class Real other) cil managed
    {
        .maxstack 8
        newobj instance void Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 Real::data
        ldarg.1
        ldfld float64 Real::data
        rem
        ret
    }

    */
}