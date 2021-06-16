using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Attributes;

namespace Euler.Problems
{
    [Problem(Priority = true)]
    public class Problem47 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var max = 1980000L;

            var factors = max.Factors2();
            var primes = (((long)Math.Sqrt(max))+1).Primes();
            var conseq = 4;

            var answer = 14L;
            var found = false;
            
            for (; !found; answer++)
            {
                var a1 = answer.PrimeFactors();

                if (a1.Distinct().Count() != conseq)
                {
                    continue;
                }

                var a2 = (answer + 1).PrimeFactors();

                if (a2.Distinct().Count() != conseq)
                {
                    answer++;
                    continue;
                }

                var a3 = (answer + 2).PrimeFactors();

                if (a3.Distinct().Count() != conseq)
                {
                    answer += 2;
                    continue;
                }

                var a4 = (answer + 3).PrimeFactors();

                if (a4.Distinct().Count() != conseq)
                {
                    answer += 3;
                    continue;
                }

                found = true;
            }


            return answer;
        }
    }
}
