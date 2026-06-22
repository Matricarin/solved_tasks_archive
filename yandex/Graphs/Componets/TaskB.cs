using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Graphs.Componets
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = ReadIntArray();

            var adjList = Enumerable.Range(1, input[0])
                .ToDictionary(k => k, v => new HashSet<int>());

            for(int k = 0; k < input[1]; k++)
            {
                var road = ReadIntArray();
                adjList[road[0]].Add(road[1]);
                adjList[road[1]].Add(road[0]);
            }

            var used = new bool[input[0]];
            var components = new List<List<int>>();
            var biggestCitiesAmount = 1;

            foreach(var vertice in adjList)
            {
                if(used[vertice.Key - 1])
                {
                    continue;
                }

                var component = new List<int>();
                
                DFS(vertice.Key, adjList, used, ref component);

                components.Add(component);
            }

            biggestCitiesAmount = components.Max(c => c.Count);
            
            Console.WriteLine(components.Count);
            Console.WriteLine(biggestCitiesAmount);
        }

        private static void DFS(int vertice, Dictionary<int, HashSet<int>> adjList, bool[] used, ref List<int> component)
        {
            if(!used[vertice - 1])
            {
                used[vertice - 1] = true;
                component.Add(vertice);
                var vertices = adjList[vertice];
                foreach(var v in vertices)
                {
                    DFS(v, adjList, used, ref component);
                }
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}