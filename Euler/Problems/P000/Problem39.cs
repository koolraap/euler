using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    public class Problem39 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var realMax = 1000;

            var perimeters = new int[1001];

            for (int max = 3; max <= realMax; max++)
            {
                for (int a = 3; a <= max; a++)
                {
                    for (int b = 3; b <= max; b++)
                    {
                        if (a + b >= max)
                            break;

                        for (int c = 1; c <= max; c++)
                        {
                            var perimeter = a + b + c;

                            if (perimeter > max)
                                break;

                            if (perimeter != max)
                            {
                                continue;
                            }

                            if (a + b <= c)
                            {
                                continue;
                            }

                            if (c * c != a * a + b * b)
                            {
                                continue;
                            }

                            perimeters[max]++;
                        }
                    }
                }
            }

            int maxValue = perimeters.Max();
            var answer = perimeters.ToList().IndexOf(maxValue);

            await Task.CompletedTask;
            return answer;
        }
    }
}
