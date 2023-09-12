### Fixing the ruleset provided on the paper (see [Project_O.pdf](/Project_O.pdf)):

- `//` - for single line comments
- the constructor body cannot contain return
- the entry point to the code is always the constructor of the class that extends EntryPoint (there must be exactly one such a class in the file)
- the program must have only one constructor that has exactly this constructor signature:
    `this(stdin: CharInput, stdout: CharOutput, stderr: CharOutput, args: Array[Array[Integer]]) // where args is a array of strings`
- introducing separate `Invocation: Identifier.method(Arguments)` and `Constructor: ClassName(Arguments)`
- clarify the specification: `Expression: IntegerLiteral | RealLiteral | BooleanLiteral | this | Invocation | Constructor | Indentifier`
      
      note that depending on context even a valid Expression can be banned 
      (for example `if Expression then ...` will ban RealLiteral, IntegerLiteral and this for sure,
      only BooleanLiteral always goes through, but Invocation and Constructor can go through only after type validation.
      The same for method call - arguments - are sequence of expressions, and a expression may be incompatible by type)

### In addition to the classes provided on the paper we need to propose this additional stdlib classes:

```
// base class
class Class is
    method SameRef(o: Class) : Boolean // test is the other object having the same pointer as me
end
```

```
// convension classes
class Output[T] is
    method Avaliable() : Integer // returns the number of items Avaliable to write (usually the remaining size of the reciever's buffer), use for congestion control
    method Write(e: T) : Output[T] // writes an item, blocks until is Avaliable
end

class Input[T] is
    method Avaliable() : Integer // returns the number of items Avaliable to read from the buffer
    method Read() : T // reads an item, blocks until is available
end
```

```
// IO classes
class CharInput extends Input[Integer] is
    // in addition to the Input.Read described functionality this read returns only Integer values that are valid unicode character codes
    method ReadLine() : Array[Integer]
    method Read(n : Integer) : Array[Integer] // read n next characters
end

class CharOutput extends Output[Integer] is
    // in addition to the Output.Write described functionality this write forwards only Inetgers that are valid unicode character codes, otherwise the consumed element is ignored
    method Write(s: Array[Integer]) : CharOutput
    method WriteLine(s: Array[Integer]) : CharOutput
end
```

```
// Class for managing exit code
class EntryPoint is
    var ExitCode : 0 // if a invalid value assigned, the real exit code of the program will be set to 1
end
```

```
// Array copy method
class Array[T] is
    var size: Integer

    // ... (other methods)

    // This creates a shallow copy of the array
    method copy() : Array[T] is
    	var newArray is Array[T](this.size)
    	var i is Integer(0)
    	while i.Less(this.size) loop
        	newArray.set(i, this.get(i))
        	i := i.Plus(1)
    	end
	return newArray
end
end
```

```
// List copy method
class List[T] is
    var items: Array[T]

    // ... (other methods)

    // This creates a shallow copy of the list
    method copy() : List[T] is
        var newList: List[T]()
        var index: Integer(0)
        while index.Less(this.items.Length()) loop
            var item := this.items.get(index)
            newList.append(item)
            index := index.Plus(1)
        end
        return newList
    end
end
```

`TODO: complete the list implementation (add method .Length, wrap returns of head and tail as ListElement[T], where ListElement has fields curr : T, next : T, prev : T, methods .Detach, .Append, .SetCurr)`
