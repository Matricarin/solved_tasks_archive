using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    
                }
            }
        }   
        private static HashSet<int> ReadSet()
        {
            var hashSet = new HashSet<int>();

            var collection = _reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Skip(1);

            foreach(var item in collection)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }
    }
}