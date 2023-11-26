.class public auto ansi beforefieldinit Factorial extends EntryPoint {
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed {
        .maxstack 30
        ldarg.0
        ldc.i4 0
        newobj static void Integer::.ctor(int32)
        stfld Integer Factorial::exit_code
        ret
    }
    
    .field public class Integer exit_code
    
    .method public void assert(Boolean) cil managed {
        .maxstack 30
        ldarg.s 1
        callvirt Boolean Boolean::not()
        brfalse.s END_IF_6QPCTFR81LWOFHWKONP1DPIHPVYWIL9F
        ldarg.0
        ldc.i4 1
        newobj static void Integer::.ctor(int32)
        stfld Integer Factorial::exit_code
        END_IF_6QPCTFR81LWOFHWKONP1DPIHPVYWIL9F:
        ret
    }
    
    .method public class Integer computeFactorial(Integer) cil managed {
        .maxstack 30
        .locals (Integer)
        ldc.i4 1
        newobj static void Integer::.ctor(int32)
        stloc.s 0
        WHILE_91ADCL0MK6VZNE4INX3NCHNQ1RTHZGV0:
        ldarg.s 1
        ldc.i4 1
        newobj static void Integer::.ctor(int32)
        callvirt Boolean Integer::greater(Integer)
        brfalse.s END_WHILE_91ADCL0MK6VZNE4INX3NCHNQ1RTHZGV0
        ldloc.s 0
        ldarg.s 1
        callvirt Integer Integer::mult(Integer)
        stloc.s 0
        ldarg.s 1
        ldc.i4 1
        newobj static void Integer::.ctor(int32)
        callvirt Integer Integer::minus(Integer)
        starg.s 1
        END_WHILE_91ADCL0MK6VZNE4INX3NCHNQ1RTHZGV0:
        ldloc.s 0
        ret
    }
    
    .method public class Integer main(StdIn, StdOut, StdOut, Array`1<Array`1<Integer>>) cil managed {
        .maxstack 30
        .locals (Integer)
        ldarg.0
        ldc.i4 10
        newobj static void Integer::.ctor(int32)
        callvirt Integer Factorial::computeFactorial(Integer)
        stloc.s 0
        ldarg.0
        ldloc.s 0
        ldc.i4 3628800
        newobj static void Integer::.ctor(int32)
        callvirt Boolean Integer::equal(Integer)
        callvirt void Factorial::assert(Boolean)
        ldarg.0
        ldfld Integer Factorial::exit_code
        ret
    }
}

