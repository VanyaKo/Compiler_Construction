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
    .maxstack  3
    .locals init (string[] V_0,
             class c_Array`1<class c_Integer>[] V_1,
             int32 V_2,
             string V_3,
             class c_Integer[] V_4,
             int32 V_5,
             char V_6)
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
    IL_0013:  br.s       IL_0066

    IL_0015:  ldloc.0
    IL_0016:  ldloc.2
    IL_0017:  ldelem.ref
    IL_0018:  stloc.3
    IL_0019:  ldloc.3
    IL_001a:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_001f:  newarr     c_Integer
    IL_0024:  stloc.s    V_4
    IL_0026:  ldc.i4.0
    IL_0027:  stloc.s    V_5
    IL_0029:  br.s       IL_004c

    IL_002b:  ldloc.3
    IL_002c:  ldloc.s    V_5
    IL_002e:  callvirt   instance char [mscorlib]System.String::get_Chars(int32)
    IL_0033:  stloc.s    V_6
    IL_0035:  ldloc.s    V_4
    IL_0037:  ldloc.s    V_5
    IL_0039:  ldloc.s    V_6
    IL_003b:  call       int32 [mscorlib]System.Convert::ToInt32(char)
    IL_0040:  newobj     instance void c_Integer::.ctor(int32)
    IL_0045:  stelem.ref
    IL_0046:  ldloc.s    V_5
    IL_0048:  ldc.i4.1
    IL_0049:  add
    IL_004a:  stloc.s    V_5
    IL_004c:  ldloc.s    V_5
    IL_004e:  ldloc.3
    IL_004f:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0054:  blt.s      IL_002b

    IL_0056:  ldloc.1
    IL_0057:  ldloc.2
    IL_0058:  ldc.i4.1
    IL_0059:  sub
    IL_005a:  ldloc.s    V_4
    IL_005c:  newobj     instance void class c_Array`1<class c_Integer>::.ctor(!0[])
    IL_0061:  stelem.ref
    IL_0062:  ldloc.2
    IL_0063:  ldc.i4.1
    IL_0064:  add
    IL_0065:  stloc.2
    IL_0066:  ldloc.2
    IL_0067:  ldloc.0
    IL_0068:  ldlen
    IL_0069:  conv.i4
    IL_006a:  blt.s      IL_0015

    IL_006c:  ldloc.1
    IL_006d:  newobj     instance void class c_Array`1<class c_Array`1<class c_Integer>>::.ctor(!0[])
    IL_0072:  ret
}