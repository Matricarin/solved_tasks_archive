using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;

namespace yandex.Basic.MaximumProduct
{
    public class TaskD
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var arr = Array.ConvertAll
            (
                reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            Array.Sort(arr);

            long f = arr[0] * arr[1] * arr[2] * arr[3];
            long s = arr[^1] * arr[^2] * arr[^3] * arr[^4];
            long t = arr[0] * arr[1] * arr[^1] * arr[^2];
            long x = arr[0] * arr[1] * arr[2] * arr[^1];
            long y = arr[^1] * arr[^2] * arr[^3] * arr[0];

            var max = Math.Max(f, Math.Max(s, Math.Max(t, Math.Max(x, y))));
        
            writer.WriteLine(max);
        }
    }
}
