.class public auto ansi beforefieldinit p_c_StdOut
       extends c_CharOutput
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_CharOutput::.ctor()
        ret
    }

    // aka System.Write(chr(e))
    .method public virtual instance void 
            m_writeChar(class c_Integer) cil managed
    {
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance int32 c_Integer::p_m_data()
    IL_0006:  call       char [mscorlib]System.Convert::ToChar(int32)
    IL_000b:  call       void [System.Console]System.Console::Write(char)
    IL_0010:  ret
    }

    // like consequent writeChar on each element of the array
    .method public virtual instance void 
            m_write(class c_Array`1<class c_Integer>) cil managed
    {
    .maxstack  3
    .locals init (int32 V_0)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  br.s       IL_0015

    IL_0004:  ldarg.0
    IL_0005:  ldarg.1
    IL_0006:  ldloc.0
    IL_0007:  callvirt   instance !0 class c_Array`1<class c_Integer>::p_m_get(int32)
    IL_000c:  callvirt   instance void c_CharOutput::m_writeChar(class c_Integer)
    IL_0011:  ldloc.0
    IL_0012:  ldc.i4.1
    IL_0013:  add
    IL_0014:  stloc.0
    IL_0015:  ldloc.0
    IL_0016:  ldarg.1
    IL_0017:  callvirt   instance class c_Integer class c_Array`1<class c_Integer>::m_len()
    IL_001c:  callvirt   instance int32 c_Integer::p_m_data()
    IL_0021:  blt.s      IL_0004

    IL_0023:  ret
    }

    // like consequent writeChar on each element of the array, but add '\n' at the end
    .method public virtual instance void 
            m_writeLine(class c_Array`1<class c_Integer>) cil managed
    {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance void c_CharOutput::m_write(class c_Array`1<class c_Integer>)
    IL_0007:  call       void [System.Console]System.Console::WriteLine()
    IL_000c:  ret
    }
}