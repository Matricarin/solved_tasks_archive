using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Sequences.Fibonacci
{
    public class TaskA
    {
        public static void Main(string[] args)
        {
            var n = 30;
            var list = new List<long>();
            list.Add(1);

            long prev = 0;
            long curr = 1;
            for(int i = 3; i <= n; i++)
            {
                long next = prev + curr;
                prev = curr;
                curr = next;
                list.Add(curr % 4);
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}