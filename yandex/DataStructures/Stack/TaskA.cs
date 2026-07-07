using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace yandex.DataStructures.Stack
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var stack = new Stack<int>();

            for(int i = 0; i < n; i++)
            {
                var input = Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                if(input.Length == 2)
                {
                    stack.Push(input[1]);
                }
                else
                {
                    stack.Pop();
                }
                
                if(stack.TryPeek(out var value))
                {
                    writer.WriteLine(value);
                }
                else
                {
                    writer.WriteLine(-1);
                }
            }
        }
    }
}