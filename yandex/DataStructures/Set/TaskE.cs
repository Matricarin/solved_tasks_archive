using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Set
{
    public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;
        public static void Main(string[] args)
        {
             using(_reader = new StreamReader("input.txt"))
            {
                using(_writer = new StreamWriter("output.txt"))
                {
                    var n = int.Parse(_reader.ReadLine());

                    var array = _reader.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    var hash = new HashSet<int>();

                    for (int left = 0; left < n; left++)
                    {
                        int cur = 0;

                        for (int right = left; right < n; right++)
                        {
                            cur |= array[right];
                            hash.Add(cur);
                        }
                    }

                    _writer.WriteLine(hash.Count);
                }
            }
        }
    }
}