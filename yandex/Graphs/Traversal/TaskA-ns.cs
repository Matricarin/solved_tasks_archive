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
            var loses = new int[playersAmount];

            for(var l = 0; l < adjList.Length; l++)
            {
                adjList[l] = new List<int>();
            }

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
                loses[l - 1]++;
            }

            var q = new Queue<int>();

            for(int l = 0; l < loses.Length; l++)
            {
                if(loses[l] == 0)
                {
                    q.Enqueue(l);
                }
            }

            int processed = 0;

            while(q.Count > 0)
            {
                if(q.Count > 1)
                {
                    writer.WriteLine(No);
                    return;
                }

                var c = q.Dequeue();
                processed++;

                foreach(var p in adjList[c])
                {
                    loses[p]--;
                    if(loses[p] == 0)
                    {
                        q.Enqueue(p);
                    }
                }
            }

            if(processed == playersAmount)
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