using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();

            sbyte age = sbyte.Parse(Console.ReadLine());

            char gender = char.Parse(Console.ReadLine());

            long personalIDNumber = long.Parse(Console.ReadLine()); //e.g. 8 306 112 507

            int employeeNumber = int.Parse(Console.ReadLine()); //27 560 000…27 569 999

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {personalIDNumber}");
            Console.WriteLine($"Unique Employee number: {employeeNumber}");

        }
    }
}
