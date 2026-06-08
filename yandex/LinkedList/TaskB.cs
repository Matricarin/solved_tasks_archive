using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yandex.LinkedList
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var solver = new PriceSolver(array);

            Console.WriteLine(solver.Solve());
        }
    }

    public class PriceSolver
    {
        private int[] _array;

        public PriceSolver(int[] array)
        {
            _array = array;
        }

        public string Solve()
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            var i1 = 0; var j1 = 0; var i2 = 0; var j2 = 0;
            for(int i = 0; i < _array.Length; i++)
            {               
                for(int j = i + 1; j < _array.Length; j++)
                {
                    if(_array[i] - _array[j] < min)
                    {
                        min = _array[i] - _array[j];
                        i1 = i; j1 = j;
                    }

                    if(_array[i] - _array[j] > max)
                    {
                        max = _array[i] - _array[j];
                        i2 = i; j2 = j;
                    }
                }
            }

            var diff = new Diff(i1+1, j1+1, i2+1, j2+1);

            return diff.ToString();
        }

        private class Diff
        {
            public int I1{get;}
            public int J1{get;}
            public int I2{get;}
            public int J2{get;}
            public Diff(int i1, int j1, int i2, int j2)
            {
                I1 = i1;
                J1 = j1;
                I2 = i2;
                J2 = j2;
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, $"{I1} {J1}", $"{I2} {J2}");
            }
        }
    }
}
