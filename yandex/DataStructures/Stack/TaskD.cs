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
            var result = 0;
            for(int i = 0; i <= n - k; i++)
            {
                var min = int.MaxValue;
                for(int v = i; v < i + k; v++)
                {
                    if(min > array[v])
                    {
                        min = array[v];
                    }
                }

                result += min;
            }

            writer.WriteLine(result);
        }
    }
}