.class public auto ansi beforefieldinit Class
       extends [mscorlib]System.Object
{
    .method public specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void [mscorlib]System.Object::.ctor()
        ret
    }

    .method public newslot virtual instance class Boolean sameRef(class Class) cil managed
    {
        .maxstack 2
        ldarg.0   // Load the current object reference
        ldarg.1   // Load the reference to the object passed as a parameter
        ceq       // Compare the two references
        newobj instance void Boolean::.ctor(bool) // wrap with Boolean
        ret       // Return the result of the comparison
    }
}