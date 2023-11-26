.class public auto ansi beforefieldinit Class
       extends [mscorlib]System.Object
{
    // Constructor
    .method public hidebysig specialname rtspecialname 
            instance void .ctor() cil managed 
    {
        .maxstack 8
        ldarg.0
        call instance void [mscorlib]System.Object::.ctor()
        ret
    }

    // sameRef method
    .method public hidebysig instance bool sameRef(class Class o) cil managed
    {
        .maxstack 2
        ldarg.0   // Load the current object reference
        ldarg.1   // Load the reference to the object passed as a parameter
        ceq       // Compare the two references
        ret       // Return the result of the comparison
    }
}
