namespace FormGenerator.HtmlGenerator
{
    public abstract class Node 
    {
        public Guid Id { get; protected set; }
        public NodeType Type { get; protected set; }
        public string Name { get; protected set; } 
        public string Alias { get; protected set; }

        public List<Attribute> Attributes { get; private set; }
        public List<Style> Styles { get; set; }

        public Node? Parent { get; private set; }

        public Node(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Alias = name;

            Attributes = new List<Attribute>();
            Styles = new List<Style>();

            Parent = null;
        }

        public abstract string GenerateHTML();

        // TODO: Update Tests
        protected string _getAttributeHTML()
        {
            List<Attribute> styleAttributes = new List<Attribute>();

            foreach (Style style in Styles)
            {
                Attribute att = new Attribute("class", style.ClassName);
                styleAttributes.Add(att);
                Attributes.Add(att);
            }

            List<string> attributes = Attributes.Select(attribute => attribute.GenerateHTML()).ToList<string>();

            foreach (Attribute att in styleAttributes)
            {
                Attributes.Remove(att);   
            }

            return string.Join(" ", attributes);
        }

        #region Attribute Managment
        public Node AddAttribute(string key, string value)
        {
            Attribute attribute = new Attribute(key, value);
            AddAttribute(attribute);

            return this;
        }

        public Node AddAttribute(string key)
        {
            Attribute attribute = new Attribute(key);
            AddAttribute(attribute);

            return this;
        }

        public Node AddAttribute(Attribute attribute)
        {
            Attribute? att = Attributes.Find(a => a.Key == attribute.Key);

            if (att is null)
            {
                Attributes.Add(attribute);
            }
            else
            {
                att.AppendValue(attribute.Value);
            }

            return this;
        }

        public Node RemoveAttribute(string key)
        {
            Attribute? att = Attributes.Find(a => a.Key == key);

            if (att is not null)
            {
                Attributes.Remove(att);
            }

            return this;
        }

        public Node RemoveAttribute(Attribute attribute)
        {
            Attributes.Remove(attribute);

            return this;
        }

        public Node RemoveAttributeValue(string key, string value)
        {
            Attribute? att = Attributes.Find(a => a.Key == key);
        
            if (att is not null)
            {
                att.RemoveValue(value);
            }

            return this;
        }

        public Node RemoveAttributeValue(Attribute attribute)
        {
            Attribute? att = Attributes.Find(a => a.Key == attribute.Key);

            if (att is not null)
            {
                att.RemoveValue(attribute.Value);
            }

            return this;
        }

        public Node UpdateAttribute(Guid id, string key, string value, bool isStandalone)
        {
            Attribute? att = Attributes.Find(a => a.Id == id);

            if (att is null)
            {
                return this;
            }

            att.Key = key;
            att.Value = value;

            if (att.IsStandalone != isStandalone)
            {
                att.ToggleStandalone(isStandalone);
            }
            
            Attribute? existing = Attributes.Find(a => a.Id != id && a.Key == att.Key);

            if (existing is null)
            {
                return this;
            }

            return MergeAttributes(att, existing);
        }

        public Node MergeAttributes(Attribute a, Attribute b)
        {
            if (a.IsStandalone && !b.IsStandalone)
            {
                b.Value = string.Empty;
                b.IsStandalone = true;

                Attributes.Remove(a);
                return this;
            }

            string[] bValues = b.Value.Split(" ");

            a.Value.Split(" ").ToList().ForEach(v => {
               if (!bValues.Contains(v)) 
               {
                    b.AppendValue(v);
               }
            });

            if (Attributes.Count > 0)
            {
                Attributes.Remove(a);
            }

            return this;
        }

        public Node MoveAttribute(Guid id, bool up)
        {
            Predicate<Attribute> comparer = (a) => a.Id == id;
            ListHelper.MoveListItem<Attribute>(Attributes, up, comparer);

            return this;
        }
        #endregion

        #region Style Managment
        public Node AddStyle(Style style)
        {
            Styles.Add(style);

            return this;
        }

        public Node RemoveStyle(Guid id)
        {
            Style? style = Styles.Find(s => s.Id == id);

            if (style is not null)
            {
                Styles.Remove(style);
            }

            return this;
        }
        #endregion

        #region Helpers
        public void SetAlias(string alias)
        {
            Alias = alias;
        }

        public void SetParent(Node node)
        {
            Parent = node;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetPath()
        {
            string prefix = Parent is null? string.Empty: $"{Parent.GetPath()} > ";

            return prefix + Alias;
        }
        #endregion
    }
}