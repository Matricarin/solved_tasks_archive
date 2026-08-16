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

            var m = Multiplied(x);
            var a = Added(x);
            var d = Differed(x);

            var root = new Node(x);
            root.M = m;
            root.A = a;
            root.D = d;

            var counter = 0;
            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var levelSize = q.Count;  

                Node found = null;

                for(int i = 0; i < levelSize; i++)
                {
                    var current = q.Dequeue();

                    if (current.M == null && current.A == null && current.D == null)
                    {
                        current.M = Multiplied(current.Value);
                        current.D = Differed(current.Value);
                        current.A = Added(current.Value);
                    }

                    foreach (var mNode in current.M)
                    {
                        q.Enqueue(mNode);
                    }
                    foreach (var aNode in current.A)
                    {
                        q.Enqueue(aNode);
                    }
                    foreach (var dNode in current.D)
                    {
                        q.Enqueue(dNode);
                    }

                    if(current.Value == y)
                    {
                        found = current;
                        break;
                    }
                }

                if(found != null)
                {
                    break;
                }

               counter++;
            }

            writer.WriteLine(counter);
        }

        private static Node[] Multiplied(int val)
        {
            var m = new Node[10];

            for (int i = 0; i < 10; i++)
            {
                m[i] = new Node(val * i);
            }

            return m;
        }

        private static Node[] Added(int val)
        {
            var a = new Node[10];

            for (int i = 0; i < 10; i++)
            {
                a[i] = new Node(val + i);
            }

            return a;
        }

        private static Node[] Differed(int val)
        {
            var d = new Node[10];

            for (int i = 0; i < 10; i++)
            {
                d[i] = new Node(val - i);
            }

            return d;
        }

    }

    public class Node
    {
        public int Value;
        public Node[] M;
        public Node[] A;
        public Node[] D;

        public Node(int val)
        {
            Value = val;
        }
    }
}


