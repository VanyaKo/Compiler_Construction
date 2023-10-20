using System.Text;

namespace Indent
{
    public interface IStringOrList
    {
        IEnumerable<IStringOrList> GetItems();
    }

    public class StringWrapper : IStringOrList
    {
        public string Value { get; }

        public StringWrapper(string value)
        {
            Value = value;
        }

        public IEnumerable<IStringOrList> GetItems()
        {
            yield return this;
        }
    }

    public class ListWrapper : IStringOrList
    {
        public List<IStringOrList> Values { get; }

        public ListWrapper()
        {
            Values = new List<IStringOrList>();
        }

        public ListWrapper(IStringOrList value)
        {
            Values = new List<IStringOrList>
            {
                value
            };
        }

        public ListWrapper(List<IStringOrList> values)
        {
            Values = values;
        }

        public IEnumerable<IStringOrList> GetItems()
        {
            foreach (var item in Values)
            {
                yield return item;
            }
        }

        public void AddExpanding(IStringOrList sl)
        {
            foreach (var item in sl.GetItems())
            {
                Values.Add(item);
            }
        }
    }

    class Indentator
    {
        public string identator { get; set; } = "| ";

        public string Traverse(ListWrapper s)
        {
            return Traverse(s, -1);
        }

        private string Traverse(IStringOrList item, int indentLevel)
        {
            StringBuilder result = new StringBuilder();

            if (item is StringWrapper stringItem)
            {
                result.AppendLine($"{string.Join("", Enumerable.Repeat(identator, indentLevel))}{stringItem.Value}");
            }
            else if (item is ListWrapper listItem)
            {
                foreach (var child in listItem.GetItems())
                {
                    result.Append(Traverse(child, indentLevel + 1));
                }
            }

            return result.ToString();
        }
    }
}
