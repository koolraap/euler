using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem17 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            var seed = 1000;

            var s = "";

            for (long i = 1; i <= seed; i++)
            {
                //Console.WriteLine("{0}={1}", i, i.ToWords());
                s += i.ToWords();
            }

            s = s.Replace(" ", "").Replace("-", "");

            return s.Length;
        }

    }
}