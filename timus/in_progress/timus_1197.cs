using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timus.in_progress
{
    public class timus_1197
    {
        private static int[][] matrix = 
        [
            [2,3,4,4],
            [3,4,6,6],
            [4,6,8,8],
            [4,6,8,8],
        ];

        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;

            var amount = int.Parse(Console.ReadLine());
            var array = new string[amount];
            for(int i = 0; i < amount; i++)
            {
                array[i] = Console.ReadLine();
            }
            
            foreach (var item in array)
            {
                var v = item[0] - 'a';
                var h = Convert.ToInt32(item[1]);
                var maxv = 'h' - 'a';
                int zh = 0;
                int zv = 0;
                if(h > 4)
                {
                    zh = 8 - h + 1;
                }
                else
                {
                    zh = h;
                }

                if(v > 4)
                {
                    zv = 8 - v + 1;
                }
                else
                {
                    zv = v;
                }
                
                Console.WriteLine(matrix[zh][zv]);
            }
        }
    }
}