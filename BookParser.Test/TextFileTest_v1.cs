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
    class TextFileTest_v1
    {

        string fileString = "This is a Test";
        string filePath = @"..\TestFile.txt";
        string inputString = "Hello Friend";

        [TestCase]
        public void Constructor_WithFile_DefaultArgument()
        {
            TextFile_v1 testFile = new TextFile_v1(filePath);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithFile_ExplicitArgument()
        {
            TextFile_v1 testFile = new TextFile_v1(filePath, true);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithString()
        {
            TextFile_v1 testFile = new TextFile_v1(inputString, false);
            Assert.AreEqual(inputString, testFile.rawText);
        }

        [TestCase]
        public void ParsedWords_DivideOnSpace()
        {
            TextFile_v1 testFile = new TextFile_v1(inputString, false);
            Assert.AreEqual(2, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void ParsedWords_DivideOnPunctuation()
        {
            string testString = "one.two!three?four-five;six:seven";
            TextFile_v1 testFile = new TextFile_v1(testString, false);
            Assert.AreEqual(7, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void ParsedWords_DivideOnUnderscore()
        {
            string testString = "one_two";
            TextFile_v1 testFile = new TextFile_v1(testString, false);
            Assert.AreEqual(2, testFile.ParsedWords().Length);

        }

        [TestCase]
        public void CountOccurrences_SingleWords()
        {
            TextFile_v1 testFile = new TextFile_v1(inputString, false);
            Assert.AreEqual(1, testFile.CountOccurrences()["hello"]);
        }

        [TestCase]
        public void CountOccurrences_UpLowerCase()
        {
            string testString = "Hello hello HELLO hELLo";
            TextFile_v1 testFile = new TextFile_v1(testString, false);
            Assert.AreEqual(4, testFile.CountOccurrences()["hello"]);
        }

        [TestCase]
        public void SortOccurrencesByNumber()
        {
            string testString = "4 4 4 4 four four four four";
            List<string> expectedList = new List<string> { "4", "four" };
            TextFile_v1 testFile = new TextFile_v1(testString, false);
            Assert.AreEqual(expectedList, testFile.SortOccurrencesByNumber()[4]);

        }
    }
}
