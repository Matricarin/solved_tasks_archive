using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Fibonacci
{
    public static class TaskB
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var first = 0;
            var second = 1;

            if(n == 0)
            {
                writer.WriteLine(first);
                return;
            }

            if(n == 1)
            {
                writer.WriteLine(second);
                return;
            }

            int mod = 0;

            for(int i = 2; i <= n; i++)
            {
                mod = (first + second) % 10;

                first = second;
                second = mod;
            }

            writer.WriteLine(mod);
        }
    }
}