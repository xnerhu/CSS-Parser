using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSSParser {
    class Program {
        // Useful paths
        static string AssetsPath = AppDomain.CurrentDomain.BaseDirectory + "assets/";
        static string StylesPath = AssetsPath + "styles.css";

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;

            string source = File.ReadAllText(StylesPath, Encoding.UTF8);
            List<StyleRule> rules = CSSParser.Parse(source);

            Printer.PrintRules(rules);

            Console.ReadLine();
        }
    }
}
