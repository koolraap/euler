using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Euler.Extensions;
using System.Collections.Concurrent;

namespace Euler.Problems
{
    public class Problem32 : IProblem<long>
    {
        private ConcurrentBag<Tuple<int, int>> _valid = new ConcurrentBag<Tuple<int, int>>();

        public async Task<long> Solve()
        {
            var permutations = "123456789".ToCharArray().Permutations().ToList();

            var options = new ParallelOptions();// { MaxDegreeOfParallelism = 1 };

            Parallel.ForEach(permutations, options,
                (n) =>
            {
                FindPandigital(string.Concat(n));
            });

            checked
            {
                var sum = _valid.Select(c => c.Item1 * c.Item2).Distinct().Sum();

                return sum;
            }
        }

        private void FindPandigital(string value)
        {
            for (int i=0; i < value.Length-2; i++)
            {
                var aStr = value.Substring(0, i+1);

                var a = int.Parse(aStr);


                for (int j = i + 1; j < value.Length - i - 1; j++ )
                {
                    var bStr = value.Substring(i + 1, j);
                    var b = int.Parse(bStr);

                    var p = (a * b).ToString();

                    //Console.WriteLine("{0}*{1}={2}", a, b, p);

                    if (aStr + bStr + p == value)
                    {
                        _valid.Add(new Tuple<int, int>(a, b));
                    }
                }
            }
        }
    }
}
