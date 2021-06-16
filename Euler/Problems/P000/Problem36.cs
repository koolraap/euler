using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem36 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 1000000L;

            var sum = 0L;

            for (int i = 0; i < seed; i++)
            {
                if (i.ToString().IsPalindrome())
                {
                    var b2 = Convert.ToString(i, 2);

                    if (b2.IsPalindrome())
                    {
                        sum += i;
                    }
                }
            }

            return sum;
        }
    }
}
