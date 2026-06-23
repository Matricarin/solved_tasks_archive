using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leetcode
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            var sorted = intervals.OrderBy(i => i[0]).ToArray();
            if(sorted.Length < 2)
            {
                return sorted;
            }

            var result = new List<int[]>();

            var firstBorder = sorted[0][0];
            var lastBorder = sorted[0][1];

            for(int i = 1; i < sorted.Length; i++)
            {
                var current = sorted[i];

                if(lastBorder >= sorted[i][1])
                {
                    continue;
                }

                if(sorted[i][0] <= lastBorder && lastBorder < sorted[i][1])
                {
                    lastBorder = sorted[i][1];
                }
                else
                {
                    result.Add(new int[]{firstBorder, lastBorder});
                    firstBorder = sorted[i][0];
                    lastBorder = sorted[i][1];
                }    
            }
            result.Add(new int[]{firstBorder, lastBorder});
            return result.ToArray();
        }
    }
}