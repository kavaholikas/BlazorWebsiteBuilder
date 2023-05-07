namespace FormGenerator.HtmlGenerator.Tests
{
    public class ConstructorTests
    {
        #region Constructors
        [Fact]
        public void NodeBaseConstructor()
        {
            ContainerNode node = new ContainerNode("div");

            Assert.NotNull(node);
            Guid guid;
            Assert.True(Guid.TryParse(node.Id.ToString(), out guid));
            Assert.Equal("div", node.Name);
            Assert.Equal("div", node.Alias);
            Assert.Equal(null, node.Parent);
        }

        [Fact]
        public void ContainerNodeConstructor()
        {
            ContainerNode node = new ContainerNode("div");

            Assert.Empty(node.ChildNodes);
            Assert.Equal(NodeType.ContainerNode, node.Type);
        }

        [Fact]
        public void TextNodeConstructor()
        {
            TextNode node = new TextNode("h1", "Hello World");

            Assert.Equal("Hello World", node.Text);
            Assert.Equal(NodeType.TextNode, node.Type);
        }

        [Fact]
        public void SelfClosingNodeConstructor()
        {
            SelfClosingNode node = new SelfClosingNode("input");

            Assert.Equal("input", node.Name);
            Assert.Equal(NodeType.SelfClosingNode, node.Type);
        }
        #endregion
    }
}