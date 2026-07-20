using System;
using System.Collections.Generic;
using System.IO;

namespace yandex.Basic.MaximumProduct
{
    public class TaskE
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var line1 = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line1)) return;
            int n = int.Parse(line1.Trim());

            var tokens = reader.ReadToEnd().Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            long[] a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(tokens[i]);
            }

            List<int> posIndices = new List<int>();
            List<int> negIndices = new List<int>();
            List<int> zeroIndices = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (a[i] > 0) posIndices.Add(i + 1);
                else if (a[i] < 0) negIndices.Add(i + 1);
                else zeroIndices.Add(i + 1);
            }

            List<int> result = new List<int>();

            if (posIndices.Count > 0 || negIndices.Count >= 2)
            {

                result.AddRange(posIndices);

    
                int maxNegIdx = -1;
                if (negIndices.Count % 2 != 0)
                {
                    maxNegIdx = negIndices[0];
                    for (int i = 1; i < negIndices.Count; i++)
                    {
                        int idx = negIndices[i];
                        if (a[idx - 1] > a[maxNegIdx - 1]) 
                        {
                            maxNegIdx = idx;
                        }
                    }
                }

                foreach (var idx in negIndices)
                {
                    if (idx != maxNegIdx)
                    {
                        result.Add(idx);
                    }
                }
            }
            else if (zeroIndices.Count > 0)
            {
                result.Add(zeroIndices[0]);
            }
            else
            {
                result.Add(negIndices[0]);
            }

            writer.WriteLine(string.Join(" ", result));
        }
    }
}