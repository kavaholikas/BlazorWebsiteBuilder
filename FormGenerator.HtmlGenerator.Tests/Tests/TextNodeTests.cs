namespace FormGenerator.HtmlGenerator.Tests
{
    public class TextNodeTests
    {
        #region Text Node
        [Fact]
        public void TextNodeGenerateHTML()
        {
            TextNode node = new TextNode("h1", "Lorem Ipsum");

            string html = node.GenerateHTML();
            string expected = "<h1 >Lorem Ipsum</h1>";
            Assert.Equal(expected, html);

            node.AddAttribute("class", "center");

            html = node.GenerateHTML();
            expected = "<h1 class=\"center\">Lorem Ipsum</h1>";
            Assert.Equal(expected, html);
        }

        [Fact]
        public void TextNodeSetText()
        {
            TextNode node = new TextNode("h1", "Hello World");

            node.SetText("Labas Pasauli");
            Assert.Equal("Labas Pasauli", node.Text);
        }
        #endregion
    }
}