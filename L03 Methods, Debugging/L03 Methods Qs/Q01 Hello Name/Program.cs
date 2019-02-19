using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Hello_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, " + NameAccepter() + "!");
        }
        static string NameAccepter()
        {
            string name = Console.ReadLine();
            return name;
        }

    }
}
