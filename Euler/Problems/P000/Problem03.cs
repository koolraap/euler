using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem3 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var largestPrimeFactor = 600851475143.Factors().Where(c => c.IsPrime()).Max();

            return largestPrimeFactor;
        }
    }
}
