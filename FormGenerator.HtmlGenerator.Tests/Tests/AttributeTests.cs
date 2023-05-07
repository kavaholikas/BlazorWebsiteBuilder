namespace FormGenerator.HtmlGenerator.Tests
{
    public class AttributeTests
    {
        #region Attribute
        [Fact]
        public void AttributeConstructorWithKeyAndValue()
        {
            Attribute att = new Attribute("class", "center");

            Assert.NotNull(att);
            Guid guid;
            Assert.True(Guid.TryParse(att.Id.ToString(), out guid));
            Assert.Equal("class", att.Key);
            Assert.Equal("center", att.Value);
            Assert.False(att.IsStandalone);
        }

        [Fact]
        public void AttributeConstructorStandalone()
        {
            Attribute att = new Attribute("disabled");

            Assert.NotNull(att);
            Guid guid;
            Assert.True(Guid.TryParse(att.Id.ToString(), out guid));
            Assert.Equal("disabled", att.Key);
            Assert.True(att.IsStandalone);
        }

        [Fact]
        public void AttributeAppendValue()
        {
            Attribute att = new Attribute("class", "center");
            att.AppendValue("red");

            Assert.Equal("class", att.Key);
            Assert.Equal("center red", att.Value);

            att.AppendValue("red");
            Assert.Equal("center red", att.Value);

            att.AppendValue("ent");
            Assert.Equal("center red ent", att.Value);

        }

        [Fact]
        public void AttribuveRemoveValue()
        {
            Attribute att = new Attribute("class", "center");
            att.AppendValue("red");

            Assert.Equal("class", att.Key);
            Assert.Equal("center red", att.Value);

            att.RemoveValue("center");
            Assert.Equal("red", att.Value);

            att.RemoveValue("red");
            Assert.Equal("", att.Value);

            att.AppendValue("red");
            att.AppendValue("center");
            Assert.Equal("red center", att.Value);

            att.RemoveValue("center");
            Assert.Equal("red", att.Value);

            att.RemoveValue("Hello World");
            Assert.Equal("red", att.Value);
        }

        [Fact]
        public void AttributeGenerateHTMLIsNotStandalone()
        {
            Attribute att = new Attribute("class", "red");
            string html = att.GenerateHTML();
            
            Assert.Equal("class=\"red\"", html);
        }

        [Fact]
        public void AttributeGenerateHTMLIsStandalone()
        {
            Attribute att = new Attribute("disabled");
            string html = att.GenerateHTML();
            Assert.Equal("disabled", html);
        }

        [Fact]
        public void AttribueToggleIsStandalone()
        {
            Attribute att = new Attribute("class", "red");
            att.ToggleStandalone(true);

            Assert.True(att.IsStandalone);
            Assert.Equal(string.Empty, att.Value);
        }
        #endregion
    }
}