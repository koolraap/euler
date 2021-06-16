using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem27 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var maxRun = 0L;
            var maxA = long.MinValue;
            var maxB = long.MinValue;

            for (long a=-999; a < 1000; a++)
            {
                for (long b=-999; b < 1000; b++)
                {
                    for (long n=0; ; n++)
                    {
                        var m = (n * n) + (a * n) + b;

                        if (m.IsPrime())
                        {
                            if (n + 1 > maxRun)
                            {
                                maxRun = n + 1;
                                maxA = a;
                                maxB = b;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            var sum = maxA * maxB;

            return sum;
        }
    }
}
