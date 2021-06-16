using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem6 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 100;

            var squareSum = 0L;
            var sumSquare = 0L;
            for (int i=1; i <= seed; i++)
            {
                sumSquare += i * i;
                squareSum += i;
            }

            squareSum = squareSum * squareSum;

            var diff = squareSum - sumSquare;

            return diff;
        }

    }
}
