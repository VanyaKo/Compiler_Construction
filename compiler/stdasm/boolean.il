.class public auto ansi beforefieldinit Boolean
       extends Class
{
    .field private bool data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldc.i4.0 // false by default
        stfld bool Boolean::data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(bool) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        stfld bool Boolean::data
        ret
    }

    .method public final instance bool $data() cil managed
    {
        ldarg.0
        ldfld bool Boolean::data
        ret
    }

    .method public newslot virtual instance int32 toInteger() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld bool Boolean::data
        ldc.i4.0
        ceq
        ldc.i4.0
        ceq
        ret
    }

    .method public newslot virtual instance bool or(bool val) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld bool Boolean::data
        ldarg.1
        or
        ret
    }
    
    .method public newslot virtual instance bool and(bool val) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld bool Boolean::data
        ldarg.1
        and
        ret
    }
    
    .method public newslot virtual instance bool xor(bool val) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld bool Boolean::data
        ldarg.1
        xor
        ret
    }
    
    .method public newslot virtual instance bool not() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld bool Boolean::data
        ldc.i4.0
        ceq
        ret
    }
}