using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Condence_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {


                if (array.Length == 1 )
                {
                    Console.WriteLine($"{array[0]} is already condensed to number");
                }
                else if (array.Length-i % 2 == 0) // even number at start
                {
                    //Console.WriteLine(EvenArrayCondenser(array));
                    for (int even = 0; even < array.Length - 1; even++)
                    {
                        array[even] = array[even] + array[even + 1];
                    }
                    array[array.Length-1] = 0;
                }
                else // odd
                {
                    for (int odd = 0; odd < array.Length-1; odd++)
                    {
                        array[odd] = array[odd] + array[odd + 1];
                        
                    }
                    array[array.Length-1] = 0;
                }

                while (i != array.Length || i != 0)
                {
                    this is for all the middle ones:
                }
            }
            Console.WriteLine(array[1]);
        }

        
    }
}
