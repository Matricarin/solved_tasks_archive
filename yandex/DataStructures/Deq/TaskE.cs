using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Deq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var array = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            var deq = new LinkedList<int>(array);

            while(deq.Count > 3)
            {
                var current = deq.First;
                var left = deq.Last;
                var right = current.Next;

                if(current.Value < left.Value)
                {
                    if(current.Value < right.Value)
                    {
                        deq.Remove(current);
                    }
                    else
                    {
                        deq.Remove(right);
                    }
                }
                else
                {
                    if(left.Value < right.Value)
                    {
                        deq.Remove(left);
                    }
                    else
                    {
                        deq.Remove(right);
                    }
                }

                if(current.Value > left.Value)
                {
                    if(current.Value > right.Value)
                    {
                        deq.Remove(current);
                        deq.AddFirst(current);
                    }
                    else
                    {
                        deq.Remove(right);
                        deq.AddFirst(right);
                    }
                }
                else
                {
                    if(left.Value > right.Value)
                    {
                        deq.Remove(left);
                        deq.AddFirst(left);
                    }
                    else
                    {   
                        deq.Remove(right);
                        deq.AddFirst(right);
                    }
                }
            }

            var c = deq.First;
            var l = deq.Last;
            var r = c.Next;

            if(c.Value < l.Value)
            {
                if(c.Value < r.Value)
                {
                    deq.Remove(c);
                }
                else
                {
                    deq.Remove(r);
                }
            }
            else
            {
                if(l.Value < r.Value)
                {
                    deq.Remove(l);
                }
                else
                {
                    deq.Remove(r);
                }
            }

            writer.WriteLine(string.Join(" ", deq));
        }
    }
}