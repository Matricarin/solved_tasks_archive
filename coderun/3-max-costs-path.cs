using System;
using System.Linq;

class Program
{
    private const string D = "D";
    private const string R = "R";
    static void Main()
    {
        var size = ReadIntArray();
        
        var sum = 0;
        var way = new string[size[0] + size[1] - 1];

        var field = new int[size[0]][];

        for(int i = 0; i < field.Length; i++)
        {
            field[i] = ReadIntArray();
        }

        (int, int) position = (0, 0);

        for(int k = 0; k < way.Length; k++)
        {            
            sum += field[position.Item1][position.Item2];

            if(position.Item1 == size[0])
            {
                way[k] = R;
                position.Item2++;
            }
            else if(position.Item2 == size[1])
            {                
                way[k] = D;
                position.Item1++;
            }
            else if(field[position.Item1 + 1][position.Item2] > field[position.Item1][position.Item2 + 1])
            {                
                way[k] = D;
                position.Item1++;
            }
            else
            {
                way[k] = R;
                position.Item2++;
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine(string.Join(" ", way));
    }

    static int[] ReadIntArray()
    {
        var s = Console.ReadLine();
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n));
    }
}
