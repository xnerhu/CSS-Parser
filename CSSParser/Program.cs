﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSSParser {
    class Program {
        // Useful paths
        static string AssetsPath = AppDomain.CurrentDomain.BaseDirectory + "assets/";
        static string StylesPath = AssetsPath + "styles.css";

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;

            List<StyleRule> rules = new List<StyleRule>();

            Console.ReadLine();
        }
    }
}