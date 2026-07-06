using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace yandex.DataStructures.Deq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var data = Array.ConvertAll
            (
                reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );
            var amountOfServers = data[1];
            var servers = new LinkedList<int>();
            var currentTime = 0;
            var firstHandledTime = int.MaxValue;
            for(int i = 0; i < data[0]; i++)
            {
                var package =Array.ConvertAll
                (
                    reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse
                );

                var inputTime = package[0];
                var handleTime = package[1];

                

            }
        }
    }
}