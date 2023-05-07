namespace FormGenerator.HtmlGenerator.Tests
{
    public class NodeStyleMethodTests
    {
        [Fact]
        public void NodeAddStyle()
        {
            Node node = new ContainerNode("div");
            Style style = new Style("red");
            node.AddStyle(style);

            Assert.NotEmpty(node.Styles);
            Assert.Equal("red", node.Styles.First().Name);
        }

        [Fact]
        public void NodeRemoveStyle()
        {
            Node node = new ContainerNode("div");
            Style style = new Style("red");

            node.AddStyle(style);
            Assert.NotEmpty(node.Styles);

            node.RemoveStyle(style.Id);
            Assert.Empty(node.Styles);
        }
    }
}
