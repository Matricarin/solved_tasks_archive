using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace YandexContest
{
    class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;
        static void Main(string[] args)
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var a = ReadInt();
            var b = ReadInt();
            var c = ReadInt();
            var d = ReadInt();
            var e = ReadInt();

            if(a % d == 0 && b % e == 0)
            {
                _writer.WriteLine("YES");
            }



           
            _reader.Close();
            _writer.Close();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader?.ReadLine()!);
        }

        private static int[] ReadIntArray()
        {
            return _reader?.ReadLine()!.Split(" ")
                                    .Select(int.Parse)
                                    .ToArray()!;
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