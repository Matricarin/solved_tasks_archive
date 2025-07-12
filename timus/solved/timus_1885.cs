using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1885
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var h = input[0];
            var t = input[1];
            var v = input[2];
            var x = input[3];
            
            var tmax = Math.Min(t, h / x);

            var tmin = Math.Max(0.0, (h - x * t) / (v - x));

            Console.WriteLine($"{tmin} {tmax}");           
        }
    }
}