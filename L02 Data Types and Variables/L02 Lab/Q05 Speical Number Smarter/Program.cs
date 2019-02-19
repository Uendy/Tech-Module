using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Speical_Number_Smarter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int digit = i;
                int sumOfDigits = 0;
                bool specialNumberCheck = false;

                while (digit > 0)
                {
                    sumOfDigits += digit % 10;
                    digit = digit / 10;
                }

                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {specialNumberCheck = true; }

                Console.WriteLine($"{i} -> {specialNumberCheck}");

            }
        }
    }
}
