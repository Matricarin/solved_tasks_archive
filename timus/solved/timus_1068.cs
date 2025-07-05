/*
    Всё, что от вас требуется — найти сумму всех целых чисел, лежащих между 1 и N включительно.
Исходные данные
    В единственной строке расположено число N, по модулю не превосходящее 10000.
Результат
    Выведите целое число — ответ задачи.
*/

//  Варианты решения
//  1. используя сумму арифметической прогрессии между первым членом и указанным членом
//      S = ((a1 + an) / 2) * n - работает (при отрицательной разности прогрессии обратить внимание на количество членов прогрессии)
//  2. использовать цикл - работает

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
            var num = int.Parse(Console.ReadLine());
            if (num < 1)
            {
                var sum = 0;
                for (int i = 1; i >= num; i--)
                {
                    sum += i;
                }
                Console.WriteLine(sum);
            }
            else
            {
                var sum = 0;
                for (int i = 1; i <= num; i++)
                {
                    sum += i;
                }
                Console.WriteLine(sum);
            }
        }
    }
}