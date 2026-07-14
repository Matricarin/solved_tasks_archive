using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 

namespace yandex.DataStructures.Stack
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var result = new int[n];
            var stack = new Stack<int>();

            var sym = 0;
            var hasNumber = false;
            var number = 0;
            var i = 0;
            while(i < n)
            {
                sym = reader.Read();
                if(sym >= '0' && sym <= '9')
                {
                    var d = sym - '0';
                    number = number * 10 + d;
                    hasNumber = true;
                    continue;
                }

                if(hasNumber)
                {
                    hasNumber = false;


                    i++;
                    number = 0;
                }
            }

            writer.WriteLine(string.Join(" ", result));
        }
    }
}