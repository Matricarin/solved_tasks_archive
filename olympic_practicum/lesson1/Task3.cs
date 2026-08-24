using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olympic_practicum.lesson1
{
    public class Task3
    {
        public static void Main(string[] args)
        {
            (var x1, var y1) = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
            (var x2, var y2) = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
            (var x3, var y3) = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
        }
    }
}