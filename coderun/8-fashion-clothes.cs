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

            var n = ReadInt();
            var nArray = ReadFastIntArray(n);
            var m = ReadInt();
            var mArray = ReadFastIntArray(m);

            var i = 0;
            var j = 0;
            var min = int.MaxValue;
            var nValue = 0;
            var mValue = 0;
            while(i < n && j < m)
            {                
                if(min > Math.Abs(nArray[i] - mArray[j]))
                {
                    min = Math.Abs(nArray[i] - mArray[j]);
                    nValue = nArray[i];
                    mValue = mArray[j];
                    if(min == 0)
                    {
                        break;
                    }
                }
                if(nArray[i] > mArray[j])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }
            
            _writer.WriteLine($"{nValue} {mValue}");
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