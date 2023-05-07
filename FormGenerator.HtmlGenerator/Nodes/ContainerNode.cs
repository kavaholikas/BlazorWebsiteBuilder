namespace FormGenerator.HtmlGenerator
{
    public class ContainerNode : Node
    {
        public List<Node> ChildNodes { get; set; }

        public ContainerNode(string name) : base(name)
        {
            Type = NodeType.ContainerNode;
            ChildNodes = new List<Node>();
        }

        public ContainerNode AddNode(Node node)
        {
            ChildNodes.Add(node);
            node.SetParent(this);

            return this;
        }

        public ContainerNode RemoveNode(Guid id)
        {
            Node? node = ChildNodes.Find(n => n.Id == id);
            if (node is not null)
            {
                ChildNodes.Remove(node);
            }

            return this;
        }

        public ContainerNode RemoveNode(Node node)
        {
            ChildNodes.Remove(node);

            return this;
        }

        public ContainerNode MoveNode(Guid id, bool up)
        {
            Predicate<Node> comparer = (n) => n.Id == id; 
            ListHelper.MoveListItem<Node>(ChildNodes, up, comparer);

            return this;
        }

        public override string GenerateHTML()
        {
            string html = "<{{tag}} {{attributes}}>{{childNodeHTML}}</{{tag}}>";
            html = html.Replace("{{tag}}", Name);
            html = html.Replace("{{attributes}}", _getAttributeHTML());
            html = html.Replace("{{childNodeHTML}}", _getChildNodeHTML());

            return html;
        }

        private string _getChildNodeHTML()
        {
            List<string> childNodes = ChildNodes.Select(node => node.GenerateHTML()).ToList<string>();
            return string.Join("", childNodes);
        }
    }
}