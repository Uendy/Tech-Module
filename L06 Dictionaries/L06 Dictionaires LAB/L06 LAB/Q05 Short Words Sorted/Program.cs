using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .ToLower()
                .Split(
                new[] { '.', ',', ':', ';', '(', ')', ' ', '!', '?', '[', ']', '\'', '/' },
                StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            Console.WriteLine(String.Join(", ",input));
        }
    }
}
