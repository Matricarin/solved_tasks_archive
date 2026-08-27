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

            var adjList = new List<int>[10];

            for(int i = 0; i < 10; i++)
            {
                adjList[i] = new List<int>();

                var a = x + i;
                var m = x * i;
                var d = x - i;

                adjList[i].Add(a);
                adjList[i].Add(d);
                adjList[i].Add(m);
            }

            var depth = 1;
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

                    if(!notFound)
                    {
                        break;
                    }
                    
                    adjList[k] = new List<int>();

                    while(q.Count > 0)
                    {
                        if(!notFound)
                        {
                            break;
                        }

                        var c = q.Dequeue();

                        for(int i = 0; i < 10; i++)
                        {
                            var na = c + i;
                            var nd = c - i;
                            var nm = c * i; 

                            if(na == y || nd == y || nm == y)
                            {
                                notFound = false;
                                break;
                            }                      

                            adjList[k].Add(na);
                            adjList[k].Add(nd);
                            adjList[k].Add(nm);
                        }                        
                    }
                }
            }

            writer.WriteLine(depth);
        }

    }
   
}


