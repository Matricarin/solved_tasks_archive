using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Timus
{
    public class Program
    {
    public static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

        Stack<double> stack = new();
        string? input;

        while ((input = Console.ReadLine()) != null)
        {
            foreach (var token in input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(token, out var value))
                {
                    stack.Push(value);
                }
            }
        }

        while (stack.Count > 0)
        {
            Console.WriteLine(Math.Sqrt(stack.Pop()).ToString("F4"));
        }
    }
    }
}