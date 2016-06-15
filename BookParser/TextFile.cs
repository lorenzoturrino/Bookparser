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

        public TextFile(string inputString, bool isFile = true)
        {
            if(isFile)
            {
                fileContent = System.IO.File
                .ReadAllText(inputString)
                .TrimEnd('\r', '\n');
            } else
            {
                fileContent = inputString;
            }
            
        }

        public string rawText
        {
            get { return fileContent; }
        }

        public string[] ParsedWords()
        {
            string pattern = @"[\W_]+";
            return StringSplitter(fileContent, pattern);
        }

        public Dictionary<string, int> CountOccurrences()
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            string[] parsedWords = ParsedWords();
            foreach (string entry in parsedWords)
            {
                string lowerEntry = entry.ToLower();
                if (occurrences.ContainsKey(lowerEntry))
                    occurrences[lowerEntry] += 1;
                else
                    occurrences[lowerEntry] = 1;
            }
            return occurrences;
        }

        //public Dictionary<int,string[]> SortOccurrencesByNumber()
        //{
        //    Dictionary<int, string[]> occurrences = new Dictionary<int, string[]>();

        //    foreach(KeyValuePair<string,int> entry in CountOccurrences())
        //    {
        //        if (occurrences.ContainsKey(entry.Value))
        //            Array.add
        //        else
        //            occurrences[entry.Value] = new string[];
        //    }

        //    return occurrences;
        //}

        public Dictionary<int,List<string>> SortOccurrencesByNumber()
        {
            Dictionary<int, List<string>> occurrences = new Dictionary<int, List<string>>();
            foreach (KeyValuePair<string,int> entry in CountOccurrences())
            {
                Console.WriteLine("entry" + entry.Key + "<>" + entry.Value);
                if (!occurrences.ContainsKey(entry.Value))
                {
                    occurrences[entry.Value] = new List<string>();
                }
                occurrences[entry.Value].Add(entry.Key);
            }
            return occurrences;
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
