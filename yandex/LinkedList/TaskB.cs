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
            var imin = int.MaxValue;
            var jmin = int.MaxValue;
            var imax = int.MinValue;
            var jmax = int.MinValue;

            int imin_index = 0; 
            var jmin_index = 0; 
            var imax_index = 0; 
            var jmax_index = 0;

            for(int i = 0; i < _array.Length; i++)
            {
                if(_array[i] < imin)
                {
                    imin = _array[i];
                    imin_index = i;
                }

                if(_array[i] > jmax && i > imin_index)
                {
                    jmax = _array[i];
                    jmax_index = i;
                }

                if(_array[i] > imax)
                {
                    imax = _array[i];
                    imax_index = i;
                }

                if(imax < jmin && i > imax_index)
                {
                    jmin = _array[i];
                    jmin_index = i;
                }
            }

            return string.Join(Environment.NewLine, [$"{imin_index + 1} {jmax_index + 2}", $"{imax_index + 1} {jmin_index + 1}"]);
        }
    }
}