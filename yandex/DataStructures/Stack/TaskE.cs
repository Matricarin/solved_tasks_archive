using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Stack
{
    public class Program
    {
        private static Dictionary<char,char> _dict = new Dictionary<char, char>
        {
            {')','('},    
            {'}','{'},    
            {']','['},    
        };

        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var stack = new Stack<char>();

            int end;
            var isCorrect = true;
            while((end = reader.Read()) != -1)
            {
                var sym = (char)end;
                if(!_dict.TryGetValue(sym, out var bracket))
                {
                    stack.Push(sym);
                }
                else
                {
                    if(stack.Count != 0)
                    {
                        if(stack.Pop() != bracket)
                        {
                            isCorrect = false;
                        }
                    }
                    else
                    {
                        isCorrect = false;
                    }
                }
            }

            if(stack.Count == 0 && isCorrect)
            {
                writer.WriteLine("YES");
            }
            else
            {
                writer.WriteLine("NO");
            }
        }
    }
}