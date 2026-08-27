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

            var visited = new HashSet<int>();

            var adjList = new List<int>[10];

            for(int i = 0; i < 10; i++)
            {
                adjList[i] = new List<int>();
                var a = x + i;
                var m = x + i;
                var d = x - i;
                if(visited.Add(a))
                {
                    adjList[i].Add(a);
                }
                if(visited.Add(d))
                {
                    adjList[i].Add(d);
                }                
                if(visited.Add(m))
                {
                    adjList[i].Add(m);
                }
            }

            var depth = 0;
            var notFound = true;
            while(notFound)
            {
                depth++;
                var q = new Queue<int>();
                for(int k = 0; k < 10; k++)
                {
                    if(!notFound)
                    {
                        break;
                    }
                    var list = adjList[k];
                    foreach(var item in list)
                    {
                        q.Enqueue(item);
                    }
                    
                    adjList[k] = new List<int>();

                    while(q.Count > 0)
                    {
                        var c = q.Dequeue();

                        var na = c + k;
                        var nd = c - k;
                        var nm = c * k;

                        if(na == y || nd == y || nm == y)
                        {
                            notFound = false;
                        }

                        if(visited.Add(na))
                        {
                            adjList[k].Add(na);
                        }
                        if(visited.Add(nd))
                        {
                            adjList[k].Add(nd);
                        }                
                        if(visited.Add(nm))
                        {
                            adjList[k].Add(nm);
                        }
                    }
                }
            }

            writer.WriteLine(depth);
        }

    }
   
}


