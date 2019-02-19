using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Largest_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            input.Sort();
            input.Reverse();

            var result = input.Take(3)
                    .ToArray();

            Console.WriteLine(String.Join(" ",result));

            // or
            var inputLine = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .OrderByDescending(x => x)
                            .Take(3);
            Console.WriteLine(String.Join(" ", inputLine));
        }
    }
}
