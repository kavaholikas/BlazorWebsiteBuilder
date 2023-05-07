namespace FormGenerator.HtmlGenerator
{
    public class Generator
    {
        private ContainerNode _root;
        private PremadeNodeGenerator _png;

        public CssGenerator CssGenerator { get; private set; }

        public Generator()
        {
            _root = new ContainerNode("div");
            _root.SetAlias("Root");

            _png = new PremadeNodeGenerator();

            CssGenerator = new CssGenerator();

            _root.AddNode(new TextNode("h1", "Form Generator"));
            _root.AddNode(new ContainerNode("div"));
        }

        public string GenerateHTML()
        {
            string html = _root.GenerateHTML();

            string css = "<style>{{rules}}</style>";

            List<string> styles = CssGenerator.Styles.Select(s => s.GenerateCSS()).ToList();

            css = css.Replace("{{rules}}", string.Join("\n", styles));

            return $"{html}<br>{css}";
        }

        public Node GetPremadeNode(PremadeNodeGenerators png)
        {
            return _png.GetPremadeNode(png);
        }

        public Node GetRoot()
        {
            return _root;
        }

        public string ExportHTML()
        {
            string html = _root.GenerateHTML();
            return html;
        }

        public string ExportHTMLplusCSS()
        {
            
            return GenerateHTML();
        }

        public string ExportCSS()
        {
            List<string> styles = CssGenerator.Styles.Select(s => s.GenerateCSS()).ToList();

            string css = string.Join("\n", styles);
            
            return css;
        }
    }
}