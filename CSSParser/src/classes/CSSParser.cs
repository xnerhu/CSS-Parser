using System;
using System.Collections.Generic;

namespace CSSParser {
    public static class CSSParser {
        public static List<StyleRule> Parse(string source) {
            List<StyleRule> rules = new List<StyleRule>();
            bool insideBrackets = false;
            bool capturingProperty = true;
            string property = "";
            string value = "";

            StyleRule rule = new StyleRule();
  
            for (int i = 0; i < source.Length; i++) {
                if (source[i] == '{' && !insideBrackets) {
                    insideBrackets = true;
                    continue;
                } else if (source[i] == '}' && insideBrackets) {
                    rule.SelectorText = rule.SelectorText.Trim();

                    rules.Add(rule);
                    rule = new StyleRule();

                    insideBrackets = false;
                    break;
                }

                if (!insideBrackets) {
                    rule.SelectorText += source[i];
                } else { 
                    if (capturingProperty && source[i] == ':') {
                        capturingProperty = false;
                        continue;
                    } else if (!capturingProperty && source[i] == ';') {
                        property = property.Trim().ToLower();
                        value = value.Trim();

                        if (property == "background-color") {
                            rule.Style.BackgroundColor = value;
                        } else if (property == "height") {
                            rule.Style.Height = value;
                        } else if (property == "width") {
                            rule.Style.Width = value;
                        }

                        property = "";
                        value = "";
                        capturingProperty = true;
                        continue;
                    }

                    if (capturingProperty) {
                        property += source[i];
                    } else {
                        value += source[i];
                    }
                }
            }

            return rules;
        }
    }
}
