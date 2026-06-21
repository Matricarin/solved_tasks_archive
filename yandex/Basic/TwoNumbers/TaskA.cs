using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Basic.TwoNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"{array[0] + array[1]}");
        }
    }
}