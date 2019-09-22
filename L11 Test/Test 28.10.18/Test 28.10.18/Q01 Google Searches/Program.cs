using System;
public class Program
{
    public static void Main()
    {
        //Check Q01 and Q02 here: https://judge.softuni.bg/Contests/Practice/Index/1320#0
        //Check Q03 and Q04 here: https://judge.softuni.bg/Contests/Practice/Index/1321#0

        //You will be given several lines of input and you must calculate how much money Google makes from user searches.
        //On the first line you will receive total days. On the second line you will receive the number of users (n) that make google searches for a single day.
        //Then, you will receive the money Google makes from a single search of a user. On the next n lines you will get the words that each user has in his search. 
        //You have to calculate the total money from the searches for the given days. However there are some additional rules:

        //•	If the words a user uses are greater than 5, we ignore the search and we do not calculate the money from it
        //•	If the search contains only one word, the money from the search are doubled
        //•	Money made by each third user are tripled.

        //After calculating the total money, print them in the following format:
        //“Total money earned for { days} days: { totalMoney}”. The money should me formatted to the second decimal point.

        int days = int.Parse(Console.ReadLine());
        int users = int.Parse(Console.ReadLine());
        double moneyPerSearch = double.Parse(Console.ReadLine());

        double total = 0.0;

        for (int i = 1; i <= users; i++)
        {
            double currentBonus = days * moneyPerSearch;

            int currentWords = int.Parse(Console.ReadLine());

            bool aboveFive = currentWords > 5; //•	If the words a user uses are greater than 5, we ignore the search and we do not calculate the money from it
            if (aboveFive)
            {
                continue;
            }

            bool singleBonus = currentWords == 1;  //•	If the search contains only one word, the money from the search are doubled
            if (singleBonus)
            {
                currentBonus *= 2;
            }

            bool thirdUserBonus = i % 3 == 0; //•	Money made by each third user are tripled.
            if (thirdUserBonus)
            {
                currentBonus *= 3;
            }

            total += currentBonus;
        }

        Console.WriteLine($"Total money earned for {days} days: {total:f2}");
    }
}