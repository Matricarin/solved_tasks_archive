using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leetcode
{
    public class TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];

            var dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if(dict.ContainsKey(nums[i]))
                {
                    result[0] = i;
                    result[1] = dict[nums[i]];

                    break;
                }

                var diff = target - nums[i];
                
                dict.TryAdd(diff, i);
            }

            return result;
        }
    }
}