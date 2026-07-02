using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace yandex.DataStructures.Set
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
                    var n = int.Parse(_reader.ReadLine());
                    var sets = new HashSet<int>[n];
                    for(int i = 0; i < n; i++)
                    {
                        sets[i] = ReadSet();
                    }

                    var core = new HashSet<int>(sets[0]);
                    for(int i = 1; i < n; i++)
                    {
                        core.IntersectWith(sets[i]);
                    }
                    if(core.Count == 0)
                    {
                        _writer.WriteLine("NO");
                    }
                    else
                    {
                        var dict = new Dictionary<int, int>();
                        for(int k = 0; k < n; k++)
                        {
                            sets[k].ExceptWith(core);
                            foreach(var s in sets[k])
                            {
                                if(!dict.TryAdd(s, 1))
                                {
                                    dict[s]++;
                                }
                            }
                        }

                        if(dict.Any(kv => kv.Value > 1))
                        {
                            _writer.WriteLine("NO");
                        }
                        else
                        {
                            _writer.WriteLine("YES");
                            _writer.WriteLine(core.Count);
                            _writer.WriteLine(string.Join
                                (
                                    " ", 
                                    sets.Select(s => s.Count)
                                ));  
                        }
                    } 
                }
            }
        }   
        private static HashSet<int> ReadSet()
        {
            var hashSet = new HashSet<int>();

            var collection = _reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Skip(1);

            foreach(var item in collection)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }
    }
}