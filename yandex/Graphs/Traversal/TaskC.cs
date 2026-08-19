using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Traversal
{
    public sealed class TaskC
    {
        public static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("input.txt");
            using StreamWriter writer = new StreamWriter("output.txt");

            var input = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            var n = input[0];

            var m = input[1];

            var maze = new char[n][];

            for (int i = 0; i < n; i++)
            {
                maze[i] = Array.ConvertAll
                (
                    reader.ReadLine().Split(),
                    char.Parse
                );
            }

            Dictionary<Tuple<int, int>, Tuple<int, int>[]> adjDict = new Dictionary<Tuple<int, int>, Tuple<int, int>[]>();

            Tuple<int, int> start = null;
            Tuple<int, int> finish = null;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    var current = new Tuple<int, int>(row, col);
                    var steps = new Tuple<int, int>[]
                    {
                        new Tuple<int,int>(row - 1, col),
                        new Tuple<int, int>(row + 1, col),
                        new Tuple<int, int>(row, col - 1),
                        new Tuple<int, int>(row, col + 1)
                    };

                    var avaliable = new List<Tuple<int, int>>();

                    foreach (var step in steps)
                    {
                        if (step.Item1 >= 0 && step.Item1 < n
                            && step.Item2 >= 0 && step.Item2 < m)
                        {
                            switch(maze[step.Item1][step.Item2])
                            {
                                case 'S':
                                    start = step;
                                    avaliable.Add(step);
                                    break;
                                case 'F':
                                    finish = step;
                                    avaliable.Add(step);
                                    break;
                                case '.':
                                    avaliable.Add(step);
                                default:
                                    continue;
                            }
                        }
                    }
                    adjDict.Add(current, avaliable.ToArray());
                }
            }

            var q = new Queue<Tuple<int,int>>();
            q.Enqueue(start);
            List<char> path = new List<char>();
            
        }
    }
}