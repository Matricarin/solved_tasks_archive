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

            var list = new ListSolver();
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
                        list.AddNumber(arr[1], arr[2]);
                        break;
                    }
                    case 2:
                    {
                        result.Add(list.GetNumber(arr[1]));
                        break;
                    }
                    case 3:
                    {
                        list.RemoveNumber(arr[1]);
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

    }

    public class ListSolver
    {
        private LinkedList<int> _list;

        public ListSolver()
        {
            _list = new LinkedList<int>();
        }

        
        public void AddNumber(int afterPosition, int number) // O(n)
        {
            if(afterPosition == 0)
            {
                _list.AddFirst(number);
            }
            else
            {
                var i = 1;
                var currentNode = _list.First;
                while(i < afterPosition)
                {
                    currentNode = currentNode.Next;
                    i++;
                }
                _list.AddAfter(currentNode, number);
            }
        }

        public  void RemoveNumber(int position) // O(n)
        {
            var i = 1;
            var currentNode = _list.First;
            while(i < position)
            {
                currentNode = currentNode.Next;
                i++;
            }

            _list.Remove(currentNode);
        }

        public int GetNumber(int position) // O(n)
        {
            var i = 1;
            var currentNode = _list.First;
            while(i < position)
            {
                currentNode = currentNode.Next;
                i++;
            }
            return currentNode.Value;
        }
    }
}

// Общая сложность получается будет такой:
// Каждый метод имеет O(n)
// Количество запросов q
// Если будет q вызовов одного метода, то получается O(q * n(n - 1)/2) = O(q * n^2)