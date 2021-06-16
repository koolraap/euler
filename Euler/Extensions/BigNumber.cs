using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Extensions
{
    // Arbitrary precision... positive integers. Forgot about -ve :-)
    public class BigNumber
    {
        private const int maxlength = 4001;

        // 0 is LSD, maxlength-1 is MSD
        private int[] _value = new int[maxlength];

        public BigNumber()
        {
        }

        public BigNumber(int value) : this(value.ToString())
        {
        }

        public BigNumber(long value) : this(value.ToString())
        {
        }

        public BigNumber(decimal value) : this(value.ToString())
        {
        }

        public BigNumber(double value) : this(Math.Round(value).ToString())
        {
        }

        public BigNumber(float value) : this(Math.Round(value).ToString())
        {
        }

        public static BigNumber MaxValue
        {
            get
            {

                return new BigNumber(new string('9', 1001));

            }
        }

        private BigNumber(string value)
        {
            var chars = value.Reverse().ToArray();
            var max = value.Length;

            for (var i = 0; i < max; i++)
            {
                var v = char.GetNumericValue(chars[i]);

                if ((int)v < 0)
                {
                    throw new InvalidOperationException("Can't have -ve BigNumber");
                }
                _value[i] = (int)v;
            }
        }

        public int this[int digit]
        {
            get { return _value[digit]; }
            set { _value[digit] = value; }
        }

        public static explicit operator BigNumber(int value)
        {
            return new BigNumber(value);
        }

        public static explicit operator BigNumber(long value)
        {
            return new BigNumber(value);
        }

        public static bool operator ==(BigNumber a, BigNumber b)
        {
            for (int i = 0; i < maxlength; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(BigNumber a, BigNumber b)
        {
            for (int i = 0; i < maxlength; i++)
            {
                if (a[i] != b[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {
            var alen = a.Length;
            var blen = b.Length;

            if (alen < blen)
            {
                return true;
            }

            if (alen > blen)
            {
                return false;
            }

            for (int i = alen - 1; i >= 0; i--)
            {
                if (a[i] < b[i])
                {
                    return true;
                }

                if (a[i] > b[i])
                {
                    return false;
                }
            }

            return false;
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            var len = a.Length > b.Length ? a.Length : b.Length;

            for (int i = len; i >= 0; i--)
            {
                if (a[i] <= b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <=(BigNumber a, BigNumber b)
        {
            var al = a.Length;
            var bl = b.Length;

            if (al < bl)
            {
                return true;
            }

            var len = al > bl ? al : bl;

            for (int i = len; i >= 0; i--)
            {
                if (a[i] > b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >=(BigNumber a, BigNumber b)
        {
            var al = a.Length;
            var bl = b.Length;

            if (al > bl)
            {
                return true;
            }

            var len = al > bl ? al : bl;

            for (int i = len; i >= 0; i--)
            {
                if (a[i] < b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var result = new BigNumber();

            var lenA = a.Length;
            var lenB = b.Length;

            var len = lenA > lenB ? lenA : lenB;

            for (int i = 0; i <= len; i++)
            {
                var c = a[i] + b[i];

                var rem = c % 10;
                var carry = c / 10;

                result[i] = result[i] + rem;

                if (result[i] > 9)
                {
                    var rem2 = result[i] % 10;
                    var c2 = result[i] / 10;

                    result[i] = rem2;
                    result[i+1] = result[i+1] + c2;
                }

                result[i + 1] = result[i + 1] + carry;
            }

            return result;
        }

        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            var result = new BigNumber();

            var aLen = a.Length;
            var bLen = b.Length;

            if (a == (BigNumber)0 || b == (BigNumber)0)
            {
                return result;
            }

            for (int i = 0; i < aLen; i++)
            {
                var tally = new BigNumber();
                var n = a[i];

                for (int j = 0; j < bLen; j++)
                {
                    var m = b[j];
                    var v = n * m;

                    var rem = v % 10;
                    var carry = v / 10;

                    tally[j + i] = tally[j + i] + rem;
                    tally[j + i + 1] = carry;
                }

                result = result + tally;
            }

            return result;
        }

        public static BigNumber operator ++(BigNumber a)
        {
            return a + (BigNumber)1;
        }

        public int Length
        {
            get
            {
                var result = maxlength - 1;

                for (; result > 0 && _value[result] == 0; result--)
                {
                    // empty
                }

                return result + 1;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(maxlength);

            bool foundNonZero = false;
            for (int i = maxlength - 1; i >= 0; i--)
            {
                var v = _value[i];

                if ((!foundNonZero && v != 0) || i == 0)
                {
                    foundNonZero = true;
                }

                if (foundNonZero)
                {
                    sb.Append(_value[i]);
                }
            }

            return sb.ToString();
        }
    }

    public static class BigNumberExtensions
    {
        public static BigNumber Pow(this int value, int exp)
        {
            return ((BigNumber)value).Pow((BigNumber)exp);
        }

        public static BigNumber Pow(this BigNumber value, int exp)
        {
            return value.Pow((BigNumber)exp);
        }

        public static BigNumber Pow(this BigNumber value, BigNumber exp)
        {
            var result = new BigNumber();

            if (exp == (BigNumber)0)
            {
                return (BigNumber)1;
            }

            result = value;

            for (BigNumber i = new BigNumber(1); i <= exp; i++)
            {
                //Console.WriteLine("{0}: {1} = {2}", i, result, result.ToString().SumDigits());
                result = result * value;
            }

            return result;
        }
    }

}