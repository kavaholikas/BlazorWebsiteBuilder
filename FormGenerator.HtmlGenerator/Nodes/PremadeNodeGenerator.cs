namespace FormGenerator.HtmlGenerator
{
    public class PremadeNodeGenerator
    {
        public Dictionary<PremadeNodeGenerators, Func<Node>> Generators;


        public PremadeNodeGenerator()
        {
            Generators = new Dictionary<PremadeNodeGenerators, Func<Node>>();

            Generators.Add(PremadeNodeGenerators.LabelInputDiv, LabelInputDiv);
            Generators.Add(PremadeNodeGenerators.SubmitButton, SubmitButton);
        }

        public Node GetPremadeNode(PremadeNodeGenerators png)
        {
            return Generators[png]();
        }

        private ContainerNode LabelInputDiv()
        {
            ContainerNode node = new ContainerNode("div");
            node.AddNode(new TextNode("label", "value")).AddNode(new SelfClosingNode("input"));

            return node;
        }

        private SelfClosingNode SubmitButton()
        {
            SelfClosingNode node = new SelfClosingNode("input");
            node.AddAttribute("type", "submit").AddAttribute("value", "submit");

            return node;
        }
    }

    public enum PremadeNodeGenerators
    {
        LabelInputDiv,
        SubmitButton
    }
}