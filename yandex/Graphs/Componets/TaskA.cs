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
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                                System.Globalization.CultureInfo.InvariantCulture;
           
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var adjList = Enumerable.Range(1, input[0]).ToDictionary(k => k, v => new HashSet<int>());

            for(int i = 0; i < input[1]; i++)
            {
                var vertices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                adjList[vertices[0]].Add(vertices[1]);
                adjList[vertices[1]].Add(vertices[0]);
            }

            var used = new bool[input[0]];

            var components = new List<List<int>>();

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

            if(components.Count > 1)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

        private static void DFS(int vertice, Dictionary<int, HashSet<int>> adjList, bool[] used, ref List<int> component)
        {
            used[vertice - 1]= true;

            var vertices = adjList[vertice];

            foreach(var v in vertices)
            {
                if(!used[v -1])
                {
                    component.Add(v);
                    DFS(v, adjList, used, ref component);
                }
            }
        }
    }
}