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
            var list = ReadLinkedList(n);

            var max = int.MinValue;

            foreach(var i in list)
            {
                if(max <= i)
                {
                    max = i;
                }
            }

            var f = list.First;
            var s = list.First;

            while(f != null)
            {
                if(f.Value == max)
                {
                    s = f;
                }

                f = f.Next;
            }

            list.Remove(s);

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