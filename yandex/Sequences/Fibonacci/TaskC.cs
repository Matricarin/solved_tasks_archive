using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace yandex.Sequences.Fibonacci
{
    public class TaskC
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var arr = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            var period = GetPisanoPeriod(arr[1]);

            BigInteger current = BigInteger.Zero;
            BigInteger next = BigInteger.One;
            for(long i = 2; i <= period; i++)
            {
                var oldNext = next;
                next = current + next;
                current = next;
            }

            writer.WriteLine(next % new BigInteger(arr[1]));            
        }     

        public static long GetPisanoPeriod(long m)
        {
            long current = 0;
            long next = 1;
            long period = 0;
            while(true)
            {
                var oldNext = next;
                next = (current + next) % m;
                current = oldNext;
                period++;
                if(current == 0 && next == 1)
                {
                    return period;
                }
            }
        }   
    }
}