using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            while(deq.Count > 2)
            {
                var current = deq.First;
                var left = deq.Last;
                var right = current.Next;

                if(current.Value > left.Value)
                {
                    if(current.Value > right.Value)
                    {
                        deq.Remove(right);
                        deq.Remove(left);
                    }
                    else
                    {
                        deq.Remove(current);
                        deq.Remove(left);
                    }
                }
                else
                {
                    if(left.Value > right.Value)
                    {
                        deq.Remove(current);
                        deq.Remove(right);
                    }
                    else
                    {
                        deq.Remove(current);
                        deq.Remove(left);
                    }
                }
            }

            writer.WriteLine(string.Join(" ", deq));
        }
    }
}