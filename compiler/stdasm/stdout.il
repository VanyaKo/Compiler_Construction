.class public auto ansi beforefieldinit c_StdOut
       extends c_CharOutput
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 1
        ldarg.0
        call instance void c_CharOutput::.ctor()
        ret
    }

    // m_avaliable matches the superclass implementation

    // aka System.Write(chr(e))
    .method public virtual instance void 
            m_writeChar(class c_Integer) cil managed
    {
        .maxstack 2
        ldarg.1
        callvirt instance int32 c_Integer::$data()
        call char [mscorlib]System.Convert::ToChar(int32)
        call void [mscorlib]System.Console::Write(char)
        ret
    }

    // TODO
    /*

    // like consequent writeChar on each element of the array
    .method public virtual instance void 
            m_write(class c_Array`1<class c_Integer>) cil managed
    {
    }

    // like consequent writeChar on each element of the array, but add '\n' at the end
    .method public virtual instance void 
            m_writeLine(class c_Array`1<class c_Integer>) cil managed
    {
    }

    */
}