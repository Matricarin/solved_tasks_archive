using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DivideAndConquer.BinarySearch
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
            var array = ReadArray(n);
            var target = int.Parse(_reader.ReadLine());

            var right = array.Length - 1;
            var left = 0;
            var answer = -1;
            while(left <= right)
            {
                var mid = (left + right) / 2;

                if(target == array[mid])
                {
                    answer = mid;
                    break;
                }

                if(target > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            _writer.WriteLine(answer);

            _reader.Close();
            _writer.Close();
        }

        private static int[] ReadArray(int size)
        {
            var array = new int[size];
            var i = 0;
            var hasNumber = false;
            var number = 0;
            var sym = 0;
            while(i < size)
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
                    array[i] = number;
                    number = 0;
                    i++;
                    hasNumber = false;
                }
            }

            return array;
        }
    }
}