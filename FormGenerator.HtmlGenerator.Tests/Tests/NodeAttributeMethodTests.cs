namespace FormGenerator.HtmlGenerator.Tests
{
    public class NodeAttributeMethodTests
    {
        #region Node Add/Remove Attributes
        [Fact]
        public void AddAttributeWithKeyAndValue()
        {
            ContainerNode node = new ContainerNode("div");

            node.AddAttribute("class", "center");

            Assert.NotEmpty(node.Attributes);
            Assert.Equal("class", node.Attributes[0].Key);
            Assert.Equal("center", node.Attributes[0].Value);
        }

        [Fact]
        public void AddAttributeWithObject()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("class", "center");

            node.AddAttribute(att);

            Assert.NotEmpty(node.Attributes);
            Assert.Equal("class", node.Attributes[0].Key);
            Assert.Equal("center", node.Attributes[0].Value);
        }

        [Fact]
        public void AddAttributeStandalone()
        {
            ContainerNode node = new ContainerNode("div");

            node.AddAttribute("disabled");

            Assert.NotEmpty(node.Attributes);
            Assert.Equal("disabled", node.Attributes[0].Key);
            Assert.Equal(string.Empty, node.Attributes[0].Value);
            Assert.True(node.Attributes[0].IsStandalone);
        }

        [Fact]
        public void RemoveAttributeWithKey()
        {
            Node node = new ContainerNode("div").AddAttribute("class", "red");

            node.RemoveAttribute("class");

            Assert.Empty(node.Attributes);
        }

        [Fact]
        public void RemoveAttributeWithObject()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("class", "red");

            node.AddAttribute(att);
            node.RemoveAttribute(att);

            Assert.Empty(node.Attributes);
        }

        [Fact]
        public void RemoveAttributeValueWithKeyAndValue()
        {
            ContainerNode node = new ContainerNode("div");
            node.AddAttribute("class", "center");
            node.AddAttribute("class", "red");

            Assert.Equal("center red", node.Attributes[0].Value);

            node.RemoveAttributeValue("class", "red");
            Assert.Equal("center", node.Attributes[0].Value);
        }
        [Fact]
        public void RemoveAttributeValueWithObject()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("class", "red");
            Attribute att2 = new Attribute("class", "center");

            node.AddAttribute(att).AddAttribute(att2);
            node.RemoveAttributeValue(att2);

            Assert.Equal("red", node.Attributes[0].Value);
        }

        [Fact]
        public void UpdateAttribute()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("class", "red");

            node.AddAttribute(att);
            node.UpdateAttribute(att.Id, "class", "green", false);

            Assert.Equal("class", att.Key);
            Assert.Equal("green", att.Value);
            Assert.Equal(att, node.Attributes.First());

            node.AddAttribute("class", "red");
            Assert.Equal("green red", att.Value);

            Attribute att2 = new Attribute("id", "green apple");
            node.AddAttribute(att2);
            Assert.Equal(2, node.Attributes.Count);

            node.UpdateAttribute(att2.Id, "class", "green apple", false);
            Assert.Equal("green red apple", att.Value);
            Assert.Equal(1, node.Attributes.Count);
        }

        [Fact]
        public void UpdateAttributeIsStandalone()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("class", "no");

            node.AddAttribute(att);

            node.UpdateAttribute(att.Id, "disabled", "", true);
            Assert.Equal("disabled", att.Key);
            Assert.Equal(string.Empty, att.Value);
            Assert.True(att.IsStandalone);
        }

        [Fact]
        public void MergeAttributes()
        {
            TextNode node = new TextNode("p", "Hello World");
            Attribute att = new Attribute("class", "red");
            Attribute att2 = new Attribute("id", "green");

            node.AddAttribute(att);
            node.AddAttribute(att2);
            Assert.Equal(2, node.Attributes.Count);

            node.MergeAttributes(att2, att);
            Assert.Equal(1, node.Attributes.Count);
            Assert.Equal("red green", node.Attributes.First().Value);

            Attribute att3 = new Attribute("stuff", "ree");
            node.AddAttribute(att3);
            node.MergeAttributes(att3, att);

            Assert.Equal("red green ree", att.Value);
        }

        [Fact]
        public void MoveAttributeDown()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("1", "one");
            Attribute att2 = new Attribute("2", "two");

            node.AddAttribute(att).AddAttribute(att2);

            node.MoveAttribute(att.Id, false);
            Assert.Equal(att2, node.Attributes.First());
            Assert.Equal(att, node.Attributes.Last());

            node.MoveAttribute(att.Id, false);
            Assert.Equal(att, node.Attributes.First());
            Assert.Equal(att2, node.Attributes.Last());
        }

        [Fact]
        public void MoveAttributeUp()
        {
            ContainerNode node = new ContainerNode("div");
            Attribute att = new Attribute("1", "one");
            Attribute att2 = new Attribute("2", "two");

            node.AddAttribute(att).AddAttribute(att2);

            node.MoveAttribute(att.Id, true);
            Assert.Equal(att2, node.Attributes.First());
            Assert.Equal(att, node.Attributes.Last());

            node.MoveAttribute(att.Id, true);
            Assert.Equal(att, node.Attributes.First());
            Assert.Equal(att2, node.Attributes.Last());
        }
        #endregion
    }
}