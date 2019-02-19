using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            input.Sort();

            SquareChecker(input);

            input.Reverse();
            input.RemoveAll(x => x == 0);

            Console.WriteLine(String.Join(" ",input));
        }

        static List<int> SquareChecker(List<int> input)
        {
            for (int index = 0; index <= input.Count-1; index++)
            {
                bool outOfLoopCheck = false;

                for (int squareNumber = 0; squareNumber <= Math.Sqrt(input[index]); squareNumber++)
                {
                    bool squareCheck = Math.Pow(squareNumber, 2) == input[index]; 
                    //better algorythm squareCheck = Math.Sqrt(input[index])%1 == 0; Checks for remainder, only square dont have!
                    if (squareCheck == true)
                    {
                        outOfLoopCheck = true;
                        continue;
                    }
                }

                if (outOfLoopCheck == false)
                {
                    // used to be input.Remover(input[index]);
                    input[index] = 0; // when it removes it it removes it and fucks up the index
                }
                
            }
            return input;

        }
    }
}
