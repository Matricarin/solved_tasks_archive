using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Graph
{
    public static class TaskA
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var input = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );
            var n = input[0];
            var m = input[1];

            int[][] routes = new int[m][];

            for(int i = 0; i < m; i++)
            {
                var arr =  Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                routes[i] = new int[arr[0]];

                for(int j = 0; j < arr[0]; j++)
                {
                    routes[i][j] = arr[j + 1];
                }
            }

            var first = new int[n][];
            InitMatrix(first, n);
            var second = new int[n][];
            InitMatrix(second, n);

            for(int x = 0; x < routes.Length; x++)
            {
                for(int y = 0; y < routes[x].Length - 1; y++)
                {
                    var y1 = routes[x][y] - 1;
                    var y2 = routes[x][y + 1] - 1;
                    first[y1][y2] = 1;
                    first[y2][y1] = 1;

                    for(int z = y + 1; z < routes[x].Length; z++)
                    {
                        var z1 = routes[x][y] - 1;
                        var z2 = routes[x][z] - 1;
                        second[z1][z2] = 1;
                        second[z2][z1] = 1;
                    }
                }
            }

            PrintMatrix(first, writer);
            PrintMatrix(second, writer);            
        }

        private static void InitMatrix(int[][] matrix, int n)
        {
            for(int f = 0; f < n; f++)
            {
                matrix[f] = new int[n];
            }
        }

        private static void PrintMatrix(int[][] matrix, StreamWriter writer)
        {
            for(int k = 0; k < matrix.Length; k++)
            {
                var row = string.Join(" ", matrix[k]);
                writer.WriteLine(row);
            }
        }
    }
}