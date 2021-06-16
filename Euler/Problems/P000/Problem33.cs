using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public class Problem33 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var aProd = 1;
            var bProd = 1;

            for (int a = 10; a < 100; a++)
            {
                for (int b = a + 1; b < 100; b++)
                {
                    var ch = ' ';
                    var aStr = a.ToString();
                    var bStr = b.ToString();

                    var matches = 0;

                    if (aStr.ToCharArray().Contains(bStr[0]))
                    {
                        matches++;
                        ch = bStr[0];
                    }

                    if (aStr.ToCharArray().Contains(bStr[1]))
                    {
                        matches++;
                        ch = bStr[1];
                    }

                    if (matches == 1 && ch != '0')
                    {
                        aStr = aStr.Replace(ch.ToString(), "");
                        bStr = bStr.Replace(ch.ToString(), "");

                        if (aStr.Length > 0 && bStr.Length > 0)
                        {

                            var a2 = int.Parse(aStr);
                            var b2 = int.Parse(bStr);

                            if ((double)a / (double)b == (double)a2 / (double)b2)
                            {
                                aProd *= a2;
                                bProd *= b2;
                                Console.WriteLine("{0}/{1}=={2}/{3}", a, b, a2, b2);
                            }
                        }
                    }

                }
            }

            var result = bProd / aProd;

            return result;
        }
    }
}
