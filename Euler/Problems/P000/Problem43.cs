using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Euler.Attributes;
using Euler.Extensions;

namespace Euler.Problems
{
    public class Problem43 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            BigInteger answer = 0;

            var perms = new Permutations();

            foreach (var digits in "1234567890".ToCharArray().Permutations())
            {
                if (digits.ElementAt(5) != '5')
                    continue;

                var number = new string(digits.ToArray()); 

                //{ 1484205182316}
                //if (number[0] == '0') continue;

                var div17 = number.Substring(7, 3).ToInt() % 17 == 0;

                if (div17)
                {
                    var div13 = number.Substring(6, 3).ToInt() % 13 == 0;

                    if (div13)
                    {
                        var div11 = number.Substring(5, 3).ToInt() % 11 == 0;

                        if (div11)
                        {
                            var div7 = number.Substring(4, 3).ToInt() % 7 == 0;

                            if (div7)
                            {
                                var div5 = number.Substring(3, 3).ToInt() % 5 == 0;

                                if (div5)
                                {
                                    var div3 = number.Substring(2, 3).ToInt() % 3 == 0;

                                    if (div3)
                                    {
                                        var div2 = number.Substring(1, 3).ToInt() % 2 == 0;

                                        bool hasProperty = div2;

                                        if (hasProperty)
                                        {
                                            answer += BigInteger.Parse(number);
                                            Console.WriteLine(number);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            var l = (long)answer;

            await Task.CompletedTask;
            return l;
        }
    }
}
