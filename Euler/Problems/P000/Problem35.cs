using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem35 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var seed = 1000000L;

            var result = 0;

            for (var i = 1L; i < seed; i++)
            {
                if (!i.IsPrime())
                    continue;

                var s = i.ToString();

                bool theAllPrime = true;

                for (int j = 1; j < s.Length; j++)
                {
                    s = s.Rotate();

                    var p = Convert.ToInt64(s);

                    if (!p.IsPrime())
                    {
                        theAllPrime = false;
                        break;
                    }
                }

                if (theAllPrime)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
