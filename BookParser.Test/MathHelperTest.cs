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
    class MathHelperTest
    {
        [TestCase]
        public void CheckPrimalityOfZero()
        {
            bool isZeroPrime = MathHelper.CheckPrimality(0);
            Assert.AreEqual(false, isZeroPrime);
        }
    }
}
