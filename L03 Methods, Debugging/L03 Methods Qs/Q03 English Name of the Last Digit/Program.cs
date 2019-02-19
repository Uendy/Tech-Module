using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int readNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(LastLetterGiver(readNumber));
        }
        static string LastLetterGiver(int readNumber)
        {
            int lastdigit = readNumber % 10;

            switch (lastdigit)
            {
                case 0:
                    return "zero";
                    
                case 1:
                    return "one";
                    
                case 2:
                    return "two";
                   
                case 3:
                    return "three";
                    
                case 4:
                    return "four";

                case 5:
                    return "five";
                   
                case 6:
                    return "six";
                   
                case 7:
                    return "seven";
                  
                case 8:
                    return "eight";
                 
                case 9:
                    return "eight";
                  
                default:
                    return "Nodefault";
                  
            }
        }
    }
}
