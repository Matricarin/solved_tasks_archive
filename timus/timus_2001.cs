using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_2001
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;

            var first = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var second = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var third = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine($"{first[0] - third[0]} {first[1] - second[1]}");
        }
    }
}