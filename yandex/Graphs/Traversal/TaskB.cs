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
                int.Parse
            );

            var x = arr[0];
            var y = arr[1];

            var max = Math.Max(x, y) + 50;

            var visited = new bool[max + 1];
            var dist = new int[max + 1];

            var q = new Queue<int>();
            q.Enqueue(x);

            visited[x] = true;
            dist[x] = 0;

            var isZeroAdded = false;

            while(q.Count > 0)
            {
                var c = q.Dequeue();

                if(c == y)
                {
                    break;
                }

                for(int i = 0; i < 10; i++)
                {
                    TryStep(c + i);
                    TryStep(c - i);
                    TryStep(c * i);
                }

                if(!isZeroAdded)
                {
                    isZeroAdded = true;
                    TryStep(0);
                }

                void TryStep(int next)
                {
                    if(next >= 0 && next <= max && !visited[next])
                    {
                        visited[next] = true;
                        dist[next] = dist[c] + 1;
                        q.Enqueue(next);
                    }
                }
            }

            writer.WriteLine(dist[y]);
        }
    }

}

