// Дан массив a a, состоящий из n n чисел, и q q запросов. Каждый запрос состоит из одного целого числа x i xi​.
// Найдите и выведите индекс p i pi​, который является первым, самым левым, вхождением числа x i xi​ в массив a a. Если x i xi​ не встречается среди элементов массива, то p i = − 1 pi​=−1.
// Формат ввода
// Первая строка содержит два разделенных пробелом числа n n и q q -- количество чисел в массиве и количество запросов, соответственно.
// Вторая строка содержит n n чисел a i ai​, где a i ai​ -- число на i i-й позиции в массиве a a. Числа разделены пробелами.
// Далее идут q q строк, каждая строка содержит ровно одно число x i xi​ -- очередной запрос.
// Ограничения: 1 ≤ n , q ≤ 1 0 5 1≤n,q≤105; 1 ≤ a i ≤ 1 0 5 1≤ai​≤105 для всех 1 ≤ i ≤ n 1≤i≤n; 1 ≤ x i ≤ 1 0 5 1≤xi​≤105 для всех 1 ≤ i ≤ q 1≤i≤q.
// Формат вывода
// Выведите q q чисел p i pi​.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.LinkedList
{
     public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;

        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var fa = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var array = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var size = fa[0];
            var requests = fa[1];

            for (int i = 0; i < requests; i++)
            {
                var request = int.Parse(_reader.ReadLine());
                var index = Array.IndexOf(array, request);
                _writer.WriteLine(index == -1 ? -1 : index + 1);
            }

            _reader.Close();
            _writer.Close();
        }   
    }
}