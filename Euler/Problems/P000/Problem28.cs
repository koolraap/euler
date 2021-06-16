using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem28 : IProblem<long>
    {
        enum Direction { Right, Down, Left, Up, Whoops };

        public async Task<long> Solve()
        {
            Console.WriteLine();
            var max = 1001;

            // diag up right
            int max2 = max / 2 + 1;
            var add = 1L;
            var tote = 0L;
            
            for (var n = 0L; n < max2; n++)
            {
                add = Convert.ToInt64(Math.Pow(n * 2 + 1, 2));
                tote += add;
//                Console.WriteLine($"n={n} add={add} tote={tote}");
            }

            var answer1 = tote;
//            Console.WriteLine($"answer1={answer1}");

            // diag down right
            tote = 0L;
            var carry = 0L;
            for (var n = 0L; n < max2; n++)
            {
                if (n == 0)
                {
                    add = 1;
                }
                else if (n == 1)
                {
                    add = 2;
                }
                else if (n > 1)
                {
                    add = 2 + (n - 1) * 8;
                }

                carry += add;

                tote += carry;

//                Console.WriteLine($"n={n} add={add} carry={carry} tote={tote}");
            }

            var answer2 = tote;
//            Console.WriteLine($"answer2={answer2}");

            // diag up left
            tote = 0L;
            carry = 0L;
            for (var n = 0L; n < max2; n++)
            {
                if (n == 0)
                {
                    add = 1;
                }
                else
                {
                    add = n * 8 - 2;
                }

                carry += add;
                tote += carry;
//                Console.WriteLine($"n={n} add={add} carry={carry} tote={tote}");
            }

            var answer3 = tote;
//            Console.WriteLine($"answer3={answer3}");

            tote = 0L;
            carry = 0L;

            // diag down left
            for (var n = 0L; n < max2; n++)
            {
                if (n == 0)
                {
                    // already done
                    add = 1;
                }
                else
                {
                    add = (n - 1) * 8 + 4;
                }

                carry += add;

                tote += carry;
//                Console.WriteLine($"n={n} add={add} carry={carry} tote={tote}");
            }

            var answer4 = tote;
//            Console.WriteLine($"answer4={answer4}");


            var answer = answer1 + answer2 + answer3 + answer4 - 3;

            return answer;
        }
    }
}

