using Euler.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem25 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var i = 0;

            var target = BigNumber.MaxValue;

            foreach (var n in target.FibonacciSequence())
            {
                i++;

                if (n.Length == 1000)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
