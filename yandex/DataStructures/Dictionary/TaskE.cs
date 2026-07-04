using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Dictionary
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            if (!int.TryParse(reader.ReadLine(), out int n)) return;

            var patternCount = new Dictionary<string, int>();
            var wordCount = new Dictionary<string, int>();

            long totalInterestingPairs = 0;

            for (int i = 0; i < n; i++)
            {
                string word = reader.ReadLine();
                if (string.IsNullOrEmpty(word)) 
                {
                    continue;
                }

                int len = word.Length;
                long pairsForThisWord = 0;

                char[] wordChars = word.ToCharArray();

                for (int j = 0; j < len; j++)
                {
                    char originalChar = wordChars[j];
                    wordChars[j] = '*'; 
                    
                    string pattern = new string(wordChars);

                    if (patternCount.TryGetValue(pattern, out int count))
                    {
                        pairsForThisWord += count;
                        patternCount[pattern] = count + 1;
                    }
                    else
                    {
                        patternCount[pattern] = 1;
                    }

                    wordChars[j] = originalChar; 
                }

                if (wordCount.TryGetValue(word, out int exactMatches))
                {
                    pairsForThisWord -= (long)exactMatches * len;
                    wordCount[word] = exactMatches + 1;
                }
                else
                {
                    wordCount[word] = 1;
                }

                totalInterestingPairs += pairsForThisWord;
            }

            writer.WriteLine(totalInterestingPairs);
        }
    }
}