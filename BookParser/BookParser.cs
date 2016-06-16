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
            
            string filePath = @"..\..\..\Sample1.txt";
            Console.WriteLine("Starting up sample reading from:" + filePath);

            TextFile_v1 sampleFile = new TextFile_v1(filePath, true);
            Dictionary<int, List<string>> resultList = sampleFile.SortOccurrencesByNumber();
            PrintResultToConsole(resultList);

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
