using System.Collections.Generic;

namespace CSSParser {
    public static class CSSParser {
        /// <summary>
        /// Parses source code into a list of style-rules
        /// </summary>
        public static List<StyleRule> Parse(string source) {
            List<StyleRule> rules = new List<StyleRule>();
            StyleRule rule = new StyleRule();
            StyleDeclaration declaration = new StyleDeclaration();
            bool insideBrackets = false;
            bool capturingProperty = true;
           
            for (int i = 0; i < source.Length; i++) {
                if (source[i] == '{') {
                    rule.SelectorText = rule.SelectorText.Trim();
                    insideBrackets = true;
                } else if (source[i] == '}') {
                    rules.Add(rule);

                    rule = new StyleRule();
                    insideBrackets = false;
                    capturingProperty = true;
                } else if (insideBrackets) {
                    if (source[i] == ':') {
                        capturingProperty = false;
                    } else if (source[i] == ';') {
                        declaration.Property = declaration.Property.Trim();
                        declaration.Value = declaration.Value.Trim();
                        rule.Style.Add(declaration);

                        declaration = new StyleDeclaration();
                        capturingProperty = true;
                    } else {
                        if (capturingProperty) {
                            declaration.Property += source[i];
                        } else {
                            declaration.Value += source[i];
                        }
                    }
                } else {
                    rule.SelectorText += source[i];
                }
            }

            return rules;
        }
    }
}
