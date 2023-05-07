namespace FormGenerator.HtmlGenerator.Tests
{
    public class RuleTests
    {
        [Fact]
        public void RuleConstructor()
        {
            Rule rule = new Rule("color", "red");

            Guid guid;
            Assert.True(Guid.TryParse(rule.Id.ToString(), out guid));
            Assert.Equal("color", rule.Property);
            Assert.Equal("red", rule.Value);
        }

        [Fact]
        public void RuleUpdateValue()
        {
            Rule rule = new Rule("color", "red");

            rule.UpdateValue("green");
            Assert.Equal("green", rule.Value);
        }

        [Fact]
        public void RuleAppendValue()
        {
            Rule rule = new Rule("color", "red");

            rule.AppendValue("green");
            Assert.Equal("red green", rule.Value);

            rule.AppendValue("jet");
            Assert.Equal("red green jet", rule.Value);
        }

        [Fact]
        public void RuleRemoveValue()
        {
            Rule rule = new Rule("color", "red");

            rule.RemoveValue("red");
            Assert.Equal("", rule.Value);

            rule.AppendValue("red");
            rule.AppendValue("green");
            rule.AppendValue("jet");

            rule.RemoveValue("green");
            Assert.Equal("red jet", rule.Value);
        }

        [Fact]
        public void RuleGenerateCSS()
        {
            Rule rule = new Rule("color", "red");

            string css = rule.GenerateCSS();

            Assert.Equal("color: red;", css);
        }
    }
}