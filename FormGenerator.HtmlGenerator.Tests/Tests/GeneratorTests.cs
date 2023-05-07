namespace FormGenerator.HtmlGenerator.Tests
{
    public class GeneratorTests
    {
        [Fact]
        public void GeneratorConstructor()
        {
            Generator g = new Generator();

            Assert.NotNull(g);
        }

        [Fact]
        public void GeneratorGetRoot()
        {
            Generator g = new Generator();

            Node root = g.GetRoot();

            Assert.NotNull(root);
            Assert.Equal("Root", root.Alias);
            Assert.Equal("div", root.Name);

            ContainerNode rootContainer = (ContainerNode)root;

            Assert.Equal(rootContainer.ChildNodes.Count, 2);
        }

        [Fact]
        public void GeneratorGetPremadeNode()
        {
            Generator g = new Generator();

            Node node = g.GetPremadeNode(PremadeNodeGenerators.LabelInputDiv);

            Assert.NotNull(node);
        }
    }
}