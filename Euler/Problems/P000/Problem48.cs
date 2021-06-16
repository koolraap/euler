using Euler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem48 : IProblem<string>
    {
        public async Task<string> Solve()
        {
            BigInteger sum = (BigInteger)0;

            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }

            var num = sum.ToString();
            var result = num.Substring(num.Length - 10);


            return result;
        }
    }
}
