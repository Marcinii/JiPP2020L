using System;
using System.Collections.Generic;
using System.IO;

namespace Project_7
{
    public class textFile : iCzytnik
    {
        public string Name => "Text File";
        public List<string> whatToCount => new List<string>()
        {
        "Words",
        "Characters"
        };

        public int Przelicz(string option, string path)
        {
            if (option == "Characters")
            {
                string Text = File.ReadAllText(path);
                return Text.Length;
            }
            else
            {
                string Text = File.ReadAllText(path);
                var str = Text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return str.Length;
            }
        }
    }
}
