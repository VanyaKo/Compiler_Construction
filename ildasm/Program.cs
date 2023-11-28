using System;
using System.Diagnostics;


public class c_Class : Object
{
    public c_Class()
    {
    }

    public virtual c_Boolean m_sameRef(c_Class obj)
    {
        return new c_Boolean(Object.ReferenceEquals(this, obj));
    }
}


public class c_Array<T> : c_Class
{
    private T[] f_items;

    public c_Array()
    {
        f_items = new T[0];
    }

    public c_Array(T[] items)
    {
        f_items = items;
    }

    public c_Array(c_Integer length)
    {

        f_items = new T[length.p_m_data()];
    }

    public c_Integer m_len()
    {
        return new c_Integer(f_items.Length);
    }

    public T m_get(c_Integer index)
    {
        return f_items[index.p_m_data()];
    }

    public T p_m_get(int index)
    {
        return f_items[index];
    }

    public void m_set(c_Integer index, T value)
    {
        f_items[index.p_m_data()] = value;
    }
}

public class c_Boolean : c_Class
{
    private bool f_data;

    public c_Boolean()
    {
        f_data = false;
    }

    public c_Boolean(bool data)
    {
        f_data = data;
    }

    public bool p_m_data()
    {
        return f_data;
    }

    public virtual c_Integer m_toInteger()
    {
        return new c_Integer(f_data ? 1 : 0);
    }

    public virtual c_Boolean m_or(c_Boolean other)
    {
        return new c_Boolean(f_data || other.f_data);
    }

    public virtual c_Boolean m_and(c_Boolean other)
    {
        return new c_Boolean(f_data && other.f_data);
    }

    public virtual c_Boolean m_not()
    {
        return new c_Boolean(!f_data);
    }
}

public class c_Real : c_Class
{
    private float f_data;

    public c_Real()
    {
        f_data = 0;
    }

    public c_Real(float data)
    {
        f_data = data;
    }

    public float p_m_data()
    {
        return f_data;
    }

    // Arithmetics

    public virtual c_Real m_plus(c_Real other)
    {
        return new c_Real(f_data + other.f_data);
    }

    public virtual c_Real m_minus(c_Real other)
    {
        return new c_Real(f_data - other.f_data);
    }

    public virtual c_Real m_mult(c_Real other)
    {
        return new c_Real(f_data * other.f_data);
    }

    public virtual c_Real m_divide(c_Real other)
    {
        return new c_Real(f_data / other.f_data);
    }

    public virtual c_Real m_reminder(c_Real other)
    {
        return new c_Real(f_data % other.f_data);
    }

    // Relations

    public virtual c_Boolean m_less(c_Real other)
    {
        return new c_Boolean(f_data < other.f_data);
    }

    public virtual c_Boolean m_greater(c_Real other)
    {
        return new c_Boolean(f_data > other.f_data);
    }

    public virtual c_Boolean m_equal(c_Real other)
    {
        return new c_Boolean(f_data == other.f_data);
    }

    // Conversions

    public virtual c_Integer m_toInteger()
    {
        return new c_Integer((int)f_data);
    }
}

public class c_Integer : c_Class
{
    private int f_data;

    public c_Integer()
    {
        f_data = 0;
    }

    public c_Integer(int data)
    {
        f_data = data;
    }

    public int p_m_data()
    {
        return f_data;
    }

    // Arithmetics

    public virtual c_Integer m_plus(c_Integer other)
    {
        return new c_Integer(f_data + other.f_data);
    }

    public virtual c_Integer m_minus(c_Integer other)
    {
        return new c_Integer(f_data - other.f_data);
    }

    public virtual c_Integer m_mult(c_Integer other)
    {
        return new c_Integer(f_data * other.f_data);
    }

    public virtual c_Integer m_divide(c_Integer other)
    {
        return new c_Integer(f_data / other.f_data);
    }

    public virtual c_Integer m_reminder(c_Integer other)
    {
        return new c_Integer(f_data % other.f_data);
    }

    // Relations

    public virtual c_Boolean m_less(c_Integer other)
    {
        return new c_Boolean(f_data < other.f_data);
    }

    public virtual c_Boolean m_greater(c_Integer other)
    {
        return new c_Boolean(f_data > other.f_data);
    }

    public virtual c_Boolean m_equal(c_Integer other)
    {
        return new c_Boolean(f_data == other.f_data);
    }

    // Conversions

    public virtual c_Boolean m_toBoolean()
    {
        return new c_Boolean(f_data == 0);
    }

    public virtual c_Real m_toReal()
    {
        return new c_Real((float)f_data);
    }
}

public class c_CharInput : c_Class
{
    public c_CharInput()
    {
    }

    public virtual c_Integer m_readChar()
    {
        return new c_Integer();
    }

    public virtual c_Array<c_Integer> m_readLine()
    {
        return new c_Array<c_Integer>();
    }

    public virtual c_Array<c_Integer> m_read(c_Integer length)
    {
        return new c_Array<c_Integer>();
    }
}

public class c_CharOutput : c_Class
{
    public c_CharOutput()
    {
    }

    public virtual void m_writeChar(c_Integer character)
    {
    }

    public virtual void m_write(c_Array<c_Integer> characters)
    {
    }

    public virtual void m_writeLine(c_Array<c_Integer> characters)
    {
    }
}

public class p_c_StdIn : c_CharInput
{
    public p_c_StdIn()
    {
    }

    public override c_Integer m_readChar()
    {
        char keyChar = Console.ReadKey().KeyChar;
        int asciiValue = Convert.ToInt32(keyChar);
        return new c_Integer(asciiValue);
    }

    public override c_Array<c_Integer> m_readLine()
    {
        string? line = Console.ReadLine();
        int length = 0;
        if (line != null)
        {
            length = line.Length;
        }
        c_Integer[] asciiValues = new c_Integer[length];

        for (int i = 0; i < length; i++)
        {
            Debug.Assert(line != null);
            char character = line[i];
            int asciiValue = Convert.ToInt32(character);
            asciiValues[i] = new c_Integer(asciiValue);
        }

        return new c_Array<c_Integer>(asciiValues);
    }

    public override c_Array<c_Integer> m_read(c_Integer n)
    {
        int count = n.p_m_data();
        c_Integer[] asciiValues = new c_Integer[count];

        for (int i = 0; i < count; i++)
        {
            asciiValues[i] = m_readChar();
        }

        return new c_Array<c_Integer>(asciiValues);
    }
}

public class p_c_StdOut : c_CharOutput
{
    public p_c_StdOut()
    {
    }

    public override void m_writeChar(c_Integer character)
    {
        char charValue = Convert.ToChar(character.p_m_data());
        Console.Write(charValue);
    }

    public override void m_write(c_Array<c_Integer> characters)
    {
        int i = 0;
        while (i < characters.m_len().p_m_data())
        {
            m_writeChar(characters.p_m_get(i));
            i++;
        }
    }

    public override void m_writeLine(c_Array<c_Integer> characters)
    {
        m_write(characters);
        Console.WriteLine();
    }
}

public class c_EntryPoint : c_Class
{
    public c_EntryPoint()
    {
    }

    public virtual c_Integer m_main(c_CharInput stdin, c_CharOutput stdout, c_Array<c_Array<c_Integer>> args)
    {
        return new c_Integer();
    }
}

public static class Program
{
    public static int Main()
    {
        c_EntryPoint mainObj = new c_EntryPoint();
        c_CharInput stdin = new p_c_StdIn();
        c_CharOutput stdout = new p_c_StdOut();
        c_Array<c_Array<c_Integer>> args = loadArgs();

        c_Integer result = mainObj.m_main(stdin, stdout, args);
        return result.p_m_data();
    }

    private static c_Array<c_Array<c_Integer>> loadArgs()
    {
        string[] commandLineArgs = Environment.GetCommandLineArgs();

        c_Array<c_Integer>[] argArrays = new c_Array<c_Integer>[commandLineArgs.Length - 1];

        for (int i = 1; i < commandLineArgs.Length; i++)
        {
            string arg = commandLineArgs[i];
            c_Integer[] argChars = new c_Integer[arg.Length];

            for (int j = 0; j < arg.Length; j++)
            {
                char ch = arg[j];
                argChars[j] = new c_Integer(Convert.ToInt32(ch));
            }

            argArrays[i - 1] = new c_Array<c_Integer>(argChars);
        }

        return new c_Array<c_Array<c_Integer>>(argArrays);
    }
}