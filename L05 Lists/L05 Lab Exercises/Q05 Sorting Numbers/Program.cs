using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Sorting_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stringFormat = input.Split(' ').ToList();
            var numbers = new List<double>();

            // var numbers = Console.ReadLine()    More streamlined
                    //.Split(' ')
                    //.Select(double.Parse)
                    //.ToList();

            for (int i = 0; i < stringFormat.Count; i++)
            {
                numbers.Add(double.Parse(stringFormat[i]));
            }

            numbers.Sort();

            Console.WriteLine(String.Join(" <= ", numbers));

            // numbers.ForEach(Console.WriteLine(String.Join(" <= ",numbers)));
        }
    }
}
