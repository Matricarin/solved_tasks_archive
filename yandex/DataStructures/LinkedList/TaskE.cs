using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.DataStructures.LinkedList
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var list = new LinkedList<int>();
            list.AddLast(array[0]);
            for(int i = 1; i < array.Length - 1; i++)
            {
                if(array[i] < array[i - 1] && array[i] < array[i + 1])
                {
                    continue;
                }

                list.AddLast(array[i]);
            }
            list.AddLast(array[^1]);
            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list.ToArray()));
        }
    }
}