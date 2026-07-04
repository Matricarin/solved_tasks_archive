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
                    var dict = new Dictionary<string, int>();

                    var n = int.Parse(_reader.ReadLine());
                    var counter = 0;
                    for(int i = 0; i < n; i++)
                    {
                        var line = _reader.ReadLine();

                        foreach(var kv in dict)
                        {
                            if(kv.Key.Equals(line))
                            {
                                continue;
                            }

                            var diff = 0;

                            for(int j = 0; j < line.Length; j++)
                            {
                                if(line[j] - kv.Key[j] != 0)
                                {
                                    diff++;
                                }
                            }

                            if(diff > 1)
                            {
                                continue;
                            }
                            counter++;
                        }

                        dict.TryAdd(line, 0);
                    }

                    _writer.WriteLine(counter);
                }
            }
        }
    }
}