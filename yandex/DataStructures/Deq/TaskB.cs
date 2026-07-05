using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace yandex.DataStructures.Deq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var n = int.Parse(reader.ReadLine());
            var deq = new LinkedList<int>();
            for(int i = 0; i < n; i++)
            {
                var request = Array.ConvertAll
                (
                    reader.ReadLine().Split(" "),
                    int.Parse
                );

                if(ProcessRequest
                (
                    (RequestType)request[0],
                    request.Length == 2 ? request[1] : -1,
                    deq
                ))
                {
                    writer.WriteLine($"{deq.First.Value} {deq.Last.Value}");
                }
                else
                {
                    writer.WriteLine(-1);
                }
            }

        }

        private static bool ProcessRequest(RequestType requestType, int value, LinkedList<int> deq)
        {
            switch (requestType)
            {
                case RequestType.First:
                    {
                        deq.AddFirst(value);
                        return true;
                    }
                case RequestType.Second:
                    {
                        deq.AddLast(value);
                        return true;
                    }
                case RequestType.Third:
                    {
                        if (deq.Count == 0)
                        {
                            return false;
                        }
                        else
                        {
                            deq.RemoveFirst();
                            if (deq.Count == 0)
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                case RequestType.Fourth:
                    {
                        if (deq.Count == 0)
                        {
                            return false;
                        }
                        else
                        {
                            deq.RemoveLast();
                            if (deq.Count == 0)
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum RequestType
    {
        First = 1,
        Second,
        Third,
        Fourth
    }
}