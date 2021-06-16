using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem37 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var found = 0;
            var sum = 0L;

            for (int i = 11; found != 11; i += 2)
            {
                var isPrime = true;

                var numL = i.ToString();
                var numR = numL;
                var max = numL.Length;


                for (var j = 0; j < max; j++)
                {
                    isPrime = long.Parse(numL).IsPrime() && long.Parse(numR).IsPrime();

                    if (!isPrime)
                    {
                        break;
                    }

                    numL = numL.Substring(1);
                    numR = numR.Substring(0, numR.Length - 1);
                }

                if (isPrime)
                {
                    found++;
                    sum += i;
                }
            }

            return sum;
        }
    }
}
