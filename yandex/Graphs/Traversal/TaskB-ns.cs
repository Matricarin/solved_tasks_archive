using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Traversal
{
    public class TaskB
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var arr = Array.ConvertAll(
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            var x = arr[0];
            var y = arr[1];

            writer.WriteLine(Solve(x, y));
        }

        public static int Solve(long x, long y)
        {
            if (x == y)
            {
                return 0;
            }

            var visited = new HashSet<long>() { x };
            var q = new Queue<long>();

            q.Enqueue(x);

            var depth = 0;

            while (q.Count > 0)
            {
                depth++;

                var levelSize = q.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var c = q.Dequeue();

                    for (int j = 0; j < 10; j++)
                    {
                        var na = c + j;

                        if (y == na)
                        {
                            return depth;
                        }

                        if (visited.Add(na))
                        {
                            q.Enqueue(na);
                        }

                        var nd = c - j;

                        if (y == nd)
                        {
                            return depth;
                        }

                        if (visited.Add(nd))
                        {
                            q.Enqueue(nd);
                        }

                        var nm = c * j;

                        if (y == nm)
                        {
                            return depth;
                        }

                        if (visited.Add(nm))
                        {
                            q.Enqueue(nm);
                        }
                    }
                }
            }

            return -1;
        }
    }

}

