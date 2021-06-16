using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem29 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var max = 100;

            var results = new HashSet<double>();

            for (int a = 2; a <= max; a++)
            {
                for (int b = 2; b <= max; b++)
                {
                    results.Add((double)Math.Pow(a, b));
                }
            }

            var x = results.ToList();
            x.Sort();

            return x.Count();
        }
    }
}
