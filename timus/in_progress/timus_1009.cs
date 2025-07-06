/*
    Рассмотрим N-значные числа в системе счисления с основанием K. Будем считать число правильным, если его K-ичная запись не содержит двух подряд идущих нулей. Например:

    1010230 — правильное 7-значное число;
    1000198 не является правильным числом;
    0001235 — не 7-значное, а 4-значное число. 

    Даны числа N и K, вычислите количество правильных K-ичных чисел, состоящих из N цифр.
    Ограничения: 2 ≤ K ≤ 10; N ≥ 2; N + K ≤ 18.
Исходные данные
    Числа N и K в десятичной записи, разделенные переводом строки.
Результат
        Искомое количество в десятичной записи.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timus
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var amountOfNumbers = k - 1;
            for(int i = 0; i < n - 1; i++)
            {
                amountOfNumbers *= k;
            }

            var amountofWrongNumbers = 0;
            for(int mask = 1 << n; mask < (1 << (n + 1)); mask++)
            {
                var zeros = 0;
                for(int i = 0; i < n; i++)
                {
                    if((mask & (1 << i)) == 0)
                    {
                        zeros++;
                    }
                }
                if(zeros >= 2)
                {
                    amountofWrongNumbers++;
                }
            }

            Console.WriteLine(amountOfNumbers - amountofWrongNumbers);
        }
    }
}