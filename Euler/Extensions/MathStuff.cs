using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Euler.Extensions;

namespace Euler
{
    public static class MathStuff
    {
        public static long SumDigits(this long value)
        {
            var sum = 0L;
            while (value != 0)
            {
                sum += value % 10;
                value /= 10;
            }

            return sum;
        }


        private static ConcurrentDictionary<long, long> FactorialCache = new ConcurrentDictionary<long, long>();

        public static long Factorial(this long value)
        {
            var result = FactorialCache.GetOrAdd(value, (x) =>
            {
                var sum = 1L;
                for (var i = 1L; i <= value; i++)
                {
                    sum *= i;
                }

                return sum;
            });

            return result;
        }

        /// <summary>
        /// Returns a list of multiples of n less than the int. (eg 7 has 2 multipes of 3: 3 and 6)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public static List<int> MultiplesLessThan(this int value, int multiple)
        {
            var result = new List<int>();

            var max = value / multiple;

            for (int i = multiple; i < value; i += multiple)
            {
                result.Add(i);
            }

            return result;
        }

        public static IEnumerable<int> FibonacciSequence(this int value)
        {
            var result = new List<int>();

            int fibTwo = 0;
            int fibOne = 1;
            int fib = 1;

            while (fib < value)
            {
                yield return fib;
                fib = fibTwo + fibOne;
                fibTwo = fibOne;
                fibOne = fib;
            }
        }

        public static IEnumerable<decimal> FibonacciSequence(this decimal value)
        {
            var result = new List<decimal>();

            decimal fibTwo = 0;
            decimal fibOne = 1;
            decimal fib = 1;

            while (fib < value)
            {
                yield return fib;
                fib = fibTwo + fibOne;
                fibTwo = fibOne;
                fibOne = fib;
            }
        }

        public static IEnumerable<BigNumber> FibonacciSequence(this BigNumber value)
        {
            var result = new List<BigNumber>();

            BigNumber fibTwo = (BigNumber)0;
            BigNumber fibOne = (BigNumber)1;
            BigNumber fib = (BigNumber)1;

            while (fib < value)
            {
                yield return fib;
                fib = fibTwo + fibOne;
                fibTwo = fibOne;
                fibOne = fib;
            }
        }

        /// <summary>
        /// Returns Fibonacci for x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int FibonacciValue(this int x)
        {
            if (x <= 1)
            {
                return 1;
            }

            return FibonacciValue(x - 1) + FibonacciValue(x - 2);
        }

        private class FactorThreadStart
        {
            public long Value;
            public long Start;
            public long End;
            public ConcurrentStack<long> Stack;
        }

        private static void FactorsWorker(object parameters)
        {
            var pts = parameters as FactorThreadStart;

            for (long divisor = pts.Start; divisor < pts.End; divisor += 2)
            {
                if (pts.Value % divisor == 0)
                {
                    pts.Stack.Push(divisor);
                }
            }
        }

        public static IEnumerable<long> Factors(this long value)
        {
            var max = (long)Math.Sqrt(value);

            if (value % 2 == 0)
            {
                yield return 2;
            }

            var stack = new ConcurrentStack<long>();

            var pts1 = new FactorThreadStart()
            {
                Value = value,
                Start = 3,
                End = max % 4 != 0 ? max / 4 + 1 : max / 4,
                Stack = stack
            };

            var pts2 = new FactorThreadStart()
            {
                Value = value,
                Start = pts1.End + 2,
                End = pts1.End + max / 4,
                Stack = stack
            };

            var pts3 = new FactorThreadStart()
            {
                Value = value,
                Start = pts2.End + 2,
                End = pts2.End + max / 4,
                Stack = stack
            };

            var pts4 = new FactorThreadStart()
            {
                Value = value,
                Start = pts3.End + 2,
                End = max,
                Stack = stack
            };

            var p1 = new ParameterizedThreadStart(FactorsWorker);
            var t1 = new Thread(FactorsWorker);
            t1.Start(pts1);

            var p2 = new ParameterizedThreadStart(FactorsWorker);
            var t2 = new Thread(FactorsWorker);
            t2.Start(pts2);

            var p3 = new ParameterizedThreadStart(FactorsWorker);
            var t3 = new Thread(FactorsWorker);
            t3.Start(pts3);

            var p4 = new ParameterizedThreadStart(FactorsWorker);
            var t4 = new Thread(FactorsWorker);
            t4.Start(pts4);

            long factor;
hackTown:
            while (stack.TryPop(out factor))
            {
                //Console.Write("{0}, ", factor);
                yield return factor;
            }

            if (t1.ThreadState != ThreadState.Stopped || t2.ThreadState != ThreadState.Stopped || t3.ThreadState != ThreadState.Stopped || t4.ThreadState != ThreadState.Stopped)
            {
                Thread.Sleep(100);
                goto hackTown;
            }

            //Console.WriteLine();
        }

        public static IEnumerable<long> Factors2(this long value)
        {
            for (long divisor = 1; divisor <= value / 2; divisor++)
            {
                if (value % divisor == 0)
                {
                    yield return divisor;
                }
            }
        }


        public static IEnumerable<long> PrimeFactors(this long value)
        {
            // Take out the 2s.
            while (value % 2 == 0)
            {
                yield return 2;
                value /= 2;
            }

            // Take out other primes.
            long factor = 3;
            while (factor * factor <= value)
            {
                if (value % factor == 0)
                {
                    // This is a factor.
                    yield return factor;
                    value /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }

            // If num is not 1, then whatever is left is prime.
            if (value > 1)
            {
                yield return value;
            }
        }

        private static long TriangleMax = 0L;
        public static ConcurrentBag<long> TriangleCache = new ConcurrentBag<long>();

        public static IEnumerable<long> Triangles(this long value, long start = 1)
        {
            for (long i = start; i < value; i++)
            {
                var triangle = (long)(i / 2.0 * (i + 1));

                if (!TriangleCache.Contains(triangle))
                {
                    TriangleCache.Add(triangle);
                    TriangleMax = i;
                }

                yield return triangle;
            }
        }

        public static bool IsTriangle(this long value)
        {
            // cache more
            if (value > TriangleMax)
            {
                value.Triangles(TriangleMax + 1).ToList();
            }

            return TriangleCache.Contains(value);
        }

        private static ConcurrentDictionary<long, long> PrimeCache = new ConcurrentDictionary<long, long>();

        public static bool IsPrime(this long value)
        {
            if (value == 2)
            {
                return true;
            }

            if (value % 2 == 0 || value == 1 || value < 0)
            {
                return false;
            }

            if (PrimeCache.TryGetValue(value, out _))
            {
                return true;
            }

            var max = Math.Sqrt(value);

            for (int i = 3; i < max+1; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            PrimeCache.TryAdd(value, value);

            return true;
        }

        public static IEnumerable<long> Primes(this long value)
        {
            if (value > 1)
            {
                yield return 2;

                for (var i = 3L; i < value; i += 2)
                {
                    if (i.IsPrime())
                    {
                        yield return i;
                    }
                }
            }
        }

        public static IEnumerable<long> Squares(this long value)
        {
            if (value > 1)
            {
                for (var i = 1L; i < value; i += 1)
                {
                    yield return i * i;
                }
            }
        }

        /// <summary>
        /// Factors add to greater than the number
        /// </summary>
        public static bool IsAbundant(this long value)
        {
            var sum = value.Factors2().Sum();

            return sum > value;
        }

        /// <summary>
        /// Factors add to less than the number
        /// </summary>
        public static bool IsDeficient(this long value)
        {
            var sum = value.Factors2().Sum();

            return sum < value;
        }

        public static bool IsInteger(this double value)
        {
            return value == Math.Truncate(value);
        }

        public static IEnumerable<long> Divisors(this long value)
        {
            var max = Math.Sqrt(value);

            for (int i = 1; i <= max; i++)
            {
                if (value % i == 0)
                {
                    yield return i;

                    var rem = value / i;
                    if (rem != i)
                    {
                        yield return rem;
                    }
                }
            }
        }

        public static IEnumerable<ulong> Collatz(this ulong value)
        {
            if (value == 1)
            {
                yield return 1;
            }

            while (value > 1)
            {

                if ((value % 2) == 0)
                {
                    value = value / 2;
                }
                else
                {
                    value = 3 * value + 1;
                }

                yield return value;
            }
        }

        public static ConcurrentDictionary<long, long> PentCache = new ConcurrentDictionary<long, long>();
        public static long PentCacheMax = 0;

        public static IEnumerable<long> Pentagonal(this long value, long start = 1)
        {
            //            Pn = n(3n−1) / 2.
            for (var i = start; i <= value; i++)
            {
                var pent = (i * (3 * i - 1)) / 2;

                if (pent > PentCacheMax)
                {
                    PentCache.AddOrUpdate(pent, i, (x, y) => pent);
                    Interlocked.Exchange(ref PentCacheMax, pent);
                }

                yield return pent;
            }
        }

        public static bool IsPentagonal(this long value)
        {
            if (value > PentCacheMax)
            {
                Pentagonal(value, PentCacheMax + 1).ToList();
            }

            return PentCache.ContainsKey(value);
        }

        public static ConcurrentDictionary<long, long> HexCache = new ConcurrentDictionary<long, long>();
        public static long HexCacheMax = 0;

        public static IEnumerable<long> Hexagonal(this long value, long start = 1)
        {
            // Hn = n(2n−1) 
            for (var i = start; i <= value; i++)
            {
                var Hex = (i * (2 * i - 1));

                if (Hex > HexCacheMax)
                {
                    HexCache.AddOrUpdate(Hex, i, (x, y) => Hex);
                    Interlocked.Exchange(ref HexCacheMax, Hex);
                }

                yield return Hex;
            }
        }

        public static bool IsHexagonal(this long value)
        {
            if (value > HexCacheMax)
            {
                Hexagonal(value, HexCacheMax + 1).ToList();
            }

            return HexCache.ContainsKey(value);
        }
    }
}
