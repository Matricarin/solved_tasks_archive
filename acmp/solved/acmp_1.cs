using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;

namespace Acmp
{
    public class Program
    {
        public static void Main()
        {            
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            var reader = new StreamReader(Console.OpenStandardInput());
            var writer = new StreamWriter(Console.OpenStandardOutput());

            var input = reader.ReadLine();
            var array = input.Split(' ');

            var sum = array.Sum(item => int.Parse(item));
            writer.WriteLine(sum);

            reader.Close();
            writer.Close();
        }
    }
}