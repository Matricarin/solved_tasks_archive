using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace olympic_practicum.lesson2
{
    public static class Task1
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader(Console.OpenStandardInput());
            using var writer = new StreamWriter(Console.OpenStandardOutput());

            var arr = Array.ConvertAll(reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries), 
                int.Parse);

            var vertices = arr[0];
            var edges = arr[1];

            var s = int.Parse(reader.ReadLine());

            var adjList = new List<int>[vertices + 1];
            for(int v = 0; v <= vertices; v++)
            {
                adjList[v] = new List<int>();
            }
            for (int e = 0; e < edges; e++)
            {
                var currentEdge = Array.ConvertAll(reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);

                adjList[currentEdge[0]].Add(currentEdge[1]);
                adjList[currentEdge[1]].Add(currentEdge[0]);
            }

            var visited = new bool[vertices + 1];
            var distances = new int[vertices + 1];

            visited[s] = true;
            distances[s] = 0;

            var q = new Queue<int>();
            q.Enqueue(s);

            while(q.Count > 0)
            {
                var c = q.Dequeue();

                for(int i = 0; i < adjList[c].Count; i++)
                {
                    if(!visited[adjList[c][i]])
                    {
                        visited[adjList[c][i]] = true;
                        distances[adjList[c][i]] = distances[c] + 1;
                        q.Enqueue(adjList[c][i]);
                    }                    
                }
            }

            for(int k = 0; k < visited.Length; k++)
            {
                if(!visited[k])
                {
                    distances[k] = -1;
                }
            }
            
            writer.WriteLine(string.Join(" ", distances.Skip(1)));
        }
    }
}