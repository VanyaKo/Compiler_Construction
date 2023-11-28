.class public auto ansi beforefieldinit c_Array`1<.ctor T>
       extends c_Class
{
    .field private !T[] p_f_items

    .method public specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldc.i4.0 // len 0 by default
        newarr !T
        stfld !0[] class c_Array`1<!T>::p_f_items
        ret
    }

    .method public specialname rtspecialname 
            instance void .ctor(!T[]) cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void c_Class::.ctor()
        ldarg.0
        ldarg.1
        stfld !0[] class c_Array`1<!T>::p_f_items
        ret
    }

    .method public specialname rtspecialname 
            instance void .ctor(class c_Integer) cil managed 
    {
    .maxstack  3
    .locals init (int32 V_0,
             int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void c_Class::.ctor()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance int32 c_Integer::p_m_data()
    IL_000c:  stloc.0
    IL_000d:  ldarg.0
    IL_000e:  ldloc.0
    IL_000f:  newarr     !T
    IL_0014:  stfld      !0[] class c_Array`1<!T>::p_f_items
    IL_0019:  ldc.i4.0
    IL_001a:  stloc.1
    IL_001b:  br.s       IL_0032

    IL_001d:  ldarg.0
    IL_001e:  ldfld      !0[] class c_Array`1<!T>::p_f_items
    IL_0023:  ldloc.1
    IL_0024:  call       !!0 [mscorlib]System.Activator::CreateInstance<!T>()
    IL_0029:  stelem     !T
    IL_002e:  ldloc.1
    IL_002f:  ldc.i4.1
    IL_0030:  add
    IL_0031:  stloc.1
    IL_0032:  ldloc.1
    IL_0033:  ldloc.0
    IL_0034:  blt.s      IL_001d

    IL_0036:  ret
    }

    .method public instance class c_Integer 
            m_len() cil managed
    {
        .maxstack 1
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::p_f_items
        ldlen
        newobj instance void c_Integer::.ctor(int32)
        ret
    }

    .method public instance !T 
            m_get(class c_Integer) cil managed
    {
        .maxstack 2
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::p_f_items
        ldarg.1
        callvirt instance int32 c_Integer::p_m_data()
        ldelem !T
        ret
    }

    .method public hidebysig instance !T  p_m_get(int32) cil managed
    {
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  ldfld      !0[] class c_Array`1<!T>::p_f_items
        IL_0006:  ldarg.1
        IL_0007:  ldelem     !T
        IL_000c:  ret
    }

    .method public instance void 
            m_set(class c_Integer, !T) cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld !0[] class c_Array`1<!T>::p_f_items
        ldarg.1
        callvirt instance int32 c_Integer::p_m_data()
        ldarg.2
        stelem !T
        ret
    }
}