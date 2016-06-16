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
        public void CheckPrimality_Zero()
        {
            bool isZeroPrime = MathHelper.CheckPrimality(0);         
            Assert.IsFalse(isZeroPrime);
        }

        [TestCase]
        public void CheckPrimality_One()
        {
            bool isOnePrime = MathHelper.CheckPrimality(1);
            Assert.IsFalse(isOnePrime);
        }

        [TestCase]
        public void CheckPrimality_PrimeNumber()
        {
            bool isSevenPrime = MathHelper.CheckPrimality(7);
            Assert.IsTrue(isSevenPrime);
        }

        [TestCase]
        public void CheckPrimality_NonprimeNumber()
        {
            bool isSixPrime = MathHelper.CheckPrimality(6);
            Assert.IsFalse(isSixPrime);
        }

        [TestCase]
        public void IsPrime_ExtendsInt()
        {
            Assert.IsTrue(7.IsPrime());
        }

    }
}

