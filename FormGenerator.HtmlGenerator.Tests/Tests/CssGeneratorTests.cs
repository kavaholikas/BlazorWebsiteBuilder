namespace FormGenerator.HtmlGenerator.Tests
{
    public class CssGeneratorTests
    {
        [Fact]
        public void CssGeneratorConstructor()
        {
            CssGenerator css = new CssGenerator();

            Assert.Empty(css.Styles);
        }

        [Fact]
        public void CssGeneratorAddStyleWithName()
        {
            CssGenerator css = new CssGenerator();
            css.AddStyle("center");

            Assert.Equal(1, css.Styles.Count);
            Assert.Equal("center", css.Styles.First().Name);

            css.AddStyle("red");
            Assert.Equal(2, css.Styles.Count);
            Assert.Equal("red", css.Styles.Last().Name);
        }

        [Fact]
        public void CssGeneratorAddStyleWithObject()
        {
            CssGenerator css = new CssGenerator();
            Style style = new Style("center");

            css.AddStyle(style);
            Assert.Equal(1, css.Styles.Count);
            Assert.Equal(style.Name, css.Styles.First().Name);

            Style styleTwo = new Style("red");
            css.AddStyle(styleTwo);
            Assert.Equal(2, css.Styles.Count);
            Assert.Equal(styleTwo.Name, css.Styles.Last().Name);
        }

        [Fact]
        public void CssGeneratorRemoveStyleWithId()
        {
            CssGenerator css = new CssGenerator();
            css.AddStyle("red");

            css.RemoveStyle(css.Styles.First().Id);
            Assert.Empty(css.Styles);
        }

        [Fact]
        public void CssGeneratorRemoveStyleWithObject()
        {
            CssGenerator css = new CssGenerator();
            Style style = new Style("red");
            css.AddStyle(style);

            css.RemoveStyle(style);
            Assert.Empty(css.Styles);
        }
    }
}