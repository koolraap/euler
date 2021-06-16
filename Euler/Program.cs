using Euler.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Go();
        }

        public void Go()
        {
            // Get all problems
            var problems = typeof(Program).Assembly.GetTypes()
                .Where(t => t.GetTypeInfo()
                    // implementing IProblem (generic interface, could confirm that)
                    .ImplementedInterfaces
                    .Any(ii => ii.Name.StartsWith("IProblem"))
                    &&
                    // except Obsolete (sloooow) ones
                    t.GetCustomAttribute<ObsoleteAttribute>() == null
                    && (t.GetCustomAttribute<ProblemAttribute>() == null
                    || t.GetCustomAttribute<ProblemAttribute>().LongRunning == false)
                )
                .OrderByDescending(x => x.Name, new AlphanumericComparer());

            var priorities = typeof(Program).Assembly.GetTypes()
                .Where(t => t.GetTypeInfo()
                    // implementing IProblem (generic interface, could confirm that)
                    .ImplementedInterfaces
                    .Any(ii => ii.Name.StartsWith("IProblem"))
                    &&
                    t.GetCustomAttribute<ObsoleteAttribute>() == null
                    &&
                    (t.GetCustomAttribute<ProblemAttribute>() != null
                    && t.GetCustomAttribute<ProblemAttribute>().Priority == true)
                )
                .OrderByDescending(x => x.Name, new AlphanumericComparer());

            if (priorities.Count() > 0)
            {
                //problems = priorities;
            }

            // Invoke
            foreach (var problem in problems.OrderBy(p => p.Name))
            {
                try
                {
                    var sw = Stopwatch.StartNew();
                    var method = problem.GetTypeInfo().GetMethods().Where(m => m.Name == "Solve").FirstOrDefault();
                    var instance = Activator.CreateInstance(problem);

                    Console.Write("{0}: ", problem.Name);
                    var result = method.Invoke(instance, null);
                    Console.WriteLine("{0} in {1} ms", result, sw.ElapsedMilliseconds);
                }
                catch (Exception ex)
                {
                    int i = 0;
                }
            }

            // Invoke
            Parallel.ForEach(problems, (problem) => {
                var sw = Stopwatch.StartNew();
                var method = problem.GetTypeInfo().GetMethods().Where(m => m.Name == "Solve").FirstOrDefault();
                var instance = Activator.CreateInstance(problem);

                Console.Write("{0}: ", problem.Name);
                var result = method.Invoke(instance, null);
                Console.WriteLine("{0} in {1} ms", result, sw.ElapsedMilliseconds);
            });

            Console.WriteLine("\nFinished");

            Console.ReadKey();
        }
    }
}
