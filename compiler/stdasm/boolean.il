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
            instance void .ctor(bool val) cil managed 
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

    // TODO: Implement other functions...
}