### Fixing the ruleset provided on the paper (see [Project_O.pdf](/Project_O.pdf)):

- `//` - for single line comments
- no way to pass functions as arguments
- the constructor body cannot contain return
- the variable declaration is set to `var Identifier : {ClassName} := Expression`
- (semantic rule) the entry point to the code is always the constructor of the class that extends EntryPoint (there must be exactly one such a class in the file)
- (semantic rule) the program must have only one constructor that has exactly this constructor signature:
    `this(stdin: StdIn, stdout: StdOut, stderr: StdOut, args: Array[Array[Integer]]) // where args is a array of strings`
- introducing separate `Invocation: Identifier.method(Arguments)` and `Constructor: ClassName(Arguments)`
- extend `Statement` with `Scope` concept: `Scope: is Body end`
- redefine `MethodDeclaration : method Identifier [ Parameters ] [ : Identifier ] Scope`
- for method declaration allow `...) : void is` for declaring methods with no return. that leads to the following consequences:
  - (semantic rule / may be implemented as syntax rule) such method bodies are disallowed to have return statement in body
  - extend `Statement` adding `Invocation` to it such that void functions can be called directly in the body
- clarify the specification: `Expression: IntegerLiteral | RealLiteral | BooleanLiteral | this | Invocation | Constructor | Indentifier`
      
      (semantic rule) note that depending on context even a valid Expression can be banned 
      (for example `if Expression then ...` will ban RealLiteral, IntegerLiteral and this for sure,
      only BooleanLiteral always goes through, but Invocation and Constructor can go through only after type validation.
      The same for method call - arguments - are sequence of expressions, and a expression may be incompatible by type)

### In addition to the classes provided on the paper we need to propose this additional stdlib classes:

```
// base class
class Class is
    method SameRef(o: Class) : Boolean; // test is the other object having the same pointer as me
end
```

```
// IO classes
class CharInput is
    method Avaliable() : Integer; // returns the number of items Avaliable to read from the buffer
    method ReadChar() : Integer; // reads an item, blocks until is available
    method ReadLine() : Array[Integer]; // returns only Integer values that are valid unicode character codes, blocks until is available
    method Read(n : Integer) : Array[Integer]; // read n next characters
end

class CharOutput is
    method Avaliable() : Integer; // returns the number of items Avaliable to write (usually the remaining size of the reciever's buffer), use for congestion control
    method WriteChar(e: Integer); // writes an item, blocks until is Avaliable
    method Write(s: Array[Integer]); // forwards only Inetgers that are valid unicode character codes, otherwise the consumed element is ignored, blocks until is avaliable
    method WriteLine(s: Array[Integer]);
end

class StdIn extends CharInput is
end

class StdOut extends CharOutput is
    method WriteInteger(Integer);
    method WriteReal(Real);
    method WriteBoolean(Boolean);

    method WriteIntegerLine(Integer);
    method WriteRealLine(Real);
    method WriteBooleanLine(Boolean);
end
```

```
// Class for managing exit code
class EntryPoint is
    var ExitCode : Integer := 0; // if a invalid value assigned, the real exit code of the program will be set to 1
end
```

```
// Array copy method
class Array[T] is
    // ... (other methods)

    // This creates a shallow copy of the array
    method copy() : Array[T] is
    	var newArray : Array[T] := Array(this.Length());
    	var i : Integer := 0;
    	while i.Less(this.Length()) loop
        	newArray.set(i, this.get(i));
        	i := i.Plus(1);
    	end
	    return newArray;
    end
end
```

Also we decided to delete list from the std library since it can be implemented using existing language constructions.
