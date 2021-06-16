using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Attributes
{
    public class ProblemAttribute : Attribute
    {
        public ProblemAttribute()
        { }

        public bool LongRunning { get; set; }
        public bool Priority { get; set; }
    }
}
