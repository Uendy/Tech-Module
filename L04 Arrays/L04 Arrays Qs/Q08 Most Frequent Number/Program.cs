using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(ushort.Parse)
                .ToArray();

            int currentCounter = 0;
            int highScore = 0;
            int currentSymbol = 0;
            int maxSymbol = 0;

            for (int index = 0; index < array.Length; index++)
            {
                for (int rotation = 0; rotation < array.Length; rotation++)
                {
                    bool sameNumberCheck = array[index] == array[rotation];
                    if (sameNumberCheck == true)
                    {
                        currentSymbol = array[index];
                        currentCounter++;
                    }
                }

                if (highScore == 0)
                {
                    highScore = currentCounter;
                    maxSymbol = currentSymbol;
                    currentCounter = 0;
                }
                else if (highScore == currentCounter)
                {
                    currentCounter = 0;
                }
                else if (currentCounter > highScore)
                {
                    maxSymbol = currentSymbol;
                    highScore = currentCounter;
                    currentCounter = 0;
                }
                currentCounter = 0;
                  
            }

            Console.WriteLine(maxSymbol);
        }
    }
}
