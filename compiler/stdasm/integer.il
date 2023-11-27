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
        ldarg.0
        ldfld int32 Integer::data
        ret
    }

    .method public newslot virtual instance class Integer 
            plus(class Integer) cil managed
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

    // Implementation of minus
    .method public newslot virtual instance class Integer 
            minus(class Integer other) cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        sub
        ret
    }

    // Implementation of mult
    .method public newslot virtual instance class Integer 
            mult(class Integer other) cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        mul
        ret
    }

    // Implementation of div
    .method public newslot virtual instance class Integer 
            div(class Integer other) cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        div
        ret
    }

    // Implementation of rem
    .method public newslot virtual instance class Integer 
            rem(class Integer other) cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        rem
        ret
    }

    // Implementation of toBoolean
    .method public newslot virtual instance bool toBoolean() cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldc.i4.0
        cgt.un
        ret
    }

    // Implementation of unaryMinus
    .method public newslot virtual instance class Integer unaryMinus() cil managed
    {
        .maxstack 8
        newobj instance void Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld int32 Integer::data
        neg
        ret
    }

    // Implementation of relational methods
    // less
    .method public newslot virtual instance bool less(class Integer other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        clt
        ret
    }

    // lessEqual
    .method public newslot virtual instance bool lessEqual(class Integer other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cle
        ret
    }

    // greater
    .method public newslot virtual instance bool greater(class Integer other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cgt
        ret
    }

    // greaterEqual
    .method public newslot virtual instance bool greaterEqual(class Integer other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        cge
        ret
    }

    // equal
    .method public newslot virtual instance bool equal(class Integer other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld int32 Integer::data
        ldarg.1
        ldfld int32 Integer::data
        ceq
        ret
    }
    
    // TODO: Implement toReal
}