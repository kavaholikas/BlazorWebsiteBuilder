namespace FormGenerator.HtmlGenerator
{
    public class Style
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Rule> Rules { get; private set; }

        public string ClassName => $"fg-{Name}";

        public Style(string name)
        {
            Name = name;

            Rules = new List<Rule>();
        }

        public Style AddRule(string key, string value)
        {
            Rule rule = new Rule(key, value);
            return AddRule(rule);
        }

        public Style AddRule(Rule rule)
        {
            Rule? r = Rules.Find(ru => ru.Property == rule.Property);
            if (r is not null)
            {
                r.AppendValue(rule.Value);
            }
            else
            {
                Rules.Add(rule);
            }

            return this;
        }

        public Style RemoveRule(Guid id)
        {
            Rule? rule = Rules.Find(r => r.Id == id);

            if (rule is not null)
            {
                Rules.Remove(rule);
            }

            return this;
        }

        public Style UpdateRule(Guid id, string property, string value)
        {
            Rule? rule = Rules.Find(r => r.Id == id);

            if (rule is null)
            {
                return this;
            }

            rule.Property = property;
            rule.Value = value;

            Rule? existing = Rules.Find(r => r.Id != id && r.Property == property);

            if (existing is null)
            {
                return this;
            }

            return MergeRules(rule, existing);
        }

        // TODO: Put merging in seperate helper class
        public Style MergeRules(Rule a, Rule b)
        {
            string[] bValues = b.Value.Split(" ");

            a.Value.Split(" ").ToList().ForEach(v => {
                if (!bValues.Contains(v)) {
                    b.AppendValue(v);
                }
            });

            if (Rules.Count > 0)
            {
                Rules.Remove(a);
            }

            return this;
        }

        public Style MoveRule(Guid id, bool up)
        {
            Predicate<Rule> comparer = (s) => s.Id == id;
            ListHelper.MoveListItem<Rule>(Rules, up, comparer);

            return this;
        }

        public string GenerateCSS()
        {
            return $".fg-{Name} {{ {_getRulesCSS()} }}";
        }

        private string _getRulesCSS()
        {
            return string.Join(" ", Rules.Select(r => r.GenerateCSS())).Trim();
        }
    }
}