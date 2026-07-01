using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.DataStructures.Set
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var resultSet = new HashSet<int>();
            for(int i = 0; i < n; i++)
            {
                var set = ReadSet();
                resultSet.UnionWith(set);
            }

            Console.WriteLine(resultSet.Count);
        }

        private static HashSet<int> ReadSet()
        {
            var set = new HashSet<int>();
            string line = Console.ReadLine();

            if (string.IsNullOrEmpty(line)) 
            {
                return set;
            }

            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts.Skip(1))
            {
                if (int.TryParse(part, out int number))
                {
                    set.Add(number);
                }
            }

            return set;
        }
    }
}