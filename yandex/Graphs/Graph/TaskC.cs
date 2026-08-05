using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Graph
{
    public static class TaskC
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var amountOfGroups = int.Parse(reader.ReadLine());
            var groups = new int[amountOfGroups][];
            var max = int.MinValue;

            for(int a = 0; a < amountOfGroups; a++)
            {
                var arr = Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                groups[a] = new int[arr[0]];

                for(int i = 1; i < arr.Length; i++)
                {
                    groups[a][i - 1] = arr[i];
                    if(arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
            }

            var matrix = new int[max][];

            for(int j = 0; j < max; j++)
            {
                matrix[j] = new int[max];
            }

            for(int g = 0; g < amountOfGroups; g++)
            {
                if(groups[g].Length == 1)
                {
                    continue;
                }
                else
                {
                    for(int m = 0; m < groups[g].Length; m++)
                    {
                        for(int n = 0; n < groups[g].Length; n++)
                        {
                            if(m == n)
                            {
                                continue;
                            }
                            else
                            {
                                matrix[groups[g][m]-1][groups[g][n]-1] = 1;
                                matrix[groups[g][n]-1][groups[g][m]-1] = 1;
                            }
                        }
                    }
                }
            }
            
            writer.WriteLine(max);
            foreach(var row in matrix)
            {
                writer.WriteLine(string.Join(" ", row));
            }
        }
    }
}