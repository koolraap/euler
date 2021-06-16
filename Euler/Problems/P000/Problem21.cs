using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    public class Problem21 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var amicables = new Dictionary<long, long>();

            for (var n = 1L; n < 10000; n++)
            {
                var sum1 = n.Factors2().Sum();
                var sum2 = sum1.Factors2().Sum();

                if (sum2 == n && sum1 != n)
                {
                    amicables[n] = sum1;
                    amicables[sum1] = n;
                }
            }

            var sum = amicables.Select(c => c.Key).Sum();

            await Task.CompletedTask;
            return sum;
        }
    }
}
