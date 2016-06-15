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

            TextFile sampleFile = new TextFile(filePath, true);
            Dictionary<int, List<string>> resultList = sampleFile.SortOccurrencesByNumber();

            foreach (KeyValuePair<int,List<string>> entry in resultList.OrderByDescending(pair => pair.Key))
            {
                Console.Write(entry.Key + " appearances: ");
                foreach (string word in entry.Value)
                {
                    Console.Write(word + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}
