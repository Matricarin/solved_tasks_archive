using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Dividers
{
    public class TaskB
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");


            var arr = Array.ConvertAll(
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            long a = arr[0];
            long b = arr[1];

            writer.WriteLine(a * b / GCD(a, b));
        }

        private static long GCD(long a, long b)
        {
            while(a > 0 && b > 0)
            {
                if(a >= b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return Math.Max(a, b);
        }
    }
}