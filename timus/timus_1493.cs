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
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;
            
            var ticket = Console.ReadLine();
            int number = int.Parse(ticket);
            var next = number + 1;
            var previous = number - 1;
            if (IsLucky(next) || IsLucky(previous))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static bool IsLucky(int num)
        {
            var number = num.ToString("D6");
            var first = AsInt(number[5]) + AsInt(number[4]) + AsInt(number[3]);
            var second = AsInt(number[2]) + AsInt(number[1]) + AsInt(number[0]);
            return first == second;
        }

        private static int AsInt(char c)
        {
            return c - '0';
        }
    }
}