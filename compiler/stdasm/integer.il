.class public auto ansi beforefieldinit Integer
       extends Class
{
    .field private int32 data

    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldc.i4.0 // 0 by default
        stfld int32 Integer::data
        ret
    }

    .method public hidebysig specialname rtspecialname 
            instance void .ctor(int32 val) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        stfld int32 Integer::data
        ret
    }

    .method public final instance int32 $data() cil managed
    {
        ldarg.0
        ldfld int32 Integer::data
        ret
    }

    .method public instance class Integer 
            plus(class Integer other) cil managed
    {
        .maxstack 2
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        add
        ret
    }

    // TODO: Implement minus, mult, div, rem etc similarly...
}