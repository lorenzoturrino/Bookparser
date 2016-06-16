﻿using System;
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
        private Dictionary<int, List<string>> sortedOccurrencesCount;

        public TextFile_v2(string inputString, bool isFile = true)
        {
            readText(inputString, isFile);
            populateWordArray();
            populateOccurrencesCount();
        }

        public string rawText
        {
            get { return fileContent; }
        }

        public string[] parsedWords
        {
            get { return parsedWordsArray; }
        }

        public Dictionary<int, List<string>> sortedOccurrences
        {
            get { return sortedOccurrencesCount; }
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

        private void populateOccurrencesCount()
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            foreach (string entry in parsedWordsArray)
            {
                if (occurrences.ContainsKey(entry))
                    occurrences[entry] += 1;
                else
                    occurrences[entry] = 1;
            }
            sortedOccurrencesCount = sortOccurrences(occurrences);
        }

        private Dictionary<int, List<string>> sortOccurrences(Dictionary<string, int> occurrences)
        {
            Dictionary<int, List<string>> sortedOccurrences = new Dictionary<int, List<string>>();
            foreach (KeyValuePair<string,int> entry in occurrences)
            {
                if(!sortedOccurrences.ContainsKey(entry.Value))
                {
                    sortedOccurrences[entry.Value] = new List<string>();
                }
                sortedOccurrences[entry.Value].Add(entry.Key);
            }
            return sortedOccurrences;
        }
    }
}
