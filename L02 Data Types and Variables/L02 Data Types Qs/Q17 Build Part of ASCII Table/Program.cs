using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q17_Build_Part_of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingSymbol = int.Parse(Console.ReadLine());
            int endingSymbol = int.Parse(Console.ReadLine());


            for (char symbol = (char)startingSymbol; symbol <= endingSymbol; symbol++)
            {
                Console.Write(symbol + " ");
            }
        }
    }
}
