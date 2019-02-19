using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q045
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FullName());
        }

        static string FullName()
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            return $"{firstName} {secondName}";
        
        }
    }
}
