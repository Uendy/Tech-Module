using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> values = input.Split(' ').ToList();
            List<double> numbers = new List<double>();

            for (int index = 0; index < values.Count; index++)
            {
                numbers.Add(double.Parse(values[index]));
            }

            bool keepCycling = true;
            while (keepCycling == true)
            {
                keepCycling = false;

                for (int index = 0; index < numbers.Count - 1; index++)
                {
                    bool checkEqualNumber = numbers[index] == numbers[index + 1];
                    if (checkEqualNumber == true)
                    {
                        numbers[index + 1] = numbers[index] + numbers[index + 1];
                        numbers.RemoveAt(index);
                        keepCycling = true;
                    }
                }

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
