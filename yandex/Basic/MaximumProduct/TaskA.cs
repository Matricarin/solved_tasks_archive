using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Basic.MaximumProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = long.Parse(reader.ReadLine());

            var array = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            long max = long.MinValue;
            int maxIndex = int.MinValue;
            long previousMax = long.MinValue;

            for(int i = 0; i < n; i++)
            {
                if(max < array[i])
                {
                    max = array[i];
                    maxIndex = i;
                }
            }

            for(int j = 0; j < n; j++)
            {
                if(maxIndex == j)
                {
                    continue;
                }

                if(previousMax < array[j])
                {
                    previousMax = array[j];
                }
            }

            long maxProduct = max * previousMax;

            writer.WriteLine(maxProduct);
        }
    }
}