using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Dictionary
{
    public static class Program
    {
        private static TextReader? _reader;
        private static TextWriter? _writer;
        public static void Main(string[] args)
        {
            using(_reader = new StreamReader("input.txt"))
            {
                using(_writer = new StreamWriter("output.txt"))
                {
                    var dict = new Dictionary<char, HashSet<int>>();

                    var n = int.Parse(_reader.ReadLine());
                    var counter = 0;
                    for(int i = 0; i < n; i++)
                    {
                        var line = _reader.ReadLine();
                        var diffCounter = 0;
                        for(int j = 0; j < line.Length; j++)
                        {
                            if(dict.TryGetValue(line[j], out var set))
                            {       
                                if(!set.Contains(j))
                                {
                                    diffCounter++;
                                }
                            }
                            else
                            {
                                diffCounter++;
                            }

                            if(!dict.TryAdd(line[j], [j]))
                            {
                                dict[line[j]].Add(j);
                            }  
                        }

                        if(diffCounter == 1)
                        {
                            counter++;
                        }
                    }

                    _writer.WriteLine(counter);
                }
            }
        }
    }
}