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

            var arr = new int[]{a, b, c};

            var buckets = new int[4];

            foreach(var item in arr)
            {
                if(item % d == 0 && item % e == 0)
                {
                    buckets[2]++;
                }
                
                if(item % d == 0 && item % e != 0)
                {
                    buckets[0]++;
                }
                
                if(item % e == 0 && item % d != 0)
                {
                    buckets[1]++;
                }

                if(item % d != 0 && item % e != 0)
                {
                    buckets[3]++;
                }
            }

            var answer = string.Empty;

            if((buckets[0] != 0 && buckets[1] != 0) 
                || buckets[2] >= 2 
                || buckets[2] != 0 && (buckets[0] != 0 || buckets[1] != 0))
            {
                answer = "YES";
            }
            else
            {
                answer = "NO";
            }

            _writer.WriteLine(answer);
           
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