using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Fibonacci
{
    public class TaskA
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            long first = 0;
            long second = 1;

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
            long third = 0;

            for(int i = 2; i <= n; i++)
            {                 
                third = second + first;
                first = second;
                second = third;
            }

            writer.WriteLine(third);
        }
    }
}