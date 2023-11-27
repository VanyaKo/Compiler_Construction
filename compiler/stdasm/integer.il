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
            instance void .ctor(int32) cil managed 
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
        .maxstack 3
        ldarg.0
        ldfld int32 Integer::data
        ret
    }

    // Arithmetics 

    .method public newslot virtual instance class Integer 
            plus(class Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        add
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class Integer 
            minus(class Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        sub
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class Integer 
            mult(class Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        mul
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class Integer 
            divide(class Integer) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        div
        newobj instance void Integer::.ctor(int32)
        ret
    }

    .method public newslot virtual instance class Integer 
            reminder(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        rem
        newobj instance void Integer::.ctor(int32)
        ret
    }

    // Relations

    .method public newslot virtual instance class Boolean less(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        clt
        newobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean lessEqual(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cle
        ewobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean greater(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cgt
        ewobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean greaterEqual(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cge
        ewobj instance void Boolean::.ctor(bool)
        ret
    }

    .method public newslot virtual instance class Boolean equal(class Integer) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        ceq
        ewobj instance void Boolean::.ctor(bool)
        ret
    }

    // Conversions

    .method public newslot virtual instance class Boolean toBoolean() cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldc.i4.0
        ceq
        newobj instance void Boolean::.ctor(bool)
        ret
    }
    
    // TODO: Implement toReal
}