namespace FormGenerator.HtmlGenerator.Tests
{
    public class SelfClosingNodeTests
    {
        #region Self Closing Node
        [Fact]
        public void SelfClosingNodeGenerateHTML()
        {
            SelfClosingNode node = new SelfClosingNode("input");

            string html = node.GenerateHTML();
            string expectedHtml = "<input />";
            Assert.Equal(expectedHtml, html);

            node.AddAttribute("type", "text");
            html = node.GenerateHTML();
            expectedHtml = "<input type=\"text\"/>";
            Assert.Equal(expectedHtml, html);

            node.AddAttribute("class", "red");
            html = node.GenerateHTML();
            expectedHtml = "<input type=\"text\" class=\"red\"/>";
            Assert.Equal(expectedHtml, html);
        }
        #endregion
    }
}