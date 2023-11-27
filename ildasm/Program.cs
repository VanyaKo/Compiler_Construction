void main()
{

}

// class Dummy
// {
//     int a;
// }

class Array<T>
{
    private int length;
    private T[] items;

    Array(int n)
    {
        items = new T[n];
    }

    int len()
    {
        return length;
    }

    T get(int i)
    {
        return items[i];
    }

    void set(int i, T v)
    {
        items[i] = v;
    }
}