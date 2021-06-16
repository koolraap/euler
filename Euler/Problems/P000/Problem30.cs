using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem30 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 2;
            var max = 999999;
            var power = 5;

            var total = 0L;

            for (int i = seed; i < max; i++)
            {
                var s = i.ToString();

                var sum = 0L;
                for (var j = 0; j < s.Length; j++)
                {
                    var n = char.GetNumericValue(s, j);
                    sum += (long)Math.Pow(n, power);

                    if (sum > i)
                    {
                        break;
                    }
                }

                if (sum == i)
                {
                    total += sum;
                }
            }

            return total;
        }
    }
}
