using System.IO;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        using var reader = new StreamReader("input.txt");
        using var writer = new StreamWriter("output.txt");

        var n = int.Parse(reader.ReadLine());

        var deq = new LinkedList<char>
        (
            reader.ReadLine().ToCharArray()
        );

        var sb = new StringBuilder();

        while(deq.Count != 0)
        {
            var f = deq.First.Value;
            var l = deq.Last.Value;
            if(f <= l)
            {
                sb.Append(f);
                deq.RemoveFirst();
            }
            else
            {
                sb.Append(l);
                deq.RemoveLast();
            }
        }

        writer.WriteLine(sb.ToString());
    }
}