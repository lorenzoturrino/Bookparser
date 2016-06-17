using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser
{
    class BookParser
    {
        static public void Main(string[] args)
        {
            TextFile_v1 sampleFile = loadText(args);
            PrintResultToConsole(sampleFile.SortOccurrencesByNumber());
        }

        static private TextFile_v1 loadText( string[] userArgs)
        {
            string sampleFile = @"..\..\..\Sample1.txt";
            if (userArgs.Length == 0)
            {
                Console.WriteLine("No arg detected, loading sample file");
                return new TextFile_v1(sampleFile, true);
            }
            else if (userArgs[0] == "STRING")
            {
                string inputString = buildStringFromArgs(userArgs);
                Console.WriteLine("String detected, loading ' " + inputString + "'");
                return new TextFile_v1(inputString, false);
            }
            else
            {
                Console.WriteLine("File path detected, loading " + userArgs[0]);
                return new TextFile_v1(userArgs[0], true);
            }
            
        }

        static private string buildStringFromArgs(string[] userArgs)
        {
            string inputText = "";
            for (int i = 1; i < userArgs.Length; i++)
            {
                inputText += userArgs[i] + " ";
            }
            return inputText;
        }

        static private void PrintResultToConsole(Dictionary<int, List<string>> blob)
        {
            foreach (KeyValuePair<int, List<string>> entry in blob.OrderByDescending(pair => pair.Key))
            {
                string line = entry.Key.ToString();
                line += (entry.Key.IsPrime() ? " (Prime number)" : " (Not a prime number)") + " appearances:\n| ";
                foreach (string word in entry.Value)
                {
                    line += word + " | ";
                }
                line += "\n\n";
                Console.Write(line);
            }
        }
    }
}