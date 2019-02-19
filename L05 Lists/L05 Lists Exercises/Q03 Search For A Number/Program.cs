using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Search_For_A_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int index = 0; index < array[1]; index++)
            {
                input.RemoveAt(0); // when you remove remember the index shifts by 1 down
            }

            bool contains = input.Contains(array[2]);
            if (contains == true)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
