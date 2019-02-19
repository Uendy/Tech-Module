using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11_Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (array.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int index = 0; index < array.Length; index++)
            {
                long leftSum = 0;
                long rightSum = 0;

                for (int i = 0; i < index; i++)
                {
                    leftSum += array[i];
                }

                for (int i = index + 1; i < array.Length; i++)
                {
                    rightSum += array[i]; 
                }

                bool leftAndRightEqual = leftSum == rightSum;
                if (leftAndRightEqual == true)
                {
                    Console.WriteLine(index);
                        return;
                }
                
            }

            Console.WriteLine("no");
        }
    }
}
