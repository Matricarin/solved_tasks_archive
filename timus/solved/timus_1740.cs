using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace timus.in_progress;

public class timus_1740
{
    public static void Main()
    {
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        var array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        var l = array[0];
        var k = array[1];
        var h = array[2];

        double max = double.MinValue;
        double min = double.MaxValue;
        
        var index = h;
        var path = k;
        
        while(path < l)
        {
            path += k;
            index += h;
        }
        if(l % k == 0)
        {
            min = max = index;
        }
        else
        {
            min = index - h;
            max = index;            
        }

        Console.WriteLine($"{min} {max}");
    }
}