namespace FormGenerator.HtmlGenerator.Tests
{
    public class PremadeNodeGeneratorTests
    {
        [Fact]
        public void PremadeNodeGeneratorConstructor()
        {
            PremadeNodeGenerator png =  new PremadeNodeGenerator();

            Assert.NotEmpty(png.Generators);
            Assert.Equal(Enum.GetValues(typeof(PremadeNodeGenerators)).Length, png.Generators.Count);
        }

        [Fact]
        public void PremadeNodeGeneratorGetPremadeNode()
        {
            PremadeNodeGenerator png = new PremadeNodeGenerator();

            Node node = png.GetPremadeNode(PremadeNodeGenerators.LabelInputDiv);
            Assert.NotNull(node);
        }
    }
}