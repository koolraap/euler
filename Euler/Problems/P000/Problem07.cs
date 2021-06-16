using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem7 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var found = 0;
            var bigPrime = 0L;
            
            for (var i=1L; found < 10001; i++)
            {
                if (i.IsPrime())
                {
                    found++;
                    bigPrime = i;
                }
            }

            return bigPrime;
        }
    }
}
