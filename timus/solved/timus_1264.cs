using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1264
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(input[0] * (input[1] + 1));
        }
    }
}