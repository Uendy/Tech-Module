using System;
public class Program
{
    public static void Main()
    {
        //check questions: https://judge.softuni.bg/Contests/Practice/Index/1147#0

        #region
        //You are given the number of homes N the Hogfather has to visit, on the first line.
        //And then the total number of presents he took when leaving the workshop on the second line.

        //In each home Hogfather visits he counts the number of socks above the fireplace and gives you that number.
        //If he runs out of presents he has to go back to the workshop for more.

        //The number of presents he has to get is equal to the integer value of initial presents divided(integer division) by
        //homes visited including the current one.Multiplied by the number of remaining homes,
        //plus the number of presents he needs in addition for the current home or in other words:
        //({ initialPresents} / { visitedHomes}) * { remainingHomes} + { additionalPresents}

        //There are two possible outputs:
        //•	If the initial number of presents is enough you print the remaining presents on a single line
        //-On a single line the number of presents left - { presentsNumber}
        //•	If the Hogfather run out of presents at some point print two lines
        //-On the first line print – total number of times he went back - { timesBack}
        //-On the second line print – total number of presents he took in addition - { additionalPresentsTaken}
        #endregion

        int totalHomes = int.Parse(Console.ReadLine());
        int initialPresent = int.Parse(Console.ReadLine());

        var currentPresents = initialPresent;
        int timesBack = 0;
        int totalAdditionalPresents = 0;

        for (int home = 1; home <= totalHomes; home++)
        {
            int presentsNeeded = int.Parse(Console.ReadLine());
            bool enoughPresents = currentPresents >= presentsNeeded;
            if(!enoughPresents)
            {
                int remainingHomes = totalHomes - home;
                int currentHousePresents = presentsNeeded - currentPresents;
                int additionalPresents = (initialPresent / home) * remainingHomes + currentHousePresents;

                currentPresents += additionalPresents;

                timesBack++;
                totalAdditionalPresents += additionalPresents;
            }

            currentPresents -= presentsNeeded;
        }

        bool noReturns = timesBack == 0;
        if (noReturns)
        {
            Console.WriteLine(currentPresents);
        }
        else
        {
            Console.WriteLine(timesBack);
            Console.WriteLine(totalAdditionalPresents);
        }
    }
}