using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acmp.in_progress
{
    public class acmp_680
    {
        public static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());

            long result = 3;
            for(int i = 1; i < a; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}