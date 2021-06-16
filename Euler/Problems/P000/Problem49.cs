using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Extensions;

namespace Euler.Problems
{
    public class Problem49 : IProblem<string>
    {
        public async Task<string> Solve()
        {
            var primes = Enumerable.Range(1000, 8999).Where(x => ((long)x).IsPrime());

            var map = new Dictionary<int, int>();

            foreach (var p in primes)
            {
                var s = p.ToString().Sort();
                map.Add(p, int.Parse(s));
            }

            var result = "";
            foreach (var p in map.Select(x => x.Value).Distinct())
            {
                var numbers = map.Where(x => x.Value == p).Select(x => x.Key).ToList();

                if (numbers.Count() >= 3)
                {
                    for (var i = 0; i < numbers.Count() - 1; i++)
                    {
                        // bug: assumes first 2 in sequence are adjacent. happens to work.
                        var diff = numbers[1 + i] - numbers[0 + i];

                        if (numbers.Contains(numbers[1 + i] + diff))
                        {
                            result += numbers[i] + numbers[i+1] + (numbers[i+1] + diff);
                        }
                    }
                }
            }

            return result;
        }
    }
}
