.class public auto ansi beforefieldinit c_Array`1<T>
       extends c_Class
{
    .field private !T[] f_items

    .method public specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.i4.0 // len 0 by default
        newarr !T
        stfld !0[] class c_Array`1<!T>::f_items
        ret
    }

    .method public specialname rtspecialname 
            instance void .ctor(!T[]) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.1
        stfld !0[] class c_Array`1<!T>::f_items
        ret
    }

    .method public specialname rtspecialname 
            instance void .ctor(class c_Integer) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldarg.1
        callvirt instance int32 c_Integer::$data()
        newarr !T
        stfld !0[] class c_Array`1<!T>::f_items
        ret
    }

    .method public instance class c_Integer 
            m_len() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::f_items
        ldlen
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public instance !T 
            m_get(class c_Integer) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::f_items
        ldarg.1
        callvirt instance int32 c_Integer::$data()
        ldelem !T
        ret
    }

    .method public instance void 
            m_set(class c_Integer, !T) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::f_items
        ldarg.1
        callvirt instance int32 c_Integer::$data()
        ldarg.2
        stelem !T
        ret
    }
}