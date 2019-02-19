using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var specialNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int bomb = specialNumbers[0];
            int blastRadius = specialNumbers[1];


            //to find the bombIndex
            var listOfIndexsOfBomb = new List<int>();
            int numberOfBombs = 0;
            for (int index = 0; index < input.Count; index++)
            {
                bool findTheBomb = input[index] == bomb;
                if (findTheBomb == true)
                {
                    numberOfBombs++;
                    listOfIndexsOfBomb.Insert(numberOfBombs - 1, index);
                    //listOfIndexsOfBomb[numberOfBombs]  = index;
                }
            }


            for (int currentBombCount = 0; currentBombCount < numberOfBombs; currentBombCount++)
            {


                //Removing the index's after the bomb
                //for (int topRemover = 0; topRemover < blastRadius; topRemover++)

                bool notEnoughIndexsAbove = blastRadius + listOfIndexsOfBomb[currentBombCount] > input.Count;
                if (notEnoughIndexsAbove == true)
                {
                    int indexsUnderCount = input.Count - listOfIndexsOfBomb[currentBombCount] - 1;
                    for (int i = 1; i < indexsUnderCount + 1; i++)
                    {
                        input[listOfIndexsOfBomb[currentBombCount] + i] = int.MaxValue;
                    }

                }
                else
                {
                    for (int i = 0; i < blastRadius + 1; i++)
                    {
                        input[listOfIndexsOfBomb[currentBombCount] + i] = int.MaxValue;
                    }
                }



                //Removing index's before the bomb
                int numbersUnderBombRemoved = listOfIndexsOfBomb[currentBombCount];
                for (int bottomRemover = 0; bottomRemover < blastRadius; bottomRemover++)
                {
                    bool notEnoughIndexsUnder = listOfIndexsOfBomb[currentBombCount] < blastRadius;
                    if (notEnoughIndexsUnder == true)
                    {
                        int numberOfRemovableIndexs = blastRadius - listOfIndexsOfBomb[currentBombCount];
                        for (int i = 1; i < numberOfRemovableIndexs + 1; i++)
                        {
                            input[listOfIndexsOfBomb[currentBombCount] - i] = int.MaxValue;
                        }
                        break;
                    }
                    else
                    {
                        input[numbersUnderBombRemoved] = int.MaxValue;
                        numbersUnderBombRemoved--;
                    }
                }
            }
                input.RemoveAll(x => x == int.MaxValue);
            //The summing and printing of the remainder
            int sum = 0;
            for (int finalIndex = 0; finalIndex < input.Count; finalIndex++)
            {
                sum += input[finalIndex];
            }

            Console.WriteLine(sum);
        }
    }
}
