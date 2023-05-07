namespace FormGenerator.HtmlGenerator
{
    public class TextNode : Node
    {
        public string Text { get; private set; }

        public TextNode(string name, string text) : base(name)
        {
            Type = NodeType.TextNode;
            Text = text;
        }

        public override string GenerateHTML()
        {
            string html = "<{{tag}} {{attributes}}>{{text}}</{{tag}}>";
            html = html.Replace("{{tag}}", Name);
            html = html.Replace("{{attributes}}", _getAttributeHTML());
            html = html.Replace("{{text}}", Text);

            return html;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}