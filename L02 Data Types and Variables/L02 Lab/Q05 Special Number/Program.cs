using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Special_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool specialNumberCheck = false;
            double digitSum = 0;
            int lastDigit = 0;
            double tensDigit = 0;

            for (int i = 1; i <= number; i++)
            {
                if (i <= 9)
                { digitSum = i; }
                else if (i <= 99)
                {
                    lastDigit = i % 10;
                    tensDigit = (i - lastDigit) / 10.0;
                    digitSum = lastDigit + tensDigit;
                }


                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                { specialNumberCheck = true; }

                Console.WriteLine($"{i} -> {specialNumberCheck}");

                specialNumberCheck = false;
            }
        }
    }
}
