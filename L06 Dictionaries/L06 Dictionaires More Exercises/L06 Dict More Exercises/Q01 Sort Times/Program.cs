using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Sort_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(String.Join(", ",input));
        }
    }
}
