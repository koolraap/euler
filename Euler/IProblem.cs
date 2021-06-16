using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    interface IProblem<T>
    {
        Task<T> Solve();

    }
}
