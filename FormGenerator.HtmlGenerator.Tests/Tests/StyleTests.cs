namespace FormGenerator.HtmlGenerator.Tests
{
    public class StyleTests
    {
        [Fact]
        public void StyleConstructor()
        {
            Style style = new Style("red");

            Guid guid;
            Assert.True(Guid.TryParse(style.Id.ToString(), out guid));
            Assert.Equal("red", style.Name);
            Assert.NotNull(style.Rules);
            Assert.Equal("fg-red", style.ClassName);
        }

        [Fact]
        public void StyleAddRuleWithKeyAndValue()
        {
            Style style = new Style("red");

            Assert.Empty(style.Rules);
            style.AddRule("color", "red");

            Assert.NotEmpty(style.Rules);
            Assert.Equal("color", style.Rules.First().Property);
            Assert.Equal("red", style.Rules.First().Value);
        }

        [Fact]
        public void StyleAddRuleWithObject()
        {
            Style style = new Style("red");

            Rule rule = new Rule("color", "red");
            style.AddRule(rule);

            Assert.NotEmpty(style.Rules);
            Assert.Equal(rule.Property, style.Rules.First().Property);
            Assert.Equal(rule.Value, style.Rules.First().Value);
            Assert.Equal(rule.Id, style.Rules.First().Id);
        }

        [Fact]
        public void StyleAppendValueToExistingRule()
        {
            Style style = new Style("red");
            style.AddRule("color", "dark");

            style.AddRule("color", "red");

            Assert.Equal("dark red", style.Rules.First().Value);
        }

        [Fact]
        public void StyleRemoveRule()
        {
            Style style = new Style("red");
            Rule rule = new Rule("color", "red");

            style.AddRule(rule);
            style.RemoveRule(rule.Id);

            Assert.Empty(style.Rules);
        }

        [Fact]
        public void StyleUpdateRule()
        {
            Style style = new Style("green");
            Rule rule = new Rule("color", "red");

            style.AddRule(rule);
            style.UpdateRule(rule.Id, "color", "green");

            Assert.NotEmpty(style.Rules);
            Assert.Equal("color", style.Rules.First().Property);
            Assert.Equal("green", style.Rules.First().Value);

            style.UpdateRule(rule.Id, "color", "black jet");
            Assert.Equal("black jet", style.Rules.First().Value);
        }

        [Fact]
        public void StyleMergeRules()
        {
            Style style = new Style("red");
            Rule ruleOne = new Rule("color", "red");
            Rule ruleTwo = new Rule("font", "jet");

            style.AddRule(ruleOne);
            style.AddRule(ruleTwo);

            Assert.Equal(2, style.Rules.Count);
            style.MergeRules(ruleTwo, ruleOne);
            
            Assert.Equal(1, style.Rules.Count);
            Assert.Equal("color", style.Rules.First().Property);
            Assert.Equal("red jet", style.Rules.First().Value);
        }

        [Fact]
        public void StyleGenerateCSS()
        {
            Style style = new Style("center");

            style.AddRule("text-align", "center");

            string css = style.GenerateCSS();
            Assert.Equal(".fg-center { text-align: center; }", css);

            style.AddRule("text-align", "red");
            css = style.GenerateCSS();
            Assert.Equal(".fg-center { text-align: center red; }", css);

            style.AddRule("font-weight", "12px");
            css = style.GenerateCSS();
            Assert.Equal(".fg-center { text-align: center red; font-weight: 12px; }", css);
        }
    }
}