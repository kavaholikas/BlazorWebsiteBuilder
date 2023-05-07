using System.Text.RegularExpressions;

namespace FormGenerator.HtmlGenerator
{
    public class Rule
    {
        public Guid Id { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }

        public Rule(string property, string value)
        {
            Id = Guid.NewGuid();
            Property = property;
            Value = value;
        }

        public void UpdateValue(string value)
        {
            Value = value;
        }

        public void AppendValue(string value)
        {
            string[] values = Value.Split(" ");

            if (values.Contains(value))
            {
                return;
            }

            Value = string.Join(" ", Value, value).Trim();
        }

        public void RemoveValue(string value)
        {
            Value = Value.Replace(value, "").Trim();
            Value = Regex.Replace(Value, @"\s+", " ");
        }

        public string GenerateCSS()
        {
            return $"{Property}: {Value};";
        }
    }
}