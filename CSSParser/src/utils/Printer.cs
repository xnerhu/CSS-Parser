using System;
using System.Collections.Generic;
namespace CSSParser {
    public static class Printer {
        public static void PrintRules(List<StyleRule> rules) {
            foreach (StyleRule rule in rules) {
                PrintColored(rule.SelectorText, DefaultColors.Selector, true);
                PrintColored(" {\n", DefaultColors.Bracket, true);

                foreach (StyleDeclaration declaration in rule.Style) {
                    PrintColored(new string(' ', 4) + declaration.Property, DefaultColors.Property, true);
                    PrintColored(": ", DefaultColors.Semicolon, true);
                    PrintColored(declaration.Value, DefaultColors.Value, true);
                    PrintColored(";\n", DefaultColors.Semicolon, true);
                }

                PrintColored("}\n\n", DefaultColors.Bracket, true);
            }
        }
        private static void PrintColored(string text, ConsoleColor color, bool inline = false) {
            Console.ForegroundColor = color;
            if (!inline) Console.WriteLine(text);
            else Console.Write(text);
        }
    }
}