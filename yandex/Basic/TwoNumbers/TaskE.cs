using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yandex.Basic.TwoNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();

            var ai = a.Length - 1;
            var bj = b.Length - 1;
            var carry = 0;

            var sb = new StringBuilder();
            while(ai >= 0 || bj >= 0 || carry > 0)
            {
                var bitA = ai >= 0 ? a[ai] - '0' : 0;
                var bitB = bj >= 0 ? b[bj] - '0' : 0;
                var sum = bitA + bitB + carry;
                carry = sum / 2;
                var nextBit = sum % 2;
                sb.Append(nextBit);
                ai--;
                bj--;
            }

            Console.WriteLine(string.Join("",sb.ToString().Reverse()));
        }
    }
}