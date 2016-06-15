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

        string fileString = "This is a Test";
        string filePath = @"C:\Users\neuro\OneDrive\prowin\BookParser\BookParser.Test\bin\TestFile.txt";
        string inputString = "Hello Friend";

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
        public void ParsedWords_DivideOnSpace()
        {
            TextFile testFile = new TextFile(inputString, false);
            Assert.AreEqual(2, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void ParsedWords_DivideOnPunctuation()
        {
            string testString = "one.two!three?four-five;six:seven";
            TextFile testFile = new TextFile(testString, false);
            Assert.AreEqual(7, testFile.ParsedWords().Length);
        }

        [TestCase]
        public void ParseWords_DivideOnUnderscore()
        {
            string testString = "one_two";
            TextFile testFile = new TextFile(testString, false);
            Assert.AreEqual(2, testFile.ParsedWords().Length);

        }

        [TestCase]
        public void CountOccurrences_SingleWords()
        {
            TextFile testFile = new TextFile(inputString, false);
            Assert.AreEqual(1, testFile.CountOccurrences()["hello"]);
        }

        [TestCase]
        public void CountOccurrences_UpLowerCase()
        {
            string testString = "Hello hello HELLO hELLo";
            TextFile testFile = new TextFile(testString, false);
            Assert.AreEqual(4, testFile.CountOccurrences()["hello"]);
        }
    }
}
