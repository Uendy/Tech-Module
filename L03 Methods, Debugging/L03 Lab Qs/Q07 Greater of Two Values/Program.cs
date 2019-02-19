using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Greater_of_Two_Values
{
    class Program
    {
        static string dataType = Console.ReadLine().ToLower();

        static void Main(string[] args)
        {
            if (dataType == "string")
            {
                Console.WriteLine(StringComparison());
            }
            else if (dataType == "char")
            {
                Console.WriteLine(CharacterComparison());
            }
            else if (dataType == "int")
            {
                Console.WriteLine(IntegerComparison());
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }

        }

        
        static string StringComparison()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            if (firstString.CompareTo(secondString) > 0) //firstString is first alphabetically
            {
                return firstString;
            }
            else
            {
                return secondString;
            }
        }
        static char CharacterComparison()
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            if (firstSymbol > secondSymbol)
            {
                return firstSymbol;
            }
            else
            {
                return secondSymbol;
            }
        }
        static int IntegerComparison()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
    }
}
