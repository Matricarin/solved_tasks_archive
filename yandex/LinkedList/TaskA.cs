using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.LinkedList
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;

            var list = new LinkedList<int>();
            var result = new List<int>();

            var inputs = int.Parse(Console.ReadLine());

            for(int i = 0; i < inputs; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch(arr[0])
                {
                    case 1:
                    {
                        AddNumber(arr[1], arr[2], list);
                        break;
                    }
                    case 2:
                    {
                        result.Add(GetNumber(arr[2]));
                        break;
                    }
                    case 3:
                    {
                        RemoveNumber(arr[2]);
                        break;   
                    }
                    default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(arr));
                    }
                }
            }

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static void AddNumber(int afterPosition, int number, LinkedList<int> list)
        {
            if(afterPosition == 0)
            {
                list.AddFirst(number);
            }
            else
            {
                var i = 0;
                var currentNode = list.First;
                while(currentNode is not null && i < afterPosition)
                {
                    currentNode = currentNode.Next;
                    i++;
                }
                list.AddAfter(currentNode, number);
            }
        }

        public static void RemoveNumber(int position, LinkedList<int> list)
        {
            var i = 0;
            var currentNode = list.First;
            while(currentNode is not null && i < position)
            {
                currentNode = currentNode.Next;
                i++;
            }

            list.Remove(currentNode);
        }

        public static int GetNumber(int position, LinkedList<int> list)
        {
            var i = 0;
            var currentNode = list.First;
            while(currentNode is not null && i < position)
            {
                currentNode = currentNode.Next;
                i++;
            }
            return currentNode.Value;
        }
    }
}