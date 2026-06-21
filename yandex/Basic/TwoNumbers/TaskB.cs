using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.Basic.TwoNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()) + 1;
            var nx = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var m = int.Parse(Console.ReadLine()) + 1;
            var mx = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var max = n > m ? n : m;

            var noffset = max - n;
            var moffset = max - m;

            var result = new int[max];

            for(int i = max - 1; i >= 0; i--)
            {
                var nval = i - noffset < 0 ? 0 : nx[i - noffset];
                var mval = i - moffset < 0 ? 0 : mx[i - moffset];

                result[i] = nval + mval;
            }

            Console.WriteLine(max - 1);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}


// более элегантная запись от gemini
using System;
using System.Linq;

namespace yandex.Basic.TwoNumbers
{
    public static class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] nx = ReadIntArray();

            int m = int.Parse(Console.ReadLine());
            int[] mx = ReadIntArray();

            int maxLen = Math.Max(nx.Length, mx.Length);
            var result = new int[maxLen];

            int i = nx.Length - 1;
            int j = mx.Length - 1;
            int k = maxLen - 1;

            while (k >= 0)
            {
                int nVal = (i >= 0) ? nx[i--] : 0;
                int mVal = (j >= 0) ? mx[j--] : 0;

                result[k--] = nVal + mVal;
            }

            Console.WriteLine(maxLen - 1);
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] ReadIntArray() =>
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}