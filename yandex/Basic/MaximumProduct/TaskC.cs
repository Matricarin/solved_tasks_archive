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
                int.Parse
            );

            var nums = new int[3];
            Array.Fill(nums,  0);
            long max = long.MinValue;
            var mi = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                if(arr[i] > mi)
                {
                    mi = arr[i];
                    nums[0] = i;
                }
            }

            var mj = int.MinValue;

            for(int j = 0; j < n; j++)
            {
                if(j == nums[0])
                {
                    continue;
                }
                else
                {
                    if(arr[j] > mj)
                    {
                        mj = arr[j];
                        nums[1] = j;
                    }
                }
            }

            var mk = int.MinValue;

            for(int k = 0; k < n; k++)
            {
                if(k == nums[0] || k == nums[1])
                {
                    continue;
                }
                else
                {
                    if(arr[k] > mk)
                    {
                        mk = arr[k];
                        nums[2] = k;
                    }
                }
            }

            max = arr[nums[0]] * arr[nums[1]] * arr[nums[2]];
            writer.WriteLine(max);
        }
    }
}