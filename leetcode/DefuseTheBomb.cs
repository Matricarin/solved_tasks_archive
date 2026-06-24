using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leetcode
{
    public class DefuseTheBomb
    {
        public int[] Decrypt(int[] code, int k)
        {
            if (k == 0)
            {
                var arr1 = new int[code.Length];
                Array.Fill(arr1, 0);
                return arr1;
            }

            if (k < 0)
            {
                var arr2 = new int[code.Length];

                for (int i = 0; i < code.Length; i++)
                {
                    var sum = 0;
                    var t = i;
                    for (int j = Math.Abs(k); j > 0; j--)
                    {
                        t--;
                        if (t == -1)
                        {
                            t = code.Length - 1;
                            sum += code[t];
                            continue;
                        }

                        sum += code[t];
                    }
                    arr2[i] = sum;
                }
                return arr2;
            }

            var arr = new int[code.Length];

            for (int u = 0; u < code.Length; u++)
            {
                var sum = 0;
                var t = u;
                for (int j = 0; j < k; j++)
                {
                    t++;
                    if (t == code.Length)
                    {
                        t = 0;
                        sum += code[t];
                        continue;
                    }

                    sum += code[t];
                }

                arr[u] = sum;
            }
            return arr;
        }
    }
}