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
                    
                    var array = Array.ConvertAll
                    (
                        _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                        int.Parse
                    );

                    var result = new HashSet<int>();

                    var current = new HashSet<int>();

                    foreach(var i in array)
                    {
                        var next = new HashSet<int>();
                        next.Add(i);

                        foreach(var c in current)
                        {
                            next.Add(c | i);
                        }

                        foreach(var v in next)
                        {
                            result.Add(v);
                        }

                        current = next;
                    }
                    
                    _writer.WriteLine(result.Count);
                }
            }
        }
    }
}