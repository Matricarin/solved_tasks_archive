using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1330
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;

            var unitAmount = int.Parse(Console.ReadLine());
            var units = new List<int>(GetUnits(unitAmount));

            var queryAmount = int.Parse(Console.ReadLine());
            var list = new List<long>();

            for (var j = 0; j < queryAmount; j++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var start = array[0] - 1;
                var length = array[1] - 1;
                if(start == 0)
                {
                    list.Add(units[length]);
                }
                else
                {
                    list.Add(units[length] - units[start - 1]);
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }

        private static int[] GetUnits(int amount)
        {
            var arr = new int[amount];
            for (var i = 0; i < amount; i++)
            {
                if(i == 0)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                else
                {
                    arr[i] = int.Parse(Console.ReadLine()) + arr[i - 1];
                }
            }
            return arr;
        }

    }
}