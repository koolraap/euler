using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems.P000
{
    [Problem(Priority = true)]
    public class Problem45 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var answer = 0L;

            var primer = 225000L;
            primer.Hexagonal().ToList();
            primer.Pentagonal().ToList();
            primer.Triangles().ToList();

            var hexes = MathStuff.HexCache.OrderBy(z => z.Key).ToList();
            var pents = MathStuff.PentCache.OrderBy(z => z.Key).ToList();
            var tris = MathStuff.TriangleCache.ToList();
            tris.Sort();

            foreach (var t in tris.Where(t => t >= 40755))
            {
                if (t.IsPentagonal() && t.IsHexagonal())
                {
                    answer = t;
                }
            }

            return answer;
        }
    }
}
