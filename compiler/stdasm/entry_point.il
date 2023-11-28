.class public auto ansi beforefieldinit c_EntryPoint
       extends c_Class
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_Class::.ctor()
        ret
    }

    .method public newslot virtual 
            class c_Integer m_main(class c_CharInput, class c_CharOutput, class c_Array`1<class c_Array`1<class c_Integer>>) cil managed
    {
        .maxstack 1
        newobj instance void c_Integer::.ctor()
        ret
    }
}


.method public static int32 main() cil managed
{
    .entrypoint
    .maxstack 8

    newobj instance void c_Main::.ctor()

    newobj instance void p_c_StdIn::.ctor()
    newobj instance void p_c_StdOut::.ctor()
    call class c_Array`1<class c_Array`1<class c_Integer>> loadArgs()

    call instance class c_Integer c_Main::m_main(class c_CharInput, class c_CharOutput, class c_Array`1<class c_Array`1<class c_Integer>>)
    callvirt instance int32 c_Integer::p_m_data()
    ret
}

.method private hidebysig static class c_Array`1<class c_Array`1<class c_Integer>> 
          loadArgs() cil managed
{
    .maxstack  4
    .locals init (string[] V_0,
             class c_Array`1<class c_Integer>[] V_1,
             int32 V_2)
    IL_0000:  call       string[] [mscorlib]System.Environment::GetCommandLineArgs()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldlen
    IL_0008:  conv.i4
    IL_0009:  ldc.i4.1
    IL_000a:  sub
    IL_000b:  newarr     class c_Array`1<class c_Integer>
    IL_0010:  stloc.1
    IL_0011:  ldc.i4.1
    IL_0012:  stloc.2
    IL_0013:  br.s       IL_0026

    IL_0015:  ldloc.1
    IL_0016:  ldloc.2
    IL_0017:  ldc.i4.1
    IL_0018:  sub
    IL_0019:  ldloc.0
    IL_001a:  ldloc.2
    IL_001b:  ldelem.ref
    IL_001c:  call       class c_Array`1<class c_Integer> strToArray(string)
    IL_0021:  stelem.ref
    IL_0022:  ldloc.2
    IL_0023:  ldc.i4.1
    IL_0024:  add
    IL_0025:  stloc.2
    IL_0026:  ldloc.2
    IL_0027:  ldloc.0
    IL_0028:  ldlen
    IL_0029:  conv.i4
    IL_002a:  blt.s      IL_0015

    IL_002c:  ldloc.1
    IL_002d:  newobj     instance void class c_Array`1<class c_Array`1<class c_Integer>>::.ctor(!0[])
    IL_0032:  ret
}