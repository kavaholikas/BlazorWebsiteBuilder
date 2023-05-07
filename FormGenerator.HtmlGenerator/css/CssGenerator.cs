namespace FormGenerator.HtmlGenerator
{
    public class CssGenerator
    {
        public List<Style> Styles { get; private set; }

        public CssGenerator()
        {
            Styles = new List<Style>();
        }

        public void AddStyle(string name)
        {
            Style style = new Style(name);
            AddStyle(style);
        }

        public void AddStyle(Style style)
        {
            if (Styles.Find(s => s.Name == style.Name) is null)
            {
                Styles.Add(style);
            }
        }


        public void RemoveStyle(Guid id)
        {
            Style? style = Styles.Find(s => s.Id == id);

            if (style is not null)
            {
                RemoveStyle(style);
            }
        }

        public void RemoveStyle(Style style)
        {
            Styles.Remove(style);
        }

        public void AddRule(Guid id, string key, string value)
        {
            Style? style = Styles.Find(s => s.Id == id);

            if (style is null)
            {
                return;
            }

            style.AddRule(key, value);
        }
    }
}