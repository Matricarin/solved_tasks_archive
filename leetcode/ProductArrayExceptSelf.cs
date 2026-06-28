using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leetcode
{
    public class ProductArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums) 
        {
            var by = new int[nums.Length];
            Array.Fill(by, 1);

            var against = new int[nums.Length];
            Array.Fill(against, 1);

            for(int i = 1; i < nums.Length; i++)
            {
                by[i] = nums[i - 1] * by[i - 1];
            }
            for(int i = nums.Length - 2; i >= 0; i--)
            {
                against[i] = against[i + 1] * nums[i + 1];
            }
            var arr = new int[nums.Length];

            for(int i = 0; i < nums.Length; i++)
            {
                arr[i] = by[i] * against[i];
            }

            return arr;
        }
    }
}