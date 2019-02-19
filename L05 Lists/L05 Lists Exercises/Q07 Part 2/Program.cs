using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 80 out of 100
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var specialNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int bomb = specialNumbers[0];
            int radius = specialNumbers[1];

            //finding the index of the bomb
            var listOfBombs = new List<int>();
            int amountOfBombs = 0;
            for (int indexOfInput = 0; indexOfInput < input.Count; indexOfInput++)
            {
                bool foundIndexOfBomb = input[indexOfInput] == bomb;
                if (foundIndexOfBomb == true)
                {
                    listOfBombs.Insert(amountOfBombs, indexOfInput);
                    amountOfBombs++;
                }
            }

            for (int currentBombIndex = 0; currentBombIndex < listOfBombs.Count; currentBombIndex++)
            {
                int theBombIndex = listOfBombs[currentBombIndex];

                //Right of Index 
                int possibleIndexs = input.Count - (theBombIndex + 1);
                bool enoughIndexs = possibleIndexs >= radius;
                if (enoughIndexs == true) // good
                {
                    for (int i = 0; i < radius; i++)
                    {
                        input[theBombIndex + 1 + i] = int.MaxValue;
                    }
                }
                else // index out of Range exception
                {
                    for (int i = 0; i < possibleIndexs; i++)
                    {
                        input[theBombIndex + 1 + i] = int.MaxValue;
                    }
                }

                //Left of Index + Index!
                int possibleIndexsLeft = theBombIndex;
                bool enoughIndexsLeft = possibleIndexsLeft >= radius;
                if (enoughIndexsLeft == true) // good
                {
                    for (int i = 0; i < radius; i++)
                    {
                        input[theBombIndex - 1 - i] = int.MaxValue;
                    }
                }
                else
                {
                    for (int i = 0; i < possibleIndexsLeft; i++)
                    {
                        input[theBombIndex - 1 - i] = int.MaxValue;
                    }
                }
                input[theBombIndex] = int.MaxValue;
            }

            input.RemoveAll(x => x == int.MaxValue);

            int sum = 0;
            for (int finalIndex = 0; finalIndex < input.Count; finalIndex++)
            {
                sum += input[finalIndex];
            }
            Console.WriteLine(sum);
        }
    }
}
