using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace yandex.Sequences.Fibonacci
{
    public static class TaskF
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var stack = new Stack<int>();

            var old = 0;
            var next = 1;

            while(next <= n)
            {
                var oldNew = next;
                next = old + next;
                old = oldNew;
                if(next <= n)
                {
                     stack.Push(next);  
                }   
            }
            var sb = new StringBuilder();

            while(stack.Count > 0)
            {
                var num =  stack.Pop();

                if (num <= n)
                {
                    n -= num;
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
            }

            writer.WriteLine(sb.ToString());
        }
    }
}