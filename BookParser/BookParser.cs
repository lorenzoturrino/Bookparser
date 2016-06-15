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

            string filePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\Sample1.txt";

            TextFile sampleFile = new TextFile(filePath);
            Dictionary<string,int> occurrences = sampleFile.CountOccurrences();
            foreach (KeyValuePair<string,int> entry in occurrences.OrderByDescending(entry => entry.Value))
            {
                Console.WriteLine("entry: " + entry.Key + " - " + entry.Value);
            }
        }
    }
}
