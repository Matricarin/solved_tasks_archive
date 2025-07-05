/*
    Определение 1. n!!…! = n(n−k)(n−2k)…(n mod k), если n не делится на k; n!!…! = n(n−k)(n−2k)…k, если n делится на k (знаков ! в обоих случаях k штук).
    Определение 2. X mod Y — остаток от деления X на Y.
    Например, 10 mod 3 = 1; 3! = 3·2·1; 10!!! = 10·7·4·1.
    Мы по заданным n и k смогли вычислить значение выражения из определения 1. А вам слабо?
Исходные данные
    В единственной строке сначала дано целое число n, 1 ≤ n ≤ 10, затем ровно один пробел, затем k восклицательных знаков, 1 ≤ k ≤ 20.
Результат
    Выведите одно число — n!!…!
*/

//  Поможет понятие обратного факториала
//  Первоначальное решение некорректно

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
            // Первоначальное решение
            // var input = Console.ReadLine().Split(' ');
            // var first = int.Parse(input[0]);
            // var k = input[1].Length;
            // var last = first % k != 0 ? first % k : k;
            // var fact = first;
            // var i = 1;
            // while (first - i * k > last)
            // {
            //     fact *= first - i * k;
            //     i++;
            // }
            // Console.WriteLine(fact);

            var input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = input[1].Length;

            int result = 1;
            for (int i = n; i > 0; i -= k)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
    }
}