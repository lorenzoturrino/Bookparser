using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookParser
{
    public class TextFile_v2
    {
        private string fileContent;
        private string[] parsedWordsArray;
        //private Dictionary<int, List<string>> sortedOccurrences;

        public TextFile_v2(string inputString, bool isFile = true)
        {
            readText(inputString, isFile);
            populateWordArray();
        }

        public string rawText
        {
            get { return fileContent; }
        }

        public string[] parsedWords
        {
            get { return parsedWordsArray; }
        }

        private void readText(string inputString, bool isFile)
        {
            if (isFile)
            {
                fileContent = System.IO.File
                .ReadAllText(inputString)
                .TrimEnd('\r', '\n');
            }
            else
            {
                fileContent = inputString;
            }
        }

        private void populateWordArray()
        {
            Regex splitChars = new Regex(@"[\W_]+");
            parsedWordsArray = splitChars
                .Split(fileContent)
                .Where(value => value.Length > 0)
                .ToArray();
        }
    }
}
