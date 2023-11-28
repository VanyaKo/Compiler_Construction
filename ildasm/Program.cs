void main()
{

}

// class Dummy
// {
//     int a;
// }

class value
{
    private int[] items;

    value(int n)
    {
        items = new int[n];
    }

    int get(int i)
    {
        return items[i];
    }

    void set(int i, int v)
    {
        items[i] = v;
    }

    void lol(value v)
    {
        v.get(32);
    }
}