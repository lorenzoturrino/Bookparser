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
            string filePath;
            if (userArgs.Length == 0)
            {
                Console.WriteLine("No arg detected, loading sample file");
                filePath = @"..\..\..\Sample1.txt";
            }
            else
            {
                Console.WriteLine("Loading " + userArgs[0]);
                filePath = userArgs[0];
            }

            return new TextFile_v1(filePath, true);
        }

        static private void PrintResultToConsole(Dictionary<int, List<string>> blob)
        {
            foreach (KeyValuePair<int, List<string>> entry in blob.OrderByDescending(pair => pair.Key))
            {
                string line = entry.Key.ToString();
                line += (MathHelper.CheckPrimality(entry.Key) ? " (Prime number)" : " (Not a prime number)") + " appearances:\n| ";
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
