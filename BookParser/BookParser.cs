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
            Console.WriteLine("Starting up sample reading");

            string filePath = @"C:\Users\neuro\OneDrive\prowin\BookParser\Sample1.txt";

            TextFile_v1 sampleFile = new TextFile_v1(filePath, true);
            Dictionary<int, List<string>> resultList = sampleFile.SortOccurrencesByNumber();

            foreach (KeyValuePair<int,List<string>> entry in resultList.OrderByDescending(pair => pair.Key))
            {
                string line = entry.Key.ToString();
                line += (MathHelper.CheckPrimality(entry.Key) ? " (Prime number)" : " (Not a prime number)") + " appearances:\n";
                foreach (string word in entry.Value)
                {
                    line += word + ", ";
                }
                line = line.Remove(line.Length - 2) + "\n\n";
                Console.Write(line);
            }
        }
    }
}
