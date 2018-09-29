using System.Collections.Generic;

namespace CSSParser {
    public class StyleRule {
        public string CssText;
        public string SelectorText;
        public List<StyleDeclaration> Style = new List<StyleDeclaration>();
    }
}
