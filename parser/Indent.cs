using System.Text;

namespace Indent
{
    public interface IStringOrList {}

    public class StringWrapper : IStringOrList
    {
        public string Value { get; }

        public StringWrapper(string value)
        {
            Value = value;
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
    }

    class Indentator
    {
        public string identator { get; set; } = "    ";

        public string Traverse(ListWrapper s)
        {
            return Traverse(s, -1);
        }

        private string Traverse(IStringOrList item, int indentLevel)
        {
            StringBuilder result = new StringBuilder();

            if (item is StringWrapper stringItem)
            {
                result.AppendLine($"{new string(' ', indentLevel * identator.Length)}{stringItem.Value}");
            }
            else if (item is ListWrapper listItem)
            {
                foreach (var child in listItem.Values)
                {
                    result.Append(Traverse(child, indentLevel + 1));
                }
            }

            return result.ToString();
        }
    }
}