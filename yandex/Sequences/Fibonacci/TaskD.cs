using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Fibonacci
{
    public class TaskD
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = long.Parse(reader.ReadLine());

            var old = 0;
            var next = 1;

            if(n == 0)
            {
                writer.WriteLine(0);
                return;
            }
            
            if(n == 1)
            {
                writer.WriteLine(1);
                return;
            }
            var result = 1;
            
            for(long i = 2; i <= n; i++)
            {
                var newOld = next;
                next = (old + next) % 10;
                result += next;
                old = newOld;
            }

            writer.WriteLine(result % 10);
        }
    }
}