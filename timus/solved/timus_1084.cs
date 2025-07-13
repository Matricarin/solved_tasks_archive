using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1084
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var a = input[0];
            var r0 = input[1];
            var r1 = a * Math.Sqrt(2.0) / 2.0;

            double s = 0.0;
            if(r0 <= 0.5 * a)
            {
                s = Math.PI * r0 * r0;
            }
            else if(r0 >= r1)
            {
                s = a * a;
            }
            else
            {
                var angle = 2 * Math.Acos((a * 0.5) / r0);
                s = Math.PI * r0 * r0 - 2 * r0 * r0 * (angle - Math.Sin(angle));
            }
            
            Console.WriteLine($"{s:f3}");
        }
    }
}