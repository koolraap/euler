using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem4 : IProblem<string>
    {
        public async Task<string> Solve()
        {
            var bigI = 0;
            var bigJ = 0;
            var bigA = 0;

            for (var i = 100; i < 1000; i++)
            {
                for (var j = 100; j < 1000; j++)
                {
                    var product = i * j;

                    if (product > bigA)
                    {
                        if (product.ToString().IsPalindrome())
                        {
                            bigI = i;
                            bigJ = j;
                            bigA = product;
                        }
                    }
                }
            }

            return string.Format("{0} x {1} = {2}", bigI, bigJ, bigI * bigJ);
        }
    }
}
