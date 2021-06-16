using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    // sum of primes < 2,000,000
    public class Problem10 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var sum = 0L;

            for (var i = 1L; i < 2000000; i++)
            {
                if (i.IsPrime())
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
