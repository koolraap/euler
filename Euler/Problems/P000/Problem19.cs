using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem19 : IProblem<int>
    {
        public async Task<int> Solve()
        {
            var sundays = 0;

            for (var dt = new DateTime(1901,1,1); dt < new DateTime(2001,1,1); dt = dt.AddDays(1))
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday && dt.Day == 1)
                {
                    sundays++;
                }
            }

            return sundays;
        }
    }
}
