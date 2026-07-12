using System;
using System.Collections.Generic;
using System.Linq;
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

            var k = int.Parse(reader.ReadLine());

            var array = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            if (n == k)
            {
                writer.WriteLine(array.Min());
            }
            else
            {
                var stack = new Stack<int>();

                stack.Push(-1);

                var min = int.MaxValue;

                for (int i = 0; i < n; i++)
                {
                    if (i - stack.Peek() < k)
                    {
                        if (min > array[i])
                        {
                            min = array[i];
                            stack.Pop();
                            stack.Push(i);
                        }
                    }
                    else
                    {
                        min = array[i];
                        stack.Push(i);
                    }
                }

                writer.WriteLine(stack.Sum(i => array[i]));
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;

namespace yandex.DataStructures.TwoStacks
{
    // Структура для хранения элемента и текущего минимума в стеке
    public struct StackElement
    {
        public int Value;
        public int Min;
        
        public StackElement(int value, int min)
        {
            Value = value;
            Min = min;
        }
    }

    public class MinStack
    {
        private readonly Stack<StackElement> _stack = new Stack<StackElement>();

        public int Count => _stack.Count;

        public void Push(int val)
        {
            // Минимум — это меньшее между новым значением и предыдущим минимумом в стеке
            int currentMin = _stack.Count == 0 ? val : Math.Min(val, _stack.Peek().Min);
            _stack.Push(new StackElement(val, currentMin));
        }

        public int Pop()
        {
            return _stack.Pop().Value;
        }

        public int GetMin()
        {
            // Если стек пуст, возвращаем бесконечность, чтобы она не влияла на Math.Min
            return _stack.Count == 0 ? int.MaxValue : _stack.Peek().Min;
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
            
            var array = Array.ConvertAll(
                reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            long sumOfMins = 0;
            
            var stackIn = new MinStack();
            var stackOut = new MinStack();

            for (int i = 0; i < n; i++)
            {
                // 1. Добавляем новый элемент в stackIn
                stackIn.Push(array[i]);

                // 2. Если окно превысило размер k, нужно удалить самый старый элемент
                if (i >= k)
                {
                    // Если stackOut пуст, переливаем в него весь stackIn
                    if (stackOut.Count == 0)
                    {
                        while (stackIn.Count > 0)
                        {
                            stackOut.Push(stackIn.Pop());
                        }
                    }
                    // Теперь на вершине stackOut гарантированно лежит самый старый элемент окна
                    stackOut.Pop();
                }

                // 3. Если окно полностью сформировано, считаем минимум
                if (i >= k - 1)
                {
                    int currentMin = Math.Min(stackIn.GetMin(), stackOut.GetMin());
                    sumOfMins += currentMin;
                }
            }

            writer.WriteLine(sumOfMins);
        }
    }
}