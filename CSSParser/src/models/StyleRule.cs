using System.Collections.Generic;

namespace CSSParser {
    public class StyleRule {
        public string CssText;
        public string SelectorText;
        public List<CSSValue> Style = new List<CSSValue>();
    }

    public class CSSValue { // TODO
        public string Property;
        public string Value;
    }
}
