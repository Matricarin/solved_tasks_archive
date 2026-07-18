using System;
using System.IO;

namespace Yandex.DataStructures.Deq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            string nStr = reader.ReadLine();
            if (string.IsNullOrEmpty(nStr)) return;

            int n = int.Parse(nStr);
            var array = Array.ConvertAll(
                reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            if (n == 2)
            {
                writer.WriteLine($"{array[0]} {array[1]}");
                return;
            }

            int[] left = new int[n];
            int[] right = new int[n];

            for (int i = 0; i < n; i++)
            {
                left[i] = (i - 1 + n) % n;
                right[i] = (i + 1) % n;
            }

            int current = 0;
            int remainingCount = n;

            while (remainingCount > 2)
            {
                int lIdx = left[current];
                int rIdx = right[current];

                int cVal = array[current];
                int lVal = array[lIdx];
                int rVal = array[rIdx];

                int minIdx = current;
                if (lVal < array[minIdx]) minIdx = lIdx;
                if (rVal < array[minIdx]) minIdx = rIdx;

                int maxIdx = current;
                if (lVal > array[maxIdx]) maxIdx = lIdx;
                if (rVal > array[maxIdx]) maxIdx = rIdx;

                left[right[minIdx]] = left[minIdx];
                right[left[minIdx]] = right[minIdx];
                remainingCount--;

                if (remainingCount == 2)
                {
                    break;
                }

                current = maxIdx;
            }

            writer.WriteLine($"{array[current]} {array[right[current]]}");
        }
    }
}