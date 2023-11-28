.method public hidebysig static class c_Array`1<class c_Integer> 
          strToArray(string) cil managed
{
    // Code size       56 (0x38)
    .maxstack  4
    .locals init (class c_Integer[] V_0,
             int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0006:  newarr     c_Integer
    IL_000b:  stloc.0
    IL_000c:  ldc.i4.0
    IL_000d:  stloc.1
    IL_000e:  br.s       IL_0028

    IL_0010:  ldloc.0
    IL_0011:  ldloc.1
    IL_0012:  ldarg.0
    IL_0013:  ldloc.1
    IL_0014:  callvirt   instance char [mscorlib]System.String::get_Chars(int32)
    IL_0019:  call       int32 [mscorlib]System.Convert::ToInt32(char)
    IL_001e:  newobj     instance void c_Integer::.ctor(int32)
    IL_0023:  stelem.ref
    IL_0024:  ldloc.1
    IL_0025:  ldc.i4.1
    IL_0026:  add
    IL_0027:  stloc.1
    IL_0028:  ldloc.1
    IL_0029:  ldarg.0
    IL_002a:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_002f:  blt.s      IL_0010

    IL_0031:  ldloc.0
    IL_0032:  newobj     instance void class c_Array`1<class c_Integer>::.ctor(!0[])
    IL_0037:  ret
}