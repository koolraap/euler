using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem5 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            for (int i = 20; ; i += 20)
            {
                var found = true;
                for (int j = 2; j <= 20; j++)
                {
                    if (i % j != 0)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return i;
                }
                    
            }
        }
    }
}
