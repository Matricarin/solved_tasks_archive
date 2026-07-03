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
                    var dict = new Dictionary<int, int>();

                    for(int i = 0; i < n; i++)
                    {
                        var request = Array.ConvertAll
                        (
                            _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                            int.Parse
                        );

                        if(request[0] == 1)
                        {
                            if(!dict.TryAdd(request[1], request[2]))
                            {
                                dict[request[1]] = request[2];
                            }
                        }
                        else
                        {
                            if(dict.TryGetValue(request[1], out var value))
                            {
                                _writer.WriteLine(value);
                            }
                            else
                            {
                                _writer.WriteLine(-1);
                            }
                        }
                    }
                }
            }
        }
    }
}