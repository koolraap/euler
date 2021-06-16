using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    public class Problem24 : IProblem<string>
    {
        public async Task<string> Solve()
        {
            var z = "0123456789".Permutations().ToList();

            z.Sort();

            var x = z[999999];

            return x;
        }
    }
}
