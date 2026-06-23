using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace yandex.DataStructures.Dictionary
{
    public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;

        public static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var n = int.Parse(_reader.ReadLine());

            var dict = new Dictionary<int, int>();

            var i = 0;
            var sym = 0;
            var number = 0;
            var hasNumber = false;
            while(i < n)
            {
                sym = _reader.Read();    

                if(sym >= '0' && sym <= '9')
                {
                    var d = sym - '0';
                    number = number * 10 + d;
                    hasNumber = true;
                    continue;                    
                }

                if(hasNumber)
                {
                    if(!dict.TryAdd(number, 1))
                    {
                        dict[number]++;
                    }
                    number = 0;
                    i++;
                } 
            }

            var max = dict.Max(kv => kv.Value);

            var keys = dict.Where(kv => kv.Value == max)
                .OrderBy(k => k.Key)
                .ToArray();

            _writer.WriteLine(keys.Length > 1 ? keys.Min().Value : keys[0].Value);

            _reader.Close();
            _writer.Close();
        }
    }
}