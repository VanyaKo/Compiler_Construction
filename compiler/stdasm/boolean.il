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
        .maxstack 3
        ldarg.0
        ldfld bool Boolean::data
        ret
    }

    .method public newslot virtual instance class Integer olua_toInteger() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool Boolean::data
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class Boolean olua_or(class Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool Boolean::data
        ldarg.1
        ldfld bool Boolean::data
        or
        newobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean olua_and(class Boolean) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool Boolean::data
        ldarg.1
        ldfld bool Boolean::data
        and
        newobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean olua_not() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld bool Boolean::data
        ldc.i4.0
        ceq
        newobj instance void Boolean::.ctor(bool)
        ret
    }
}