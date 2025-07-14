using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1877
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());

            var answer = string.Empty;

            for(int i = 0; i < 10000; i++)
            {
                if((i + 1) % 2 == 0)
                {
                    if(i == second)
                    {
                        answer = "yes";
                    }
                }

                if((i + 1)% 2 != 0)
                {
                    if(i == first)
                    {
                        answer = "yes";
                    }
                }
            }
            if(string.IsNullOrEmpty(answer))
            {
                answer = "no";
            }

            Console.WriteLine(answer);
        }
    }
}