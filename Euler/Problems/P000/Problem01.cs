using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem1 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            var threes = 1000.MultiplesLessThan(3);
            var fives = 1000.MultiplesLessThan(5);

            var both = threes.Concat(fives).Distinct().ToList();

            var sum = both.Sum(c => c);

            return sum;
        }
    }
}
