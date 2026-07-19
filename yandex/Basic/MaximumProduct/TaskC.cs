using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var arr = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            if (n == 3)
            {
                writer.WriteLine(arr[0] * arr[1] * arr[2]);
                return;
            }

            Array.Sort(arr);
            long max = long.MinValue;
            long r2 = arr[^1] * arr[^2];
            long l2 = arr[0] * arr[1];

            if (r2 > l2)
            {
                if (arr[0] < 0)
                {
                    if (l2 * arr[^1] > r2 * arr[^3])
                    {
                        max = l2 * arr[^1];
                    }
                    else
                    {
                        max = r2 * arr[^3];
                    }
                }
                else
                {
                    max = r2 * arr[^3];
                }
            }
            else
            {
                if (arr[^1] > 0)
                {
                    max = l2 * arr[^1];
                }
                else
                {
                    max = r2 * arr[^3];
                }
            }

            writer.WriteLine(max);
        }
    }
}