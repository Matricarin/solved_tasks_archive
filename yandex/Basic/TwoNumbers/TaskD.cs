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

            var row = input[0];
            var column = input[1];

            var a = new int[row][];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadIntArray();
            }

            var result = new int[row][];

            for (int j = 0; j < row; j++)
            {
                result[j] = new int[column];

                var b = ReadIntArray();

                for (int k = 0; k < column; k++)
                {
                    result[j][k] = a[j][k] + b[k];
                }
            }

            foreach (var line in result)
            {
                Console.WriteLine(string.Join(" ", line));
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