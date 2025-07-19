using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace timus.in_progress
{
    public class timus_1484
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var x = array[0];
            var y = array[1];
            var n = array[2];
            (x * n + a)/(n + a) -> y
            (x + a)/(a + 1) -> y
            x / (a + 1) + 1 -> y
            x / (a + 1) -> y - 1

            // x y n
            // 9.5 2.0 12 

            // sum = x * n + v;
            // all = n + v
            // y = Math.Round((sum / all), 1)
            // y = Math.Round(((x * n + v)/(n + v)), 1)
            // y * (n + v) = x * n + v
            // y * n + v * y = x * n + v
            // n * (y - x) = v(1 - y)

            // v = n * (y - x) / (1 - y)

            // 12 + 86 = 98
            // 114 + 86 = 200
            // 200 / 98 = 2.04
        }
    }
}