namespace FormGenerator.HtmlGenerator.Tests
{
    public class ContainerNodeTests
    {
        #region Container Node
        [Fact]
        public void ContainerNodeAddNode()
        {
            ContainerNode node = new ContainerNode("div");
            TextNode p = new TextNode("p", "Hello World");

            Assert.Empty(node.ChildNodes);

            node.AddNode(p);
            Assert.NotEmpty(node.ChildNodes);
            Assert.Equal(p, node.ChildNodes[0]);
            Assert.Equal(node, p.Parent);
        }

        [Fact]
        public void ContainerNodeRemoveNode()
        {
            ContainerNode node = new ContainerNode("div");
            TextNode p = new TextNode("p", "Hello World");

            node.AddNode(p);
            node.RemoveNode(p);

            Assert.Empty(node.ChildNodes);
        }

        [Fact]
        public void ContainerNodeRemoveNodeWithId()
        {
            ContainerNode node = new ContainerNode("div");
            TextNode p = new TextNode("p", "Hello World");

            node.AddNode(p);
            node.RemoveNode(p.Id);

            Assert.Empty(node.ChildNodes);
        }

        [Fact]
        public void ContainerNodeMoveNodeUp()
        {
            ContainerNode node = new ContainerNode("div");
            TextNode h1 = new TextNode("h1", "h1");
            TextNode h2 = new TextNode("h2", "h2");

            node.AddNode(h1).AddNode(h2);

            Assert.Equal(h1, node.ChildNodes.First());
            Assert.Equal(h2, node.ChildNodes.Last());

            node.MoveNode(h1.Id, true);
            Assert.Equal(h2, node.ChildNodes.First());
            Assert.Equal(h1, node.ChildNodes.Last());

            node.MoveNode(h1.Id, true);
            Assert.Equal(h1, node.ChildNodes.First());
            Assert.Equal(h2, node.ChildNodes.Last());
        }

        [Fact]
        public void ContainerNodeMoveNodeDown()
        {
            ContainerNode node = new ContainerNode("div");
            TextNode h1 = new TextNode("h1", "h1");
            TextNode h2 = new TextNode("h2", "h2");

            node.AddNode(h1).AddNode(h2);

            Assert.Equal(h1, node.ChildNodes.First());
            Assert.Equal(h2, node.ChildNodes.Last());

            node.MoveNode(h1.Id, false);
            Assert.Equal(h2, node.ChildNodes.First());
            Assert.Equal(h1, node.ChildNodes.Last());

            node.MoveNode(h1.Id, false);
            Assert.Equal(h1, node.ChildNodes.First());
            Assert.Equal(h2, node.ChildNodes.Last());
        }

        [Fact]
        public void ContainerNodeGenerateHTML()
        {
            ContainerNode node = new ContainerNode("div");
            
            string html = node.GenerateHTML();
            string expectedHtml = "<div ></div>";
            Assert.Equal(expectedHtml, html);

            node.AddAttribute("class", "center");
            html = node.GenerateHTML();
            expectedHtml = "<div class=\"center\"></div>";
            Assert.Equal(expectedHtml, html);

            node.AddNode(new TextNode("p", "Hello World"));
            html = node.GenerateHTML();
            expectedHtml = "<div class=\"center\"><p >Hello World</p></div>";
            Assert.Equal(expectedHtml, html);

            node.AddNode(new ContainerNode("div"));
            html = node.GenerateHTML();
            expectedHtml = "<div class=\"center\"><p >Hello World</p><div ></div></div>";
            Assert.Equal(expectedHtml, html);
        }
        #endregion
    }
}