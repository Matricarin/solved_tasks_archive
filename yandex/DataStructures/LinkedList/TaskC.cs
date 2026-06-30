using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.LinkedList
{
     public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;

        public static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var fa = _reader.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var array = ReadFastIntArray(fa[0]); 

            var firstIndexes = new Dictionary<int, int>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                if (!firstIndexes.ContainsKey(array[i]))
                    firstIndexes[array[i]] = i + 1; 
            }    

            for (int i = 0; i < fa[1]; i++)
            {
                var request = int.Parse(_reader.ReadLine());
                if (firstIndexes.TryGetValue(request, out var index))
                    _writer.WriteLine(index);
                else
                    _writer.WriteLine(-1);
            }

            _reader.Close();
            _writer.Close();
        } 

        private static int[] ReadFastIntArray(int size)
        {
            var array = new int[size];
            var current = 0;
            var index = 0;
            var sym = 0;
            var hasNumber = false;
            while(index < size)
            {
                sym = _reader.Read();
                if(sym >= '0' && sym <= '9')
                {
                    var d = sym - '0';
                    current = current * 10 + d;
                    hasNumber = true;
                    continue;
                }

                if(hasNumber)
                {                 
                    array[index] = current;
                    current = 0;
                    hasNumber = false;
                    index++;   
                }                
            }
            return array;
        }  
    }
}