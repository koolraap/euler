using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem12 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var sum = 0L;

            for (var i = 1; i <= 12379; i++)
            {
                sum = sum + i;

                var divisors = sum.Divisors().ToList();
                var count = divisors.Count;

                if (count > 500)
                {
                    return sum;
                }
            }

            return -1;
        }
    }
}
