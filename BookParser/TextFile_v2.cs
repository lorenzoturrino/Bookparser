using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser
{
    class TextFile_v2
    {
        private string fileContent;
        //private wordArray;
        //private Dictionary<int, List<string>> sortedOccurrences;

        public TextFile_v2(string inputString, bool isFile = true)
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

        public string rawText
        {
            get { return fileContent; }
        }
    }
}
