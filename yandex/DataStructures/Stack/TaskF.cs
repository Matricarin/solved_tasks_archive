using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Stack
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
                reader.ReadLine().Split(" "),
                int.Parse
            );
            var max = 0;
            var stack = new Stack<int>();
            stack.Push(-1);

            for(int i = 0; i < n; i++)
            {   
                if(array[i] % 2 != 0)
                {
                    stack.Push(i);
                }
                else
                {
                    stack.TryPop(out _);

                    if(stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        max = Math.Max(max, i - stack.Peek());
                    }
                }
            }

            writer.WriteLine(max);
        }
    }
}


