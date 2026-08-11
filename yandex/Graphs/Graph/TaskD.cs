using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Graph
{
    public class TaskD
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var d = int.Parse(reader.ReadLine());
            var departments = new int[d][];
            var max = int.MinValue;
            for(int i = 0; i < d; i++)
            {
                var arr = Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                departments[i] = new int[arr[0]];

                for(int k = 1; k < arr.Length; k++)
                {
                    departments[i][k - 1] = arr[k];
                    if(max < arr[k])
                    {
                        max = arr[k];
                    }
                }
            }

            var adjMatrix = new int[max][];

            for(int u = 0; u < max; u++)
            {
                adjMatrix[u] = new int[max];
            }

            for(int j = 0; j < departments.Length; j++)
            {
                for(int e = 1; e < departments[j].Length; e++)
                {
                    adjMatrix[departments[j][0] - 1][departments[j][e]- 1] = 1;
                    adjMatrix[departments[j][e]- 1][departments[j][0]- 1] = -1;
                }
            }

            foreach(var row in adjMatrix)
            {
                writer.WriteLine(string.Join(" ", row));
            }
        }
    }
}