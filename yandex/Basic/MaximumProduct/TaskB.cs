using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace yandex.Basic.MaximumProduct
{
    public class TaskB
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            if(n <= 2)
            {
                writer.WriteLine("No");
            }
            else
            {
                double c = n + (n - 3);
                double d = c / n;
                if(d <= 1.5)
                {
                    writer.WriteLine("No");
                }
                else
                {
                    writer.WriteLine("Yes");
                    writer.WriteLine(string.Join(" ", Enumerable.Range(1, n).OrderByDescending(i => i)));
                }
            }
        }
    }
}