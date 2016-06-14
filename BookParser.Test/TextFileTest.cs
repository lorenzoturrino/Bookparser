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
            string ExpectedString = "This is a Test!?.";
            string FilePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile TestFile = new TextFile(FilePath);
                 
            Assert.AreEqual(ExpectedString, TestFile.RawText);
        }

        [TestCase]
        public void ParsedWordsTest()
        {
            string[] ExpectedArray = {"This", "is", "a", "Test"};
            string FilePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile TestFile = new TextFile(FilePath);

            Assert.AreEqual(ExpectedArray, TestFile.ParsedWords());
        }

    }
}
