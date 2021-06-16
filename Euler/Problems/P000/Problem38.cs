using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Extensions;

namespace Euler.Problems
{
    public class Problem38 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var largest = 0L;

            for (long i = 2; i < 10000; i++)
            {
                var num = "";

                for (int j = 1; ; j++)
                {
                    num += i * j;

                    if (num.Length == 9)
                    {
                        if (num.IsPandigital())
                        {
                            var n = long.Parse(num);

                            if (n > largest)
                            {
                                largest = n;
                            }
                        }
                    }
                    else if (num.Length > 9)
                    {
                        break;
                    }
                }
            }

            return largest;
        }
    }
}
