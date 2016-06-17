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
            string filePath;

            if(args.Length == 0)
            {
                Console.WriteLine("No arg detected, loading sample file");
                filePath = @"..\..\..\Sample1.txt";
            }
            else
            {
                Console.WriteLine("Loading " + args[0]);
                filePath = args[0];
            }


            //TextFile_v1 sampleFile = new TextFile_v1(filePath, true);
            //Dictionary<int, List<string>> resultList = sampleFile.SortOccurrencesByNumber();
            //PrintResultToConsole(resultList);

            TextFile_v2 sampleFile_2 = new TextFile_v2(filePath, true);
            Dictionary<int, List<string>> resultList_2 = sampleFile_2.sortedOccurrences;
            PrintResultToConsole(resultList_2);
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
