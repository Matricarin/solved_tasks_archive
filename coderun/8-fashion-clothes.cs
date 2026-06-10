using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var nArray = ReadIntArray();
            var m = ReadInt();
            var mArray = ReadIntArray();

            var nf = nArray[0]; var nl = nArray[^1];
            var mf = mArray[0]; var ml = mArray[^1];
            var nValue = 0;
            var mValue = 0;
            var nmDiff = Math.Abs(nf - ml);
            var mnDiff = Math.Abs(nl - mf);

            if(nmDiff == mnDiff)
            {
                
            }
            



            _writer.WriteLine($"{nArray[sInd]} {mArray[pInd]}");
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
    }
}