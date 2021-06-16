using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem9 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            var seed = 1000;

            for (int a=1; a < 1000; a++)
            {
                for (int b=1; b < 1000; b++)
                {
                    var c2 = a * a + b * b;

                    var c = Math.Sqrt(c2);

                    if (c.IsInteger())
                    {
                        var i = (int)c;

                        if (a + b + i == seed)
                        {
                            //Console.WriteLine("{0}, {1}, {2}", a, b, i);
                            return a * b * i;
                        }
                    }
                }
            }

            return -1;
        }
    }
}
