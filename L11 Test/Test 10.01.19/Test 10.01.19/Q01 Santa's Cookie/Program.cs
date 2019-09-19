using System;
public class Program
{
    public static void Main()
    {
        //You will receive the amount of batches – n that you need to bake. For every batch you will receive ingredients:  flour, sugar and cocoa in grams, each on a new line.
        //You need to calculate how many boxes of cookies you get for every batch with the given ingredients and total boxes of cookies for all batches.
        //To calculate the number of boxes per batch you need to divide total cookies per bake by cookies per box (see the table below).
        //To get the total cookies per bake use the following formula and round the result to the nearest lower number:  

        //({cup} + {smallSpoon} + {bigSpoon}) * min from({flourCups}, {sugarSpoons}, {cocoaSpoons}) / singleCookieGrams

        //To get the flourCups divide flour by cups.
        //To get the sugarSpoons divide sugar by bigSpoon. 
        //And for the cocoaSpoons divide cocoa by smallSpoon.
        //The cups and the spoons must be integer numbers.

        //If flourCups, sugarSpoons or cocoaSpoons for a single bake are not enough(<= 0), print the following message: "Ingredients are not enough for a box of cookies."
        //Otherwise calculate the cookies and print the number of boxes you get for the current batch:
        //"Boxes of cookies: {boxes of cookies per current bake}"

        //When you finish baking, pack the all the cookies in boxes and send them to Santa and his dwarfs and print the total number of boxes on the console.
        //"Total boxes: {totalBoxes for all bakes}"

        //Table of values:
        //singe cookie = 25g
        //cup = 180g
        //small spoon = 10g
        //big spoon = 20g
        //cookie per box = 5


        int batches = int.Parse(Console.ReadLine());

        int boxes = 0;

        for (int i = 0; i < batches; i++)
        {
            int amountOfFlourInGrams = int.Parse(Console.ReadLine());
            int amountOfSugarInGrams = int.Parse(Console.ReadLine());
            int amountOfCocoaInGrams = int.Parse(Console.ReadLine());

            int cupOfFlour = amountOfFlourInGrams / 140;
            int smallSpoon = amountOfCocoaInGrams / 10;
            int bigSpoon = amountOfSugarInGrams / 20;

            bool insufficientIngrediants = cupOfFlour == 0 || smallSpoon == 0 || bigSpoon == 0;
            if (insufficientIngrediants)
            {
                Console.WriteLine("Ingredients are not enough for a box of cookies.");
                continue;
            }

            int minOfThis = Math.Min(cupOfFlour, Math.Min(smallSpoon, bigSpoon));

            //({cup} + {smallSpoon} + {bigSpoon}) * min from({flourCups}, {sugarSpoons}, {cocoaSpoons}) / singleCookieGrams
            int cookies = ((140 + 10 + 20) * minOfThis) / 25; // becose one cookie = 25 grams

            int currentBox = (cookies / 5);
            boxes += currentBox;

            Console.WriteLine($"Boxes of cookies: {currentBox}");
        }

        Console.WriteLine($"Total boxes: {boxes}");
    }
    }
}