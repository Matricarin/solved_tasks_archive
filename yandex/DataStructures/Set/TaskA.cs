using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.DataStructures.Set
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var set = new HashSet<int>();

            var q = int.Parse(Console.ReadLine());

            for(int i = 0; i < q; i++)
            {
                var request = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if(request[0] == 1)
                {
                    set.Add(request[1]);
                }
                else
                {
                    if(set.Contains(request[1])) 
                    { 
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(0);
                    } 
                }
            }
        }
    }
}