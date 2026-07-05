using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Deq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());

            var q = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                var request = Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                switch (request[0])
                {
                        case 1:
                        {
                            q.Enqueue(request[1]);
                            writer.WriteLine(q.Peek());
                            break;
                        }
                        case 2:
                        {
                            if(!q.TryDequeue(out _))
                            {
                                writer.WriteLine(-1);
                            }
                            else
                            {
                                if(q.TryPeek(out var peek))
                                {
                                    writer.WriteLine(peek);
                                } 
                                else
                                {
                                    writer.WriteLine(-1);
                                }  
                            }
                            break;
                        }
                        default:
                            throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}