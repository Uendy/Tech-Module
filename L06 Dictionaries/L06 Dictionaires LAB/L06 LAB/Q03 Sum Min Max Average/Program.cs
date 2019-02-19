using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Sum_Min_Max_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            var listOfNumbers = new List<int>();
            for (int index = 0; index < numberOfInputs; index++)
            {
                listOfNumbers.Add(int.Parse(Console.ReadLine()));
            }

            var sum = listOfNumbers.Sum();    
            var min = listOfNumbers.Min();
            var max = listOfNumbers.Max();
            var average = listOfNumbers.Average();

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
