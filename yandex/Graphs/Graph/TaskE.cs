using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Graph
{
    public class TaskE
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());
            var adjMatrix = new int[n][];

            for(int i = 0; i < n; i++)
            {
                adjMatrix[i] = Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );
            }

            for(int x = 0; x < n; x++)
            {
                for(int y = 0; y < n; y++)
                {
                    for(int z = 0; z < n; z++)
                    {
                        adjMatrix[y][z] = adjMatrix[y][z] | (adjMatrix[y][x] & adjMatrix[x][z]);
                    }
                }   
            }

            for(int k = 0; k < n; k++)
            {
                writer.WriteLine(string.Join(" ", adjMatrix[k]));
            }
        }
    }
}