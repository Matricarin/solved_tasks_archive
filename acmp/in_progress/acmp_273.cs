using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acmp.in_progress
{
    public class acmp_273
    {
        private static HashSet<int> _hash = new HashSet<int>();
        public static void Main(string[] args)
        {
            var num = Console.ReadLine();
            var count = CountTriples(num, 0, 2);
            Console.WriteLine(count);
        }

        private static int CountTriples(string num, int start, int end)
        {
            var count = 0;

            if(num.Length - 1 < end)
            {
                return count;
            }

            var substring = int.Parse(num.Substring(start, end - start + 1));

            if(_hash.Add(substring))
            {
                return CountTriples(num, start + 1, end + 1) + 1;
            }
            else
            {
                return CountTriples(num, start + 1, end + 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = File.ReadAllText("INPUT.TXT").Trim();
            var set = new HashSet<int>();

            for (int i = 0; i < n.Length; i++)
            {
                for (int j = i + 1; j < n.Length; j++)
                {
                    for (int k = j + 1; k < n.Length; k++)
                    {
                        char a = n[i], b = n[j], c = n[k];
                        if (a == '0') continue; // Трёхзначные числа не могут начинаться с нуля
                        int value = (a - '0') * 100 + (b - '0') * 10 + (c - '0');
                        set.Add(value);
                    }
                }
            }

            File.WriteAllText("OUTPUT.TXT", set.Count.ToString());
        }
    }
}
