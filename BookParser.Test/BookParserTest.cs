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
    public class BookParserTest
    {
        [TestCase]
        public void FirstTest()
        {
            Assert.AreEqual(true, true);
        }
    }
}
