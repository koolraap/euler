using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    [Problem(LongRunning = true)]
    public class Problem50 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 1000000L;
            var primes = seed.Primes().ToArray();
            var max = primes.Count();
            var maxSum = 0L;
            var maxLength = 0L;

            for (var start = 0; start < primes.Count(); start++)
            {
                for (var end = primes.Count(); end > start - maxLength; end--)
                {
                    var sum = 0L;

                    for (var i = start; i < end; i++)
                    {
                        sum += primes[i];

                        if (sum >= seed)
                        {
                            break;
                        }

                        var length = i - start + 1;

                        if (length <= maxLength)
                        {
                            continue;
                        }

                        // skip non-prime sums
                        if (!sum.IsPrime())
                        {
                            continue;
                        }

                        maxLength = length;
                        maxSum = sum;
                    }
                }

            }

            Console.WriteLine();
            return maxSum;
        }

    }
}
