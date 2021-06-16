using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem31 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var coins = new List<int> { 200, 100, 50, 20, 10, 5, 2, 1 };
            var max = 200;
            var permutations = 0L;

            for (int a = 0; a <= max / coins[0]; a++)
            {
                for (int b = 0; b <= max / coins[1]; b++)
                {
                    if (a * coins[0] + b * coins[1] > max)
                        break;

                    for (int c = 0; c <= max / coins[2]; c++)
                    {
                        if (a * coins[0] + b * coins[1] + c* coins[2] > max)
                            break;

                        for (int d = 0; d <= max / coins[3]; d++)
                        {
                            if (a * coins[0] + b * coins[1] + c * coins[2] + d* coins[3] > max)
                                break;

                            for (int e = 0; e <= max / coins[4]; e++)
                            {
                                if (a * coins[0] + b * coins[1] + c * coins[2] + d * coins[3] + e*coins[4]> max)
                                    break;

                                for (int f = 0; f <= max / coins[5]; f++)
                                {
                                    if (a * coins[0] + b * coins[1] + c * coins[2] + d * coins[3] + e * coins[4] + f * coins[5] > max)
                                        break;

                                    for (int g = 0; g <= max / coins[6]; g++)
                                    {
                                        if (a * coins[0] + b * coins[1] + c * coins[2] + d * coins[3] + e * coins[4] + f * coins[5] + g *coins[6]> max)
                                            break;

                                        for (int h = 0; h <= max / coins[7]; h++)
                                        {
                                            if (a*coins[0] + 
                                                b*coins[1] + 
                                                c*coins[2] + 
                                                d*coins[3] + 
                                                e*coins[4] +
                                                f*coins[5] +
                                                g*coins[6] +
                                                h*coins[7] == max)
                                            {
                                                permutations++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return permutations;
        }
    }
}
