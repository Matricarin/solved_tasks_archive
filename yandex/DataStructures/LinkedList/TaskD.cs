using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace yandex.DataStructures.LinkedList
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = ReadLinkedList(n);
            
            
            var current = list.First;
            var min = current.Value;
            while(current != null)
            {              
                if(min > current.Value)
                {
                    min = current.Value;                   
                }
                current.Value = min;
                current = current.Next;
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static LinkedList<int> ReadLinkedList(int size)
        {
            var list = new LinkedList<int>();
            var i = 0;
            var hasHumber = false;
            var sym = 0;
            var number = 0;
            while (i < size)
            {
                sym = Console.Read();
                if (sym >= '0' && sym <= '9')
                {
                    var d = sym - '0';
                    number = number * 10 + d;
                    hasHumber = true;
                    continue;
                }

                if (hasHumber)
                {
                    list.AddLast(number);
                    hasHumber = false;
                    number = 0;
                    i++;
                }
            }
            return list;
        }
    }
}