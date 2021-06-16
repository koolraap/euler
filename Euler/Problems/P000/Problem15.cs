using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem15 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            // pascal's triangle. 2n+1??? 20.
            var seed = 41;

            long[,] pasT = new long[seed, seed];

            // rows 0 & 1
            pasT[0, 0] = 1;
            pasT[0, 1] = 1;
            pasT[1, 1] = 1;

            for (long y = 2; y < seed; y++)
            {
                //Console.Write("{0}: ", y + 1);

                for (long x = 0; x <= y; x++)
                {
                    var a = x == 0 ? 0 : pasT[x - 1, y - 1];
                    var b = x == y ? 0 : pasT[x, y - 1];
                    var c = a + b;
                    pasT[x, y] = c;

                    //Console.Write("{0} ", pasT[x, y]);
                }
                //Console.WriteLine(" [{0}] - {1}", pasT[y / 2, y], y / 2);
            }

            //Console.WriteLine();

            var result = pasT[seed / 2, seed - 1];

            return result;
        }
    }
}
