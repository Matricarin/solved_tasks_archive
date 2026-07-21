using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Sequences.Fibonacci
{
    public static class TaskA_1
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacciNumber(n));
        }

        public static long GetFibonacciNumber(int n)
        {
            Console.WriteLine($"Начали обработку числа {n}...");

            if(n == 1)
            {
                return 0;
            }

            if(n == 2)
            {
                return 1;
            }

            var answer = GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2);

            Console.WriteLine($"Закончили обработку числа {n}...Результат {answer}");

            return answer;
        }
    }
}