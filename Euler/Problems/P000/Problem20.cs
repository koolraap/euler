using Euler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem20 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 100;
            BigNumber value = (BigNumber)1;

            for (int i = 1; i <= seed; i++)
            {
                value *= (BigNumber)i;
            }

            var digitSum = value.ToString().SumDigits();

            return digitSum;
        }
    }
}
