using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    public class Problem40 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var max = 1000000;

            var sequenceLength = 0;

            var found1 = false;
            var found10 = false;
            var found100 = false;
            var found1000 = false;
            var found10000 = false;
            var found100000 = false;
            var found1000000 = false;

            var answer = 0;

            for (int i = 1; i < max; i++)
            {
                var s = i.ToString().Reverse().ToString();

                sequenceLength += s.Length;

                if (sequenceLength >= 1 && !found1)
                {
                    answer += int.Parse(s[0].ToString());
                    found1 = true;
                }

                if (sequenceLength >= 10 && !found10)
                {
                    var digit = s[sequenceLength - 10].ToString();
                    answer *= int.Parse(digit);
                    found10 =true;
                }

                if (sequenceLength >= 100 && !found100)
                {
                    var digit = s[sequenceLength - 100].ToString();
                    answer *= int.Parse(digit);
                    found100 = true;
                }

                if (sequenceLength >= 1000 && !found1000)
                {
                    var digit = s[sequenceLength - 1000].ToString();
                    answer *= int.Parse(digit);
                    found1000 = true;
                }

                if (sequenceLength >= 10000 && !found10000)
                {
                    var digit = s[sequenceLength - 10000].ToString();
                    answer *= int.Parse(digit);

                    found10000 = true;
                }

                if (sequenceLength >= 100000 && !found100000)
                {
                    var digit = s[sequenceLength - 100000].ToString();
                    answer *= int.Parse(digit);
                    found100000 = true;
                }

                if (sequenceLength >= 1000000 && !found1000000)
                {
                    var digit = s[sequenceLength - 1000000].ToString();
                    answer *= int.Parse(digit);
                    found1000000 = true;
                }


            }

            await Task.CompletedTask;
            return answer;
        }
    }
}