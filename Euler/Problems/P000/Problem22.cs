using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Euler.Problems
{
    public class Problem22 : IProblem<long>
    {

        public async Task<long> Solve()
        {
            var lines = File.ReadAllText(@"problems\p022_names.txt").Split(",\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            lines.Sort();

            long total = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                var alphavalue = lines[i].AlphabeticalValue();

                total += alphavalue * (i + 1);
            }

            return total;
        }
    }
}
