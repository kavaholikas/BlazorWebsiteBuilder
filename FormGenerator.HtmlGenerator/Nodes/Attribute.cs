using System.Text.RegularExpressions;

namespace FormGenerator.HtmlGenerator
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsStandalone { get; set; }

        public Attribute(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            IsStandalone = false;
        }

        public Attribute(string key)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = string.Empty;
            IsStandalone = true;
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

        public void ToggleStandalone(bool isStandalone)
        {
            if (isStandalone)
            {
                Value = string.Empty;
            }

            IsStandalone = isStandalone;
        }

        public string GenerateHTML()
        {
            return IsStandalone switch
            {
                true => $"{Key}",
                false => $"{Key}=\"{Value}\""
            };
        }
    }
}