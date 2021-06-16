using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem2 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            var totes = 4000000.FibonacciSequence().Where(c => c % 2 == 0);

            var result = totes.Sum();

            return result;
        }
    }
}
