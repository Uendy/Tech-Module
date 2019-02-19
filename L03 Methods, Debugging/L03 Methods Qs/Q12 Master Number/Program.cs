using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q12_Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Super good Palendrome Method Here

            int maxValue = int.Parse(Console.ReadLine());

            for (int checkedNumber = 232; checkedNumber <= maxValue; checkedNumber ++) 
            {
                if (SymmetryCheck(checkedNumber) == false)
                {
                    continue;
                }
                if (DivisibleBySeven(checkedNumber) == false)
                {
                    continue;
                }
                if (CheckForAtleastOneEvenDigit(checkedNumber) == false)
                {
                    continue;
                }

                bool trifecta = SymmetryCheck(checkedNumber) == true && DivisibleBySeven(checkedNumber) == true && CheckForAtleastOneEvenDigit(checkedNumber) == true;

                if (trifecta == true)
                {
                    Console.WriteLine(checkedNumber);
                }
            }


        }

        static bool SymmetryCheck(int checkedNumber) //Martins way = superSmart and simple
        {
            string checkedNumberAsString = checkedNumber.ToString();

            int length = checkedNumberAsString.Length;

            for (int i = 0; i < checkedNumberAsString.Length/2; i++)
            {
                if (checkedNumberAsString[i] != checkedNumberAsString[length - i - 1])
                { return false; }
            }

            return true;
        }

        static bool DivisibleBySeven(int checkedNumber)
        {
            bool isDivisibleBYSeven = false;

            int result = 0;

            foreach (var symbol in checkedNumber.ToString())
            {
                var digit = symbol - '0';
                result += digit;
            }

            if (result % 7 == 0)
            {
                isDivisibleBYSeven = true;
            }
            return isDivisibleBYSeven;
        }

        static bool CheckForAtleastOneEvenDigit(int checkedNumber)
        {
            bool oneEvenDigit = false;
            string checkedNumberConvertedToString = checkedNumber.ToString();

            foreach (var symbol in checkedNumberConvertedToString)
            {
                var digit = symbol - '0';

                if (digit % 2 == 0)
                {
                    oneEvenDigit = true;
                }
            }
            return oneEvenDigit;
        }
    }   
}
