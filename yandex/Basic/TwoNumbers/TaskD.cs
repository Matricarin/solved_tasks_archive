using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Basic.TwoNumbers
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var input = ReadIntArray();
            var a = new int[input[0]][];
            var b = new int[input[0]][];
            var result = new int[input[0]][];

            for(int i = 0; i < a.Length; i++)
            {
                a[i] = ReadIntArray();
            }

            for(int i = 0; i < b.Length; i++)
            {
                b[i] = ReadIntArray();
            }

            for(int j = 0; j < input[0]; j++)
            {
                result[j] = new int[input[1]];

                for(int k = 0; k < input[1]; k++)
                {
                    result[j][k] = a[j][k] + b[j][k];
                }
            }

            foreach(var row in result)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}