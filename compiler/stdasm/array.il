.class public auto ansi beforefieldinit Array`1<T>
       extends Class
{
    .field private class Integer length
    .field private !T[] items

    .method public specialname rtspecialname 
            instance void .ctor(class Integer) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void Class::.ctor()
        ldarg.0
        ldarg.1
        callvirt instance int32 Integer::$data()
        newarr !T
        stfld !0[] class Array`1<!T>::items
        ldarg.0
        ldarg.1
        stfld class Integer Array::length
        ret
    }

    .method public instance class Integer 
            len() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld class Integer Array::length
        ret
    }

    .method public instance !T 
            get(class Integer) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld !0[] class Array`1<!T>::items
        ldarg.1
        callvirt instance int32 Integer::$data()
        ldelem !T
        ret
    }

    .method public instance void 
            set(class Integer, !T) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld !0[] class Array`1<!T>::items
        ldarg.1
        callvirt instance int32 Integer::$data()
        ldarg.2
        stelem !T
        ret
    }
}