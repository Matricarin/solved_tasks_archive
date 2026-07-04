using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace yandex.DataStructures.Dictionary
{
    public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;
        public static void Main(string[] args)
        {
            using (_reader = new StreamReader("input.txt"))
            {
                using (_writer = new StreamWriter("output.txt"))
                {
                    var dict = new Dictionary<Fraction, int>();

                    var n = int.Parse(_reader.ReadLine());

                    for (int i = 0; i < n; i++)
                    {
                        var array = Array.ConvertAll
                        (
                            _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                            int.Parse
                        );

                        var item = new Fraction(array[0], array[1]);

                        if (!dict.TryAdd(item, 1))
                        {
                            dict[item]++;
                        }
                    }

                    var maxRepeatAmount = dict.Max(i => i.Value);

                    var repeated = dict.Where(kv => kv.Value == maxRepeatAmount)
                        .Min(kv => kv.Key);

                    _writer.WriteLine(repeated);
                }
            }
        }
    }

    public readonly struct Fraction : IComparable<Fraction>
    {
        public int Numenator { get; }
        public int Denumenator { get; }

        public Fraction(int num, int denum)
        {
            var devider = GCD(num, denum);

            Numenator = num / devider;
            Denumenator = denum / devider;
        }
        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a | b;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numenator, Denumenator);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is not Fraction other)
            {
                return false;
            }

            return other.Numenator.Equals(Numenator) && other.Denumenator.Equals(Denumenator);
        }

        public override string ToString()
        {
            return $"{Numenator} {Denumenator}";
        }

        public int CompareTo(Fraction other)
        {
            var currentLedNum = Numenator * other.Denumenator;
            var otherLedNum = other.Numenator * Denumenator;

            if (currentLedNum == otherLedNum)
            {
                return 0;
            }
            if (currentLedNum > otherLedNum)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }


}