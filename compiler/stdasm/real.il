.class public auto ansi beforefieldinit c_Real
       extends c_Class
{
  .field private float32 p_f_data

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void c_Class::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldc.r4     0.0
    IL_000c:  stfld      float32 c_Real::p_f_data
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
    IL_0008:  stfld      float32 c_Real::p_f_data
    IL_000d:  ret
  } // end of method c_Real::.ctor
  .method public hidebysig instance float32 
          p_m_data() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ret
  } // end of method c_Real::p_m_data

  .method public newslot virtual 
          instance class c_Real  m_plus(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
    IL_000c:  mul
    IL_000d:  newobj     instance void c_Real::.ctor(float32)
    IL_0012:  ret
  } // end of method c_Real::m_mult

  .method public newslot virtual 
          instance class c_Real  m_divide(class c_Real) cil managed
  {
    // Code size       19 (0x13)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  ldarg.1
    IL_0007:  ldfld      float32 c_Real::p_f_data
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
    IL_0001:  ldfld      float32 c_Real::p_f_data
    IL_0006:  conv.i4
    IL_0007:  newobj     instance void c_Integer::.ctor(int32)
    IL_000c:  ret
  } // end of method c_Real::m_toInteger
}