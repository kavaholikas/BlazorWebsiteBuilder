namespace FormGenerator.HtmlGenerator
{
    public class SelfClosingNode : Node
    {
        public SelfClosingNode(string name) : base(name)
        {
            Type = NodeType.SelfClosingNode;
        }

        public override string GenerateHTML()
        {
            string html = "<{{tag}} {{attributes}}/>";
            html = html.Replace("{{tag}}", Name);
            html = html.Replace("{{attributes}}", _getAttributeHTML());

            return html;
        }
    }
}