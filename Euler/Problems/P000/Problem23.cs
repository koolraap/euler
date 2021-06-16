using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem23 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var abundantNumbers = new List<long>();

            var leftovers = new ConcurrentDictionary<long, long>(Enumerable.Range(1, 28123).Select((c) => new KeyValuePair<long,long>(c, c)));
            
            for (long i = 12; i <= 28123; i++)
            {
                if (i.IsAbundant())
                {
                    //Console.Write("{0}, ", i);
                    abundantNumbers.Add(i);

                    var dummy = 0L;
                    Parallel.ForEach(abundantNumbers, (num) => leftovers.TryRemove(num + i, out dummy));
                }
            }

            var sum = leftovers.Select(c => c.Key).ToList().Sum();

            return sum;
        }
    }
}
