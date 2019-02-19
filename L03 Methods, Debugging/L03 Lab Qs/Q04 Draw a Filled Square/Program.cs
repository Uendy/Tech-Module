using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Draw_a_Filled_Square
{
    class Program
    {
        static int sizeOfSquare = int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            UpperBottomBorder(sizeOfSquare);
            MiddleBorders(sizeOfSquare);
            UpperBottomBorder(sizeOfSquare);
        }

        static void UpperBottomBorder(int sizeOfSquare)
        {
            for (int i = 1; i <= sizeOfSquare; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
        }

        static void MiddleBorders(int sizeOfSquare)
        {
            for (int row = 1; row <= sizeOfSquare-2; row++)
            {
                Console.Write("-");
                MiddleFiller(sizeOfSquare);
                Console.WriteLine("-");
            }
        }

        static void MiddleFiller(int sizeOfSquare)
        {
            for (int turns = 1; turns < sizeOfSquare; turns++)
            {
                Console.Write("\\/");
            }
        }
    }
}
