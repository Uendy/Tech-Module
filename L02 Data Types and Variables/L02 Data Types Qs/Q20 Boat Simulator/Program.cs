using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q20_Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //From "More Exercises" URL: https://judge.softuni.bg/Contests/Practice/Index/570#13

            char firstBoat = char.Parse(Console.ReadLine());
            int firstBoatMoves = 0;

            char secondBoat = char.Parse(Console.ReadLine());
            int secondBoatMoves = 0;

            byte numberOfTurns = byte.Parse(Console.ReadLine());

            for (int round = 1; round <= numberOfTurns; round++)
            {
                string turn = Console.ReadLine();

                if (turn == "UPGRADE")
                {
                    firstBoat += (char)3;
                    secondBoat += (char)3;
                    continue;
                }

                if (round % 2 != 0)// odd
                {
                    firstBoatMoves += turn.Length;
                }
                else // even
                {
                    secondBoatMoves += turn.Length;
                }

                if (firstBoatMoves >= 50)
                {
                    Console.WriteLine(firstBoat);
                    return;
                }
                if (secondBoatMoves >= 50)
                {
                    Console.WriteLine(secondBoat);
                    return;
                }
            }

            if (firstBoatMoves > secondBoatMoves)
            {
                Console.WriteLine(firstBoat);
            }
            else
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}
