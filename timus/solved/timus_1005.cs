/*
    У вас есть несколько камней известного веса w1, …, wn. Напишите программу, которая распределит камни в две кучи так, что разность весов этих двух куч будет минимальной.
Исходные данные
    Ввод содержит количество камней n (1 ≤ n ≤ 20) и веса камней w1, …, wn (1 ≤ wi ≤ 100 000) — целые, разделённые пробельными символами.
Результат
    Ваша программа должна вывести одно число — минимальную разность весов двух куч.
*/


//  1. Использовал жадный алгоритм. Не учитывает все возможные сочетания камней
//  2. Динамическое программирование / полный перебор

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
            var amount = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            var totalSum = nums .Sum();
            var minDiff = int.MaxValue;

            for(int mask = 0; mask < (1 << amount); mask++)
            {
                var sum1 = 0;
                for(int i = 0; i < amount;i++)
                {
                    if((mask & (1 << i)) != 0)
                    {
                        sum1 += nums[i];
                    }
                }

                var sum2 = totalSum - sum1;
                var diff = Math.Abs(sum1 - sum2);
                minDiff= Math.Min(minDiff, diff);
            }

            Console.WriteLine(minDiff);
            
        }   
    }
}