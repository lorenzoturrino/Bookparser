using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser
{
    public static class MathHelper
    {
        public static bool CheckPrimality(int value)
        {
            return PrimeByTrialDivision(value);
        }

        public static bool IsPrime(this int value)
        {
            return PrimeByTrialDivision(value);
        }

        private static bool PrimeByTrialDivision(int value)
        {
            if (value == 0 || value == 1)
            {
                return false;
            }
            int maxDivisor = (int)Math.Min(Math.Ceiling(Math.Sqrt(value)),value-1);
            for (int i = 2; i <= maxDivisor; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }
    }

}
