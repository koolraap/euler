using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem44 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var max = 4000L;
            var result = 0L;

            var pentagonals = max.Pentagonal();

            foreach (var j in pentagonals)
            {
                foreach (var k in pentagonals)
                {
                    var sum = j + k;
                    var dif = j - k;

                    if (dif <= 0)
                        break;

                    if (sum.IsPentagonal() && dif.IsPentagonal())
                    {
                        result = dif;
                        goto done;
                    }
                }
            }

        done:
            await Task.CompletedTask;
            return result;
        }
    }
}
