using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler.Attributes;
using Euler.Extensions;

namespace Euler.Problems
{
    public class Card
    {
        public Suit Suit;
        public Face Face;

        public ulong Value;// { get { return GetValue(); } }
    }

    [Obsolete()]
    public class Problem54 : IProblem<long>
    {
        public async Task<long> Solve()
        {
            var lines = File.ReadAllLines(@"problems\p054_words.txt");

            foreach (var line in lines)
            {
                var bothhands = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var hand1 = bothhands.Take(5).Select(h => new Card { Face = (Face)Enum.Parse(typeof(Face), "C" + h[0]), Suit = (Suit)Enum.Parse(typeof(Suit), h[1].ToString())});
                var hand2 = bothhands.Skip(5).Take(5).Select(h => new Card { Face = (Face)Enum.Parse(typeof(Face), "C" + h[0]), Suit = (Suit)Enum.Parse(typeof(Suit), h[1].ToString())});

                if (hand1.PokerValue() > hand2.PokerValue())
                {

                }

            }

            return -1L;
        }
    }

    public enum Suit
    {
        H = 0x040000,
        D = 0x030000,
        C = 0x020000,
        S = 0x010000
    }

    public enum Face
    {
        CA = 0xF,
        CK = 0xE,
        CQ = 0xD,
        CJ = 0xC,
        CT = 0xB,
        C9 = 0xA,
        C8 = 0x9,
        C7 = 0x8,
        C6 = 0x7,
        C5 = 0x6,
        C4 = 0x5,
        C3 = 0x4,
        C2 = 0x3
    }

    public enum HandType
    {
        RoyalFlush = 0xF00000,
        StraightFlush = 0xE00000,
        FourKind = 0xD00000,
        FullHouse = 0xC00000,
        Flush = 0xB00000,
        Straight = 0xA00000,
        ThreeKind = 0x900000,
        TwoPair = 0x800000,
        OnePair = 0x900000,
        High = 0x700000
    }

    public static class IEnumerableExtensions
    {


        const ulong H = 0x040000;
        const ulong D = 0x030000;
        const ulong C = 0x020000;
        const ulong S = 0x010000;



        public static ulong PokerValue(this IEnumerable<Card> cards)
        {
            if (cards.Count() != 5)
            {
                throw new ArgumentException("Poker length isn't 5");
            }

            return 0;
        }

        public static HandType GetHandType(this IEnumerable<Card> cards)
        {
            var isFlush = cards.IsFlush();
            var isStraight = cards.IsStraight();

            // royal flush
            if (isFlush && cards.IsStraight() && cards.Any(c => c.Face == Face.CA))
            {
                return HandType.RoyalFlush;
            }

            // straight flush
            if (isFlush && isStraight)
            {
                return HandType.StraightFlush;
            }

            // four of a kind
            if (cards.Is4Kind())
            {
                return HandType.FourKind;
            }

            // Full house
            if (cards.IsFullHouse())
            {
                return HandType.FullHouse;
            }

            // Flush
            if (cards.IsFlush())
            {
                return HandType.Flush;
            }

            // Straight
            if (isStraight)
            {
                return HandType.Straight;
            }

            // three of a kind
            if (cards.Is4Kind())
            {
                return HandType.ThreeKind;
            }

            // two pairs
            if (cards.IsTwoPair())
            {
                return HandType.TwoPair;
            }

            // one pair
            if (cards.IsPair())
            {
                return HandType.OnePair;
            }

            // high card
            return HandType.High;
        }

        public static bool IsFlush(this IEnumerable<Card> cards)
        {
            return cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public static bool IsStraight(this IEnumerable<Card> cards)
        {
            var max = cards.Max(c => c.Face);
            var min = cards.Min(c => c.Face);

            return max - min == 5;
        }

        public static bool IsFullHouse(this IEnumerable<Card> cards)
        {
            return false;
        }

        public static bool Is4Kind(this IEnumerable<Card> cards)
        {
            var groups = cards.GroupBy(c => c.Face);

            if (groups.Count() == 2)
            {
            }

            return false;
        }

        private static bool IsTwoPair(this IEnumerable<Card> cards)
        {
            return false;
        }

        public static bool IsPair(this IEnumerable<Card> cards)
        {
            var max = cards.Max(c => c.Face);
            var min = cards.Min(c => c.Face);

            return max - min == 5;
        }
    }
}
