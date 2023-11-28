.class public auto ansi beforefieldinit p_c_StdIn
       extends c_CharInput
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_CharInput::.ctor()
        ret
    }

    // Read a character from stdin and returning c_Integer(ord(char))
    .method public virtual instance class c_Integer 
            m_readChar() cil managed
    {
    .maxstack  1
    .locals init (valuetype [System.Console]System.ConsoleKeyInfo V_0)
    IL_0000:  call       valuetype [System.Console]System.ConsoleKeyInfo [System.Console]System.Console::ReadKey()
    IL_0005:  stloc.0
    IL_0006:  ldloca.s   V_0
    IL_0008:  call       instance char [System.Console]System.ConsoleKeyInfo::get_KeyChar()
    IL_000d:  call       int32 [mscorlib]System.Convert::ToInt32(char)
    IL_0012:  newobj     instance void c_Integer::.ctor(int32)
    IL_0017:  ret
    }

    // Read a line from stdin and returning c_Integer(ord(chars))
    .method public virtual instance class c_Array`1<class c_Integer> 
            m_readLine() cil managed
    {
    .maxstack  3
    .locals init (string V_0,
             int32 V_1,
             class c_Integer[] V_2,
             int32 V_3,
             int32 V_4)
    IL_0000:  call       string [System.Console]System.Console::ReadLine()
    IL_0005:  stloc.0
    IL_0006:  ldc.i4.0
    IL_0007:  stloc.1
    IL_0008:  ldloc.0
    IL_0009:  brfalse.s  IL_0012

    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0011:  stloc.1
    IL_0012:  ldloc.1
    IL_0013:  newarr     c_Integer
    IL_0018:  stloc.2
    IL_0019:  ldc.i4.0
    IL_001a:  stloc.3
    IL_001b:  br.s       IL_0039

    IL_001d:  ldloc.0
    IL_001e:  ldloc.3
    IL_001f:  callvirt   instance char [mscorlib]System.String::get_Chars(int32)
    IL_0024:  call       int32 [mscorlib]System.Convert::ToInt32(char)
    IL_0029:  stloc.s    V_4
    IL_002b:  ldloc.2
    IL_002c:  ldloc.3
    IL_002d:  ldloc.s    V_4
    IL_002f:  newobj     instance void c_Integer::.ctor(int32)
    IL_0034:  stelem.ref
    IL_0035:  ldloc.3
    IL_0036:  ldc.i4.1
    IL_0037:  add
    IL_0038:  stloc.3
    IL_0039:  ldloc.3
    IL_003a:  ldloc.1
    IL_003b:  blt.s      IL_001d

    IL_003d:  ldloc.2
    IL_003e:  newobj     instance void class c_Array`1<class c_Integer>::.ctor(!0[])
    IL_0043:  ret
    }

    // Read n characters from stdin and return their ascii codes
    .method public virtual instance class c_Array`1<class c_Integer> 
            m_read(class c_Integer n) cil managed
    {
    .maxstack  3
    .locals init (int32 V_0,
             class c_Integer[] V_1,
             int32 V_2)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance int32 c_Integer::p_m_data()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  newarr     c_Integer
    IL_000d:  stloc.1
    IL_000e:  ldc.i4.0
    IL_000f:  stloc.2
    IL_0010:  br.s       IL_001f

    IL_0012:  ldloc.1
    IL_0013:  ldloc.2
    IL_0014:  ldarg.0
    IL_0015:  callvirt   instance class c_Integer c_CharInput::m_readChar()
    IL_001a:  stelem.ref
    IL_001b:  ldloc.2
    IL_001c:  ldc.i4.1
    IL_001d:  add
    IL_001e:  stloc.2
    IL_001f:  ldloc.2
    IL_0020:  ldloc.0
    IL_0021:  blt.s      IL_0012

    IL_0023:  ldloc.1
    IL_0024:  newobj     instance void class c_Array`1<class c_Integer>::.ctor(!0[])
    IL_0029:  ret
    }
}