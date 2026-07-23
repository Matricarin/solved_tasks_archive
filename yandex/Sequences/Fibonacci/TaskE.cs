using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Sequences.Fibonacci
{
    public static class TaskE
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

            var m = arr[0] == 0 ? 0 : arr[0] - 1;
            var n = arr[1];

            var period = GetPisano();
            
            var sumPeriod = GetSumModFibonacci(period);

            var xn = n / period;
            var yn = n % period;

            var sumN = sumPeriod * xn + GetSumModFibonacci(yn);
            
            var xm = m / period;
            var ym = m % period;

            var sumM = sumPeriod * xm + GetSumModFibonacci(ym);

            var result = sumN - sumM;

            writer.WriteLine(result % 10);
        }

        public static long GetPisano()
        {
            long old = 0;
            long next = 1;
            long period = 0;
            while(true)
            {
                long oldNew = next;
                next = (old + next) % 10;
                old = oldNew;
                period++;
                if(old == 0 & next == 1)
                {
                    return period;
                }
            }
        }

        public static long GetSumModFibonacci(long n)
        {
            long result = 1;
            
            if(n == 0)
            {
                return 0;
            }

            if(n == 1)
            {
                return 1;
            }
            long old = 0;
            long next = 1;
            for(long i = 2; i <= n; i++)
            {
                var oldNew = next;
                next = (old + next) % 10;
                old = oldNew;
                result += next;
            }

            return result;
        }      
    }
}