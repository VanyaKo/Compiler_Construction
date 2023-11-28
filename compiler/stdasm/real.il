.class public auto ansi beforefieldinit c_Real
       extends c_Class
{
  .field private float32 f_data

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void c_Class::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldc.r4     0.0
    IL_000c:  stfld      float32 c_Real::f_data
    IL_0011:  ret
  } // end of method c_Real::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(float32 data) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void c_Class::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      float32 c_Real::f_data
    IL_000d:  ret
  } // end of method c_Real::.ctor

<<<<<<< HEAD
    .method public final instance float64 $data() cil managed
    {
        .maxstack 3
        ldarg.0
        ldfld float64 c_Real::f_data
        ret
    }
    
    // Conversion
    
    .method public newslot virtual instance class c_Integer m_toInteger() cil managed
    {
        .maxstack 8
        newobj instance void c_Integer::.ctor(int32)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        conv.i4
        ret
    }

    // Arithmetics
    
    .method public newslot virtual instance class c_Real 
            m_plus(class c_Real other) cil managed
    {
        .maxstack 8
        newobj instance void c_Real::.ctor(float64)
        dup
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        add
        ret
    }
=======
  .method public hidebysig instance float32 
          p_m_data() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ret
  } // end of method c_Real::p_m_data

  .method public newslot virtual 
          instance class c_Real  m_plus(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  add
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_plus

  .method public newslot virtual 
          instance class c_Real  m_minus(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  sub
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_minus

  .method public newslot virtual 
          instance class c_Real  m_mult(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  mul
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_mult
>>>>>>> dev-vitaly

  .method public newslot virtual 
          instance class c_Real  m_divide(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  div
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_divide

  .method public newslot virtual 
          instance class c_Real  m_reminder(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  rem
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_reminder

  .method public newslot virtual 
          instance class c_Boolean  m_less(class c_Real) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  clt
    IL_000e:  newobj     instance void c_Boolean::.ctor(bool)
    IL_0013:  ret
  } // end of method c_Real::m_less

  .method public newslot virtual 
          instance class c_Boolean  m_greater(class c_Real) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  cgt
    IL_000e:  newobj     instance void c_Boolean::.ctor(bool)
    IL_0013:  ret
  } // end of method c_Real::m_greater

  .method public newslot virtual 
          instance class c_Boolean  m_equal(class c_Real) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::f_data
    IL_000c:  ceq
    IL_000e:  newobj     instance void c_Boolean::.ctor(bool)
    IL_0013:  ret
  } // end of method c_Real::m_equal

  .method public newslot virtual 
          instance class c_Integer  m_toInteger() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::f_data
    IL_0006:  conv.i4
    IL_0007:  newobj     instance void c_Integer::.ctor(int32)
    IL_000c:  ret
  } // end of method c_Real::m_toInteger

<<<<<<< HEAD
    // Relations

    .method public newslot virtual instance class c_Boolean m_less(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        clt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_greater(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        cgt
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_equal(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_lessEqual(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        clt
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
    
    .method public newslot virtual instance class c_Boolean m_greaterEqual(class c_Real other) cil managed
    {
        .maxstack 8
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        cgt
        ldarg.0
        ldfld float64 c_Real::f_data
        ldarg.1
        ldfld float64 c_Real::f_data
        ceq
        or
        newobj instance void c_Boolean::.ctor(bool)
        ret
    }
=======
>>>>>>> dev-vitaly
}