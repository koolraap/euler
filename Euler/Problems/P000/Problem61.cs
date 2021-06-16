using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    public class Problem61 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var maxD = 0L;

            for (var d = 2L; d < 8; d++)
            {
                var sqrt = Math.Sqrt(d);

                if (Math.Truncate(sqrt) == sqrt)
                {
                    continue;
                }

            }

            return -1;
        }
    }
}
