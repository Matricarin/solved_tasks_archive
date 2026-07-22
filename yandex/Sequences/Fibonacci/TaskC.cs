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

            BigInteger zero = BigInteger.One;
            BigInteger first = BigInteger.One;
            BigInteger fn = new BigInteger();

            if(arr[0] == 1)
            {
                fn = zero;
            }
            else if(arr[0] == 1)
            {
                fn = first;
            }
            else
            {
                for(long i = 3; i <= arr[0]; i++ )
                {
                    fn = zero + first;
                    zero = first;
                    first = fn;
                }
            }

            var mod = fn % new BigInteger(arr[1]);

            writer.WriteLine(mod.ToString());
        }        
    }
}