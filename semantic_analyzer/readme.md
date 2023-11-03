## Semantic rules

Performed after linking of the runtime libraries

### typename

- for a generic type, the inner type must be defined

### constructorInvocation

- typename is a existing class, either declared by the user or is defined in the runtime library

### attribute

- attribute is either a existing method or a variable

### methodInvocation

- attribute is a existing method name
- argumentList has the same number of arguments that the function accepts
- each object in argumentList is the correct subtype that is acceped by the function at this position

### classDeclaration

- exactly one of the declared classes must extend EntryPoint
- IDENTIFIER is not occupied by the other user defined classes or by the runtime library classes
- typename is a existing class, either declared by the user or is defined in the runtime library
- there must be at most one constructor

### methodDeclaration

- IDENTIFIER is not colliding with the superclass attributes and other near defined attributes
- typename is a existing class, either declared by the user or is defined in the runtime library
- if typename is void, void return is only allowed in the scope (done on syntax stage)

### constructorDeclaration

- void return is only allowed in the scope (done on syntax stage)
- iff class extends EntryPoint, the constructor must be `this(stdin: StdIn, stdout: StdOut, stderr: StdOut, args: Array[Array[Integer]])`

### variableDeclaration

- IDENTIFIER is not colliding with the superclass attributes and other near defined attributes
- typename is a existing class, either declared by the user or is defined in the runtime library
- object is the a valid subtype of the typename

### assignment

- attribute is a existing variable name
- IDENTIFIER must be a valid name from the scope

### if/while 

- object must be a valid bool subtype

