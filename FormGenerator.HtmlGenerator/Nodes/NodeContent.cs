namespace FormGenerator.HtmlGenerator
{
    public class NodeContent
    {
        public NodeType Type { get; set; }
        public List<Node>? ChildNodes { get; set; }
        public string? Text { get; set; }
    }
}