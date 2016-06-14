using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookParser
{
    public class TextFile
    {
        private string fileContent;

        public TextFile(string path)
        {
            fileContent = System.IO.File
                .ReadAllText(path)
                .TrimEnd('\r', '\n');
        }

        public string rawText
        {
            get { return fileContent; }
        }

        public string[] ParsedWords()
        {
            string pattern = @"[\W]+";
            return StringSplitter(fileContent, pattern);
        }

        private string[] StringSplitter(string originalString, string pattern)
        {
            Regex substitionString = new Regex(pattern);
            string[] wordArray = substitionString.Split(originalString);
            string[] cleanArray = TrimEmptyValues(wordArray);
            return cleanArray;
        }

        private string[] TrimEmptyValues(string[] originalArray)
        {
            string[] cleanArray = originalArray
                .Where(value => value.Length > 0)
                .ToArray();
            return cleanArray;
        }


    }
}
