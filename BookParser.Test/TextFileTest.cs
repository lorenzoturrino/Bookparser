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
        [TestCase]
        public void ConstructorTest()
        {
            string expectedString = @"This\ %is a ^Test is is a!?.";
            string filePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile testFile = new TextFile(filePath);
                 
            Assert.AreEqual(expectedString, testFile.rawText);
        }

        [TestCase]
        public void ParsedWordsTest()
        {
            string filePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile testFile = new TextFile(filePath);

            Assert.AreEqual(7, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void CountOccurrencesTest()
        {
            string filePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile testFile = new TextFile(filePath);

            Dictionary<string, int> occurrences = testFile.CountOccurrences();
            Assert.AreEqual(1, occurrences["Test"]);
            Assert.AreEqual(3, occurrences["is"]);
        }

    }
}
