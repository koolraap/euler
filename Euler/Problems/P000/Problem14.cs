using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem14 : IProblem<ulong>
    {
        public async Task<ulong> Solve()
        {
            var max = 0UL;
            var length = 0UL;
            var answer = 0UL;

            for (var i = 10UL; i < 1000000; i++)
            {
                length = 1;
                foreach (var value in i.Collatz())
                {
                    length++;
                }

                if (length > max)
                {
                    max = length;
                    answer = i;
                }
            }

            return answer;
        }
    }
}
