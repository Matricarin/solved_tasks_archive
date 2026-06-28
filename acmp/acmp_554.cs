using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acmp.in_progress
{
    public class acmp_554
    {
        public static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());

            var result = 1;

            for(int i = 0; i <= a; i++)
            {
                result += i;
            }

            Console.WriteLine(result);
        }
    }
}