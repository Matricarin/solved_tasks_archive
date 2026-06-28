using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_2012
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            for(int i = 1; i <= 239; i++)
            {
                if(i % 45 == 0)
                {
                    num++;
                }
            }

            if(num >= 12)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            /* Простое решение
            if(num >= 7)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            */
        }
    }
}