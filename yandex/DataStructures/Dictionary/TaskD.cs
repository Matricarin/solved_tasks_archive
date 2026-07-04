using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Dictionary
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

                    var array = Array.ConvertAll
                    (
                        _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                        int.Parse
                    );

                    var dict = new Dictionary<int, int>();

                    for(int i = 0; i < n; i++)
                    {
                        if(!dict.TryAdd(array[i], 1))
                        {
                            dict[array[i]]++;
                        }
                    }

                    var triple = dict.OrderByDescending(kv => kv.Value)
                        .ThenBy(kv => kv.Key)
                        .Select(kv => kv.Key)
                        .Take(3);
                    
                    _writer.WriteLine(string.Join(" ", triple.OrderBy(i => i)));
                }
            }
        }
    }
}