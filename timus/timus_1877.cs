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

            if((first + 1) % 2 == 0 && (second + 1) % 2 != 0)
            {  
                answer = "no";
            }
            else
            {
                answer = "yes";
            }

            Console.WriteLine(answer);
        }
    }
}