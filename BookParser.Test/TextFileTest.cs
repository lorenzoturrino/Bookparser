using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit;
using NUnit.Framework;
using BookParser;

namespace BookParser.Test
{
    [TestFixture]
    class TextFileTest
    {

        string fileString = @"This\ %is a ^Test is is a!?.";
        string filePath = @"C:\Users\neuro\OneDrive\prowin\BookParser\BookParser.Test\bin\TestFile.txt";
        string inputString = "Hello123";


        [TestCase]
        public void Constructor_WithFile_DefaultArgument()
        {
            TextFile testFile = new TextFile(filePath);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithFile_ExplicitArgument()
        {
            TextFile testFile = new TextFile(filePath, true);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithString()
        {
            TextFile testFile = new TextFile(inputString, false);
            Assert.AreEqual(inputString, testFile.rawText);
        }

        [TestCase]
        public void ParsedWordsTest()
        {
            TextFile testFile = new TextFile(filePath);
            Assert.AreEqual(7, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void CountOccurrencesTest()
        {
            TextFile testFile = new TextFile(filePath);
            Dictionary<string, int> occurrences = testFile.CountOccurrences();
            Assert.AreEqual(1, occurrences["Test"]);
            Assert.AreEqual(3, occurrences["is"]);
        }

    }
}
