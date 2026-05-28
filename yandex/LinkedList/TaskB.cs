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
            var n = int.Parse(Console.ReadLine());

            var array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var solver = new PriceSolver(array);

            Console.WriteLine(solver.Solve());
        }
    }

    public class PriceSolver
    {
        private int[] _array;

        public PriceSolver(int[] array)
        {
            _array = array;
        }

        public string Solve()
        {
            var linkedList = new LinkedList<int>();

            for(var i = 0; i < _array.Length; i++)
            {
                if(linkedList.Count == 0)
                {
                    linkedList.AddFirst(i);
                    continue;
                }

                var currentNode = linkedList.First;
                while(currentNode is not null)
                {
                    if(_array[currentNode.Value] > _array[i])
                    {
                        linkedList.AddBefore(currentNode, i);
                        break;
                    }
                    currentNode = currentNode.Next ?? null;
                }
                linkedList.AddLast(i);
            }

            var max = linkedList.Last.Value;

            var afterMax = int.MinValue;
            var beforeMax = int.MinValue;

            var cn = linkedList.First;
            while(cn is not null)
            {
                cn = cn.Next ?? null;
                if(cn.Value < max && beforeMax == int.MaxValue)
                {
                    beforeMax = cn.Value;
                }

                if(cn.Value > max && afterMax == int.MaxValue)
                {
                    afterMax = cn.Value;
                }
            }

            return string.Join(Environment.NewLine, [$"{beforeMax} {max}", $"{max} {afterMax}"]);
        }
    }
}
