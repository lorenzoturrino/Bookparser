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
            string ExpectedString = @"This\ %is a ^Test is is a!?.";
            string FilePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile TestFile = new TextFile(FilePath);
                 
            Assert.AreEqual(ExpectedString, TestFile.RawText);
        }

        [TestCase]
        public void ParsedWordsTest()
        {
            string FilePath = "C:\\Users\\neuro\\OneDrive\\prowin\\BookParser\\BookParser.Test\\bin\\TestFile.txt";

            TextFile TestFile = new TextFile(FilePath);

            Assert.AreEqual(7, TestFile.ParsedWords().Length);
        }

       

    }
}
