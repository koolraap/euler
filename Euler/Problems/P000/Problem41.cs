using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler.Attributes;
using Euler.Extensions;

namespace Euler.Problems
{

    public class Problem41 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var result = 0L;
            var permutations = "1234567".ToCharArray().Permutations().Select(x => string.Concat(x)).ToList();
            
            foreach (var num in permutations)
            {
                var n = long.Parse(num);

                if (n.IsPrime() && n > result)
                {
                    result = n;
                }
            }

            return result;
        }
    }
}
