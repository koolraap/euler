using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Attributes;

namespace Euler.Problems
{
    public class Problem46 : IProblem<long>
    {


        public async Task<long> Solve()
        {
            var max = 40000L;

            var primes = max.Primes().ToArray();
            var squares = max.Squares().ToArray();

            var result = 9;

            var isGoldbach = true;

            while (isGoldbach)
            {
                bool found = false;

                if (primes.Contains(result))
                    goto loveit;

                foreach (var square in squares.Where(s => s*2 < result))
                {
                    foreach (var prime in primes.Where(p => p <= result - (square * 2)))
                    {
                        if (square * 2 + prime == result)
                        {
                            found = true;
                            Console.WriteLine($"{result} = {square} * 2 + {prime}");
                        }
                    }
                }

                if (!found)
                {
                    break;
                }

loveit:

                result += 2;

                
            }
            return result;
        }
    }
}
