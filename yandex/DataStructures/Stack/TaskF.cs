using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());
            var array = Array.ConvertAll
            (
                reader.ReadLine().Split(" "),
                int.Parse
            );
            var max = 0;
            for(int i = 0; i < n; i++)
            {   
                var stack = new Stack<int>();
                var length = 0;
                for(int j = i; j < n; j++)
                {
                    if(array[j] % 2 == 1)
                    {
                        stack.Push(array[j]);
                    }
                    else if(array[j] % 2 == 0 && stack.Count != 0)
                    {
                        stack.Pop();
                        length += 2;
                        if(stack.Count == 0)
                        {
                            if(max < length)
                            {
                                max = length;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }                
            }

            writer.WriteLine(max);
        }
    }
}


