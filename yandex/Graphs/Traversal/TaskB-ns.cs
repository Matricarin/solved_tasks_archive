using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Formats.Asn1;

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

            var (m, a, d) = Evaluate(x);

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

                for (int i = 0; i < levelSize; i++)
                {
                    var current = q.Dequeue();

                    if (current.M == null && current.A == null && current.D == null)
                    {
                        var (mNodes, aNodes, dNodes) = Evaluate(current.Value);
                        current.M = mNodes;
                        current.D = dNodes;
                        current.A = aNodes;
                    }

                    for (int k = 0; k < 10; k++)
                    {
                        q.Enqueue(current.M[k]);
                        q.Enqueue(current.A[k]);
                        q.Enqueue(current.D[k]);
                    }

                    if (current.Value == y)
                    {
                        found = current;
                        break;
                    }
                }

                if (found != null)
                {
                    break;
                }

                counter++;
            }

            writer.WriteLine(counter);
        }

        private static (Node[], Node[], Node[]) Evaluate(int val)
        {
            var m = new Node[10];
            var a = new Node[10];
            var d = new Node[10];
            for (int i = 0; i < 10; i++)
            {
                m[i] = new Node(val * i);
                a[i] = new Node(val + i);
                d[i] = new Node(val - i);
            }

            return (m, a, d);
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


