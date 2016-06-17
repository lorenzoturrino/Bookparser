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
    class TextFileTest_v2
    {
        string fileString = "This is a Test";
        string filePath = @"..\..\TestFile.txt";
        string inputString = "Hello Friend";

        [TestCase]
        public void Constructor_WithFile_DefaultArgument()
        {
            TextFile_v2 testFile = new TextFile_v2(filePath);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithFile_ExplicitArgument()
        {
            TextFile_v2 testFile = new TextFile_v2(filePath, true);
            Assert.AreEqual(fileString, testFile.rawText);
        }

        [TestCase]
        public void Constructor_WithString()
        {
            TextFile_v2 testFile = new TextFile_v2(inputString, false);
            Assert.AreEqual(inputString, testFile.rawText);
        }

        [TestCase]
        public void ParsedWords_DivideOnSpace()
        {
            TextFile_v2 testFile = new TextFile_v2(inputString, false);
            Assert.AreEqual(2, testFile.parsedWords.Length);
        }

        [TestCase]
        public void ParsedWords_DivideOnPunctuation()
        {
            string testString = "one.two!three?four-five;six:seven";
            TextFile_v2 testFile = new TextFile_v2(testString, false);
            Assert.AreEqual(7, testFile.parsedWords.Length);
        }

        [TestCase]
        public void ParsedWords_DivideOnUnderscore()
        {
            string testString = "one_two";
            TextFile_v2 testFile = new TextFile_v2(testString, false);
            Assert.AreEqual(2, testFile.parsedWords.Length);

        }

        [TestCase] 
        public void SortedOccurrences_UpLowerCase()
        {
            string testString = "Hello hello HELLO hELLo";
            List<string> expectedList = new List<string> { "hello" };
            TextFile_v2 testFile = new TextFile_v2(testString, false);
            Assert.AreEqual(expectedList, testFile.sortedOccurrences[4]);
        }

        [TestCase]
        public void SortedOccurrences_CorrectKey()
        {
            string testString = "3 3 3";
            List<string> expectedList = new List<string> { "3" };
            TextFile_v2 testFile = new TextFile_v2(testString, false);
            Assert.AreEqual(expectedList, testFile.sortedOccurrences[3]);
        }

        [TestCase]
        public void SortedOccurrences_CorrectValue()
        {
            string testString = "2 2 two two";
            List<string> expectedList = new List<string> { "2", "two" };
            TextFile_v2 testFile = new TextFile_v2(testString, false);
            Assert.AreEqual(expectedList, testFile.sortedOccurrences[2]);
        }
    }
}
