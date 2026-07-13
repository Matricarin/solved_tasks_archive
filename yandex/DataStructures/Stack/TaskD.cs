using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace yandex.DataStructures.Stack
{
    public struct StackItem
    {
        public int Value;
        public int Min;
        public StackItem(int value, int  min)
        {
            Value = value;
            Min = min;
        }
    }
    public class MinStack
    {
        private Stack<StackItem> _stack;
        public int Min => Count == 0 ? int.MaxValue : _stack.Peek().Min;
        public int Count => _stack.Count;
        public MinStack()
        {
            _stack = new Stack<StackItem>();
        }

        public void Push(int value)
        {
            var currentMin = Count == 0 ? value : Math.Min(value, _stack.Peek().Min);
            _stack.Push(new StackItem(value, currentMin));
        }

        public int Pop()
        {
            return _stack.Pop().Value;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var k = int.Parse(reader.ReadLine());

            var array = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            var stackIn = new MinStack();
            var stackOut = new MinStack();
            long result = 0;
            for(int i = 0; i < n; i++)
            {
                stackIn.Push(array[i]);

                if(i >= k)
                {
                    if(stackOut.Count == 0)
                    {
                        while(stackIn.Count > 0)
                        {
                            stackOut.Push(stackIn.Pop());
                        }
                    }

                    stackOut.Pop();
                }

                if(i >= k - 1)
                {
                    var min = Math.Min(stackIn.Min, stackOut.Min);
                    result += min;
                }
            }
            writer.WriteLine(result);
        }
    }
}
