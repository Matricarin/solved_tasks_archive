using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace yandex.Sequences.Fibonacci
{
    public class TaskC
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var arr = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                long.Parse
            );

            if (arr[0] == 0)
            {
                writer.WriteLine(0);
                return;
            }

            if (arr[0] == 1)
            {
                writer.WriteLine(1);
                return;
            }

            var m = new long[2][];

            m[0] = [1, 1];
            m[1] = [1, 0];

            var row = RowMatrix(m, arr[0], arr[1]);

            writer.WriteLine(row[0][1]);

        }

        public static long[][] MultiplyMatrixWithMod(long[][] a, long[][] b, long m)
        {
            var result = new long[2][];
            result[0] = new long[] { (a[0][0] * b[0][0] + a[0][1] * b[1][0]) % m, (a[0][0] * b[0][1] + a[0][1] * b[1][1]) % m };
            result[1] = new long[] { (a[1][0] * b[0][0] + a[1][1] * b[1][0]) % m, (a[1][0] * b[0][1] + a[1][1] * b[1][1]) % m };
            return result;
        }

        public static long[][] RowMatrix(long[][] a, long power, long m)
        {
            var result = new long[2][];
            result[0] = [1, 0];
            result[1] = [0, 1];

            var source = a;

            while (power > 0)
            {
                if (power % 2 == 1)
                {
                    result = MultiplyMatrixWithMod(result, source, m);
                }

                source = MultiplyMatrixWithMod(source, source, m);
                power /= 2;
            }

            return result;
        }
    }
}