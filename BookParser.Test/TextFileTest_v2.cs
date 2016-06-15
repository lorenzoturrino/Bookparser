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
        string filePath = @"C:\Users\neuro\OneDrive\prowin\BookParser\BookParser.Test\bin\TestFile.txt";
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
    }
}
