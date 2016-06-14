using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookParser
{
    public class TextFile
    {
        private string FileContent;

        public TextFile(string path)
        {
            FileContent = System.IO.File
                .ReadAllText(path)
                .TrimEnd('\r', '\n');
        }

        public string RawText
        {
            get { return FileContent; }
        }

        public string[] ParsedWords()
        {
            string Pattern = @"[\W]+";
            return StringSplitter(FileContent, Pattern);
        }

        private string[] StringSplitter(string originalString, string pattern)
        {
            Regex SubstitionString = new Regex(pattern);
            string[] WordArray = SubstitionString.Split(originalString);
            string[] CleanArray = TrimEmptyValues(WordArray);
            return CleanArray;
        }

        private string[] TrimEmptyValues(string[] originalArray)
        {
            string[] CleanArray = originalArray
                .Where(value => value.Length > 0)
                .ToArray();
            return CleanArray;
        }


    }
}
