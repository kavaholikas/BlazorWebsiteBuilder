namespace FormGenerator.HtmlGenerator.Tests
{
    public class HelperMethodTests
    {
        #region Helper Methods
        [Fact]
        public void NodeSetAlias()
        {
            Node node = new ContainerNode("div");
            node.SetAlias("TEST");

            Assert.Equal("TEST", node.Alias);
        }

        [Fact]
        public void NodeMoveListItem()
        {
            Node node = new ContainerNode("div");
            Attribute att = new Attribute("class", "red");
            Attribute att2 = new Attribute("id", "green");

            node.AddAttribute(att).AddAttribute(att2);
            node.MoveAttribute(att.Id, false);

            Assert.Equal(att, node.Attributes.Last());
            Assert.Equal(att2, node.Attributes.First());
        }

        [Fact]
        public void NodeGethPath()
        {
            ContainerNode node = new ContainerNode("div");
            node.SetAlias("Root");

            Assert.Equal("Root", node.GetPath());

            ContainerNode div = new ContainerNode("div");
            node.AddNode(div);
            Assert.Equal("Root > div", div.GetPath());

            div.SetAlias("Super DIV");
            Assert.Equal("Root > Super DIV", div.GetPath());

            div.AddNode(new TextNode("h1", "Hello World from Super DIV"));
            Assert.Equal("Root > Super DIV > h1", div.ChildNodes[0].GetPath());
        }

        [Fact]
        public void NodeSetName()
        {
            Node node = new ContainerNode("div");
            node.SetName("span");

            Assert.Equal("span", node.Name);
        }
        #endregion
    }
}