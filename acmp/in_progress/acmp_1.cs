using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acmp
{
    public class Program
    {
        public static void Main()
        {            
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());

            var input = _reader.ReadLine();
            var array = input.Split(' ');

            var sum = array.Sum(item => int.Parse(item));
            _writer.WriteLine(sum);

            _reader.Close();
            _writer.Close();
        }
    }
}