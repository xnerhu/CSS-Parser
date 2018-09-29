using System.Collections.Generic;

namespace CSSParser {
    public class StyleSheet {
        public string Href;
        public List<StyleRule> Rules = new List<StyleRule>();
    }
}
