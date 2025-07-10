using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acmp.in_progress
{
    public class acmp_317
    {
        private static int[] weights;
        private static Dictionary<int,int> memo = new Dictionary<int, int>();
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            weights = input.Take(3).ToArray();
            var target = input[3];
            var counter = CollectGifts(target);            
            Console.WriteLine(counter);
        }

        public static int CollectGifts(int remaining)
        {
            if(remaining == 0)
            {
                return 1;
            }
            if(remaining < 0)
            {
                return 0;
            }
            if(memo.ContainsKey(remaining))
            {
                return 0;
            }

            var total = 0;
            foreach(var w in weights)
            {
                total += CollectGifts(remaining - w);
            }

            memo[remaining] = total;

            return total;
        }
    }
}