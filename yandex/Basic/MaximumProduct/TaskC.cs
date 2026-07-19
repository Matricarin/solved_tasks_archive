using System;
using System.IO;

namespace yandex.Basic.MaximumProduct
{
    public class TaskC
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());
            var arr = Array.ConvertAll(
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            Array.Sort(arr);

            long option1 = arr[^1] * arr[^2] * arr[^3];
            
            long option2 = arr[0] * arr[1] * arr[^1];

            long maxProduct = Math.Max(option1, option2);

            writer.WriteLine(maxProduct);
        }
    }
}