using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Extensions;

namespace Euler.Problems
{
    public class Problem16 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = (BigNumber)2;

            var x = (BigNumber)1999 + (BigNumber)1;

            var result = seed.Pow(1000);

            int total = 0;
            var resultStr = result.ToString();
            for (int i = 0; i < result.Length; i++)
            {
                total += (int)char.GetNumericValue(resultStr, i);
            }

            return total;
        }

    }
}

