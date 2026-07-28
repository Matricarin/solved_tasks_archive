using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace yandex.Graphs.Graph
{
    public static class TaskB
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var sizes = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );
            var n = sizes[0];
            var m = sizes[1];
            var room = new char[n][];

            for (int i = 0; i < n; i++)
            {
                var row = reader.ReadLine();
                room[i] = row.ToCharArray();
            }

            var start = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            var actionsLength = int.Parse(reader.ReadLine());
            var actions = reader.ReadLine();
            var cells = new HashSet<(int, int)>
            {
                (start[0] - 1, start[1] - 1)
            };
            var current = (start[0] - 1, start[1] - 1);
            var target = (current.Item1 - 1, current.Item2);
            foreach (var action in actions)
            {
                var dir = (target.Item1 - current.Item1, target.Item2 - current.Item2);
                switch (action)
                {
                    case 'R':
                        {
                            if (dir == (-1, 0))
                            {
                                target = (current.Item1, current.Item2 + 1);
                            }
                            else if (dir == (1, 0))
                            {
                                target = (current.Item1, current.Item2 - 1);
                            }
                            else if (dir == (0, 1))
                            {
                                target = (current.Item1 + 1, current.Item2);
                            }
                            else
                            {
                                target = (current.Item1 - 1, current.Item2);
                            }
                            break;
                        }
                    case 'L':
                        {
                            if (dir == (-1, 0))
                            {
                                target = (current.Item1, current.Item2 - 1);
                            }
                            else if (dir == (1, 0))
                            {
                                target = (current.Item1, current.Item2 + 1);
                            }
                            else if (dir == (0, 1))
                            {
                                target = (current.Item1 - 1, current.Item2);
                            }
                            else
                            {
                                target = (current.Item1 + 1, current.Item2);
                            }
                            break;
                        }
                    case 'M':
                        {
                            if (target.Item1 < n && target.Item2 < m)
                            {
                                var sym = room[target.Item1][target.Item2];

                                if (sym == '.')
                                {
                                    cells.Add(target);
                                    current = target;
                                    target = (current.Item1 + dir.Item1, current.Item2 + dir.Item2);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(action));
                }
            }

            writer.WriteLine(cells.Count);
        }

    }
}