using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    [Problem(Priority = true)]
    public class Problem51 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var found = false;
            var answer = -1L;

            for (var n = 100000L; n < 1000000 ; n++)
            {
                var n6 = n * 6;

                var nSum = n.SumDigits();

                if (n6.SumDigits() == nSum)
                {
                    var n5 = n * 5;
                    
                    if (n5.SumDigits() == nSum)
                    {
                        var n4 = n * 4;

                        if (n4.SumDigits() == nSum)
                        {
                            var n3 = n * 3;

                            if (n3.SumDigits() == nSum)
                            {
                                var n2 = n * 2;

                                if (n2.SumDigits() == nSum)
                                {
                                    var s = n.ToString().Sort();
                                    var s2 = n2.ToString().Sort();
                                    var s3 = n3.ToString().Sort();
                                    var s4 = n4.ToString().Sort();
                                    var s5 = n5.ToString().Sort();
                                    var s6 = n6.ToString().Sort();

                                    if (s == s2 && s == s3 && s == s4 && s == s5 && s == s6)
                                    {
                                        found = true;
                                        answer = n;


                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return answer;
        }

    }
}
