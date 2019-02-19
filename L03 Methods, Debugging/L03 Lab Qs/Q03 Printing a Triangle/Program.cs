using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Printing_a_Triangle
{
    class Program
    {
        static int sizeOfTriangle = int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            TopPart(sizeOfTriangle);
            BottomPart(sizeOfTriangle);
        }

        static void TopPart(int size)
        {
            for (int row = 1; row <= size; row++)
            {
                collumn(row);
            }
        }

        static void BottomPart(int size)
        {
            for (int row = size-1; row >= 1; row--)
            {
                collumn(row);
            }
        }

        static void collumn(int row)
        {
            for (int coll = 1; coll <= row; coll++)
            {
                Console.Write(coll + " ");
            }
            Console.WriteLine();
        }
    }
}
