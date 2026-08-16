using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Traversal
{
    public class TaskA
    {
        public static void Main(string[]  args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var input = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            var playersAmount = input[0];

            var gamesAmount = input[1];

            var scores = new int[playersAmount];

            var played = new int[playersAmount];

            var matrix = new int[playersAmount][];

            for(int i = 0; i < playersAmount; i++)
            {
                matrix[i] = new int[playersAmount];
            }

            for(int g = 0; g < gamesAmount; g++)
            {
                var game = Array.ConvertAll(
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                matrix[game[0] - 1][game[1] - 1] = game[game[2] - 1];
                matrix[game[1] - 1][game[0] - 1] = game[game[2] - 1];
            }

            for(int x = 0; x < playersAmount; x++)
            {
                for(int y = 0; y < playersAmount; y++)
                {
                    if(matrix[x][y] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        played[x]++;
                        played[y]++;
                        scores[matrix[x][y] - 1]++;
                    }
                }
            }

            if(played.Any(p => p == 0))
            {
                writer.WriteLine("NO");
            }
            else
            {
                writer.WriteLine("YES");
            }
        }
    }
}