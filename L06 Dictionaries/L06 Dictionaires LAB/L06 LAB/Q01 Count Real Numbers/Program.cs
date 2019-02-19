using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var map = new SortedDictionary<double, int>();

            for (int index = 0; index < input.Length; index++)
            {
                bool alreadyContainsKey = map.ContainsKey(input[index]);

                if (alreadyContainsKey == true)
                {
                    map[input[index]] ++;
                }
                else // new key
                {
                    map[input[index]] = 1;
                }
            }

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
