using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1493
    {
        public static void Main(string[] args)
        {
            var ticket = Console.ReadLine();
            int number = int.Parse(ticket);

            if (IsLucky(number - 1) || IsLucky(number + 1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static bool IsLucky(int num)
        {
            var str = num.ToString("D6"); 
            int sum1 = str[0] - '0' + str[1] - '0' + str[2] - '0';
            int sum2 = str[3] - '0' + str[4] - '0' + str[5] - '0';
            return sum1 == sum2;
        }
    }
}