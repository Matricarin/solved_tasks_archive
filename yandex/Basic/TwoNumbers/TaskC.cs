using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Basic.TwoNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var pool = new string[]{a, b};

            var s = string.Create(2 * n, pool, (chars, pool) =>
            {
                for(int i = 0; i < 2 * n; i++)
                {
                    var idx = i / 2;
                    if(i % 2 == 0)
                    {
                        chars[i] = pool[0][idx];
                    }
                    else
                    {
                        chars[i] = pool[1][idx];
                    }
                }
            });

            Console.WriteLine(s);
        }
    }
}