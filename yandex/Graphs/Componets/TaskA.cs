using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace yandex.Graphs.Componets
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;
           
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var adjList = Enumerable.Range(1, input[0]).ToDictionary(k => k, v => new HasSet<int>());

            for(int i = 0; i < input[1]; i++)
            {
                var vertices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                adjList[vertices[0]].Add(vertices[1]);
                adjList[vertices[1]].Add(vertices[0]);
            }

            //  найти компоненты связности?
        }
    }
}