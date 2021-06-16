using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.Reflection;
using Euler.Attributes;

namespace Euler.Problems
{
    public class Problem26 : IProblem<decimal>
    {
        int numeratorLength = 50000;
        public async Task<decimal> Solve()
        {
            // make enormous numerator
            BigInteger numerator = 1;
            for (var i = 0; i < numeratorLength; i++)
            {
                numerator = numerator * 10;
            }

            Console.WriteLine($"Numerator: {numerator}");
            long max = 1000;
            var answer = 0L;
            var maxSequenceLength = 0;
            var maxJ = 0;
            // by observation. max length before repeating section
            var maxNonRepeatingStart = 6;
            BigInteger blah = 0;
            for (var i = max; i > 2; i--)
            {
                var factors = i.Factors2();

                // short cut if the sequence length 
                if (i <= maxSequenceLength)
                    break;

                if (factors.Count() == 2 && factors.Contains(2) && factors.Contains(5)
                    || factors.Count() == 1 && (factors.Contains(2) || factors.Contains(5)))
                {
                    // not a recurring decimal http://cribbd.com/learn/maths/number/identify-recurring-and-terminating-decimals
                    continue;
                }

                BigInteger denominator = i;

                var result = numerator / denominator;

                var test = result * denominator;
                var diff = numerator - test;
                if (diff != 0)
                {
                    if (!factors.Contains(2) && !factors.Contains(5))
                    {
                        if (FindRepeatingPattern(i, result.ToString(), 0, ref maxSequenceLength, ref answer))
                        {
                            continue;
                        }

                        // try with offsets.
                        for (int j = 1; j <= maxNonRepeatingStart; j++)
                        {
                            if (FindRepeatingPattern(i, result.ToString(), j, ref maxSequenceLength, ref answer))
                            {
                                if (j > maxJ)
                                    maxJ = j;
                                goto breakOut;
                            }
                        }

                        var thisIsAProblem = 0;
                        breakOut:

                        var what = 0;
                    }
                }
                //Console.WriteLine($"{i}: {result}");
            }

            Console.WriteLine($"max pattern length: {maxSequenceLength} answer={answer} max start offset={maxJ}");
            await Task.CompletedTask;
            return answer;
        }

        private bool FindRepeatingPattern(long i, string number, int startAt, ref int maxSequenceLength, ref long answer)
        {
            // test for single digit repeat pattern
            number = number.Substring(startAt);

            var test = number.Substring(0, 10);

            for (int j = 1; j <= 9; j++)
            {
                if (test == j.ToString().Repeat(test.Length))
                {
                    return true;
                }
            }


            for (int n = 2; n < number.Length / 2; n++)
            {
                var pattern = number.Substring(0, n);
                var matches = Regex.Matches(number, pattern);

                if (matches.Count == numeratorLength)
                {
                    return true;
                }

                if (matches.Count > 1)
                {
                    var sequenceLength = matches[1].Index - matches[0].Index;
                    if (sequenceLength == matches[0].Length)
                    {
                        if (sequenceLength > maxSequenceLength)
                        {
                            maxSequenceLength = sequenceLength;
                            answer = i;
                        }
                        Console.WriteLine($"{i}: {sequenceLength} {pattern}");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
