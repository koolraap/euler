using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            var max = value.Length / 2;

            for (int i=0; i < max; )
            {
                if (value[i] != value[value.Length-(++i)])
                {
                    return false;
                }
            }

            return true;
        }

        public static long SumDigits(this string value)
        {
            long total = 0;

            for (int i = 0; i < value.Length; i++)
            {
                total += (long) char.GetNumericValue(value[i]);
            }

            return total;
        }

        public static long AlphabeticalValue(this string value)
        {
            var result = 0L;

            for (int i = 0; i < value.Length; i++)
            {
                result += (long)value[i] - 64;
            }

            return result;
        }


        static long maxPandigital = 0;
        static ConcurrentDictionary<string, long> PandigitalCache = new ConcurrentDictionary<string, long>();

        public static bool IsPandigitalFast(this string value)
        {
            return value.ToCharArray().Distinct().Count() == value.Length;
        }

        public static bool IsPandigital(this string value)
        {
            var x = value.ToCharArray().ToList();
            x.Sort();
            var num = string.Concat(x);
            var n = long.Parse(num);

            if (n < maxPandigital)
            {
                long dummy;
                return PandigitalCache.TryGetValue(value, out dummy);
            }

            var isPandigital = true;
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (char.GetNumericValue(num[i + 1]) - char.GetNumericValue(num[i]) != 1)
                {
                    isPandigital = false;
                    break;
                }
            }

            if (isPandigital)
            {
                PandigitalCache.AddOrUpdate(value, n, (q, y) => { throw new Exception("Whoops"); });
            }

            return isPandigital;
        }



        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static string ToWords(this long value)
        {
            var Ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var Tens = new string[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            var Other = new string[] { "Hundred", "Thousand", "Million" };

            if (value < 20)
            {
                return Ones[value];
            }

            if (value < 100)
            {
                var x = Tens[value / 10] + " " + Ones[value % 10];
            }

            var thousands = 0;
            var hundreds = 0;

            var result = "";
            if (value > 999)
            {
                thousands = (int)char.GetNumericValue(value.ToString(), 0);

                result += Ones[thousands] + " Thousand ";

                value = long.Parse(value.ToString().Substring(1, 3));
            }

            if (value > 99)
            {
                hundreds = (int)char.GetNumericValue(value.ToString(), 0);

                result += " " + Ones[hundreds] + " Hundred ";

                value = long.Parse(value.ToString().Substring(1, 2));

                if (value > 0)
                {
                    result += " and ";
                }
            }

            if (value > 0 && value < 20)
            {
                result += " " + Ones[value];
            }
            else if (value > 0)
            {
                result += " " + Tens[value / 10] + " " + Ones[value % 10];
            }

            return result.Trim().Replace("  ", " ");
        }

        public static string Rotate(this string value)
        {
            var max = 1;

            var result = "";

            for (var i = 0; i < max; i++)
            {
                result += value.Substring(1, value.Length - 1) + value[0];
            }

            return result;
        }

        // https://dzone.com/articles/find-all-permutations-string-c
        public static List<string> Permutations(this string word)
        {
            if (word.Length == 2)
            {
                char[] _c = word.ToCharArray();
                string s = new string(new char[] { _c[1], _c[0] });
                return new string[]
                {
                    word,
                    s
                }.ToList();
            }

            var _result = new List<string>();
            var _subsetPermutations = word.Substring(1).Permutations();
            var _firstChar = word[0];
            foreach (string s in _subsetPermutations)
            {
                string _temp = _firstChar.ToString() + s;
                _result.Add(_temp);
                char[] _chars = _temp.ToCharArray();
                for (int i = 0; i < _temp.Length - 1; i++)
                {
                    char t = _chars[i];
                    _chars[i] = _chars[i + 1];
                    _chars[i + 1] = t;
                    string s2 = new string(_chars);
                    _result.Add(s2);
                }
            }
            return _result;
        }

        public static string Sort(this string value)
        {
            var x = value.ToCharArray().ToList();
            x.Sort();

            return string.Concat(x);
        }

        public static string Repeat(this char chatToRepeat, int repeat)
        {

            return new string(chatToRepeat, repeat);
        }
        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }

        public static string Reverse(this string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
