using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem34 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var total = 0L;

            for (var i=145L; i < 40730; i++)
            {
                var num = i.ToString();

                var sum = 0L;

                for (var j=0; j < num.Length; j++)
                {
                    var n = (long)char.GetNumericValue(num, j);

                    sum += n.Factorial();

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
