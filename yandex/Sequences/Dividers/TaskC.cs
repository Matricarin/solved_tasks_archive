using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Dividers
{
    public class TaskC
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = long.Parse(reader.ReadLine());
            
            var answer = InvertGCD(2, 1, n);

            writer.WriteLine(answer);
        }

        public static string InvertGCD(long a, long b, long n)
        {
            while(a <= n && b <= n)
            {
                var max = Math.Max(a, b);
                var min = Math.Min(a, b);
                if(max <= n && (max + min) <= n)
                {
                    a = max;
                    b = max + min; 
                }
                else
                {
                    break;
                }
            };
            
            return $"{a} {b}";
        }
    }
}

