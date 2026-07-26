using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Dividers
{
    public class TaskA
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var arr = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            var a = arr[0];
            var b = arr[1];
            
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

            var result = Math.Max(a, b);

            writer.WriteLine(result);
        }
    }
}