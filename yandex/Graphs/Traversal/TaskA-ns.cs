using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.Graphs.Traversal
{
    public class TaskA
    {
        private const string Yes = "YES";
        private const string No = "NO";
        public static void Main(string[]  args)
        {
            using var reader = new StreamReader("input.txt");
            using var writer = new StreamWriter("output.txt");

            var input = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            var playersAmount = input[0];

            var gamesAmount = input[1];

            if(gamesAmount < playersAmount - 1)
            {
                writer.WriteLine(No);
                return;
            }

            var adjList = new List<int>[playersAmount];

            for(var l = 0; l < adjList.Length; l++)
            {
                adjList[l] = new List<int>();
            }

            var won = new HashSet<int>();

            for(int i = 0; i < gamesAmount; i++)
            {
                var stat = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                var widx = stat[2] - 1;
                var w = stat[widx];
                var l = stat[1 - widx];

                adjList[l - 1].Add(w - 1);
            }

            for(int j = 0; j < adjList.Length; j++)
            {
                var stack = new Stack<int>(adjList[j]);
                while(stack.Count > 0)
                {
                    var p = stack.Pop();
                    won.Add(p);
                }
            }

            if(won.Count == playersAmount - 1)
            {
                writer.WriteLine(Yes);
            }
            else
            {
                writer.WriteLine(No);
            }
            
        }
    }
}