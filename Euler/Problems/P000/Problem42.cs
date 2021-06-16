using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler.Attributes;
using Euler.Extensions;

namespace Euler.Problems
{
    public class Problem42 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var file = File.ReadAllText(@"problems\p042_words.txt");
            var words = file.Split("\",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // prime cache
            _ = 1000L.Triangles().ToList();

            var answer = 0L;

            foreach (var word in words)
            {
                var value = word.AlphabeticalValue();

                if (value.IsTriangle())
                {
                    answer++;
                }
            }

            await Task.CompletedTask;
            return answer;
        }
    }
}
