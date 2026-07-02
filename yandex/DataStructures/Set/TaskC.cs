using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Set
{
    public static class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;
        public static void Main(string[] args)
        {
            using(_reader = new StreamReader("input.txt"))
            {
                using(_writer = new StreamWriter("output.txt"))
                {
                    var n = int.Parse(_reader.ReadLine());
                    var set = ReadSet();

                    for(int i = 1; i < n; i++)
                    {
                        var current = ReadSet();
                        set.IntersectWith(current);
                    }

                    _writer.WriteLine(set.Count);
                }
            };
        }

        private static HashSet<int> ReadSet()
        {
            var set = new HashSet<int>();

            var collection = _reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Skip(1);

            foreach(var item in collection)
            {
                set.Add(item);
            }

            return set;
        }
    }
}