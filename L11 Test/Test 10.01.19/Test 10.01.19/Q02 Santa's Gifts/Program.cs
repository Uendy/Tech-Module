using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You will be given an array of integers, which represent the house numbers you should visit. The commands will lead you to them. 
        //If they lead you to non-existing places, don’t move.

        //•	Forward { numberOfSteps}
        //•	Back { numberOfSteps}
        //o When you receive the “Forward” or “Back” command, you move the given number of times in this direction and remove the house in this position from your list. Also, when you receive the next command, you continue from this position.

        //•	Gift { index}{ houseNumber}
        //o Enter a new house number, which the dwarves have left out on purpose, at the given position and move to its position. 

        //•	Swap { indexOfFirst}{ indexOfSecond}
        //o Santa wants to rearrange his path and swap the order of two houses. You will receive the numbers of the houses, that need to be switched and he doesn’t need to move to fulfill this command.

        int numberOfCommands = int.Parse(Console.ReadLine());

        int currentIndex = 0;

        var houses = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        for (int i = 0; i < numberOfCommands; i++)
        {
            string input = Console.ReadLine();
            var inputTokens = input.Split(' ').ToList();

            var command = inputTokens[0];

            switch (command)
            {
                case "Forward":
                    int spaces = int.Parse(inputTokens[1]);
                    currentIndex = MoveForward(houses, currentIndex, spaces);
                    break;

                case "Back":
                    int spacesBack = int.Parse(inputTokens[1]);
                    currentIndex = MoveBack(houses, currentIndex, spacesBack);
                    break;

                case "Swap":
                    int firstHouse = int.Parse(inputTokens[1]);
                    int secondHouse = int.Parse(inputTokens[2]);
                    SwapHouses(houses, firstHouse, secondHouse);
                    break;

                case "Gift":
                    int index = int.Parse(inputTokens[1]);
                    int houseNumber = int.Parse(inputTokens[2]);
                    currentIndex = DropGift(houses, index, houseNumber, currentIndex);
                    break;

                default:
                    break;
            }
        }

        Console.WriteLine($"Position: {currentIndex}");
        string outPut = string.Join(", ", houses);
        Console.WriteLine(outPut);
    }

    public static int DropGift(List<int> houses, int index, int houseNumber, int currentIndex)
    {
        bool isInside = index >= 0 && index < houses.Count();
        if (!isInside)
        {
            return currentIndex;
        }

        houses.Insert(index, houseNumber);
        currentIndex = index;

        return currentIndex;
    }

    public static void SwapHouses(List<int> houses, int firstHouse, int secondHouse)
    {
        bool bothInside = houses.Contains(firstHouse) && houses.Contains(secondHouse);
        if (!bothInside)
        {
            return;
        }

        int indexOfFirst = houses.IndexOf(firstHouse);
        int indexOfSecond = houses.IndexOf(secondHouse);

        houses.RemoveAt(indexOfFirst);
        houses.Insert(indexOfFirst,secondHouse);

        houses.RemoveAt(indexOfSecond);
        houses.Insert(indexOfSecond, firstHouse);
    }

    public static int MoveBack(List<int> houses, int currentIndex, int spacesBack)
    {
        bool isInsideArray = currentIndex - spacesBack >= 0 && spacesBack < houses.Count();
        if (!isInsideArray)
        {
            return currentIndex;
        }

        currentIndex -= spacesBack;
        houses.RemoveAt(currentIndex);

        return currentIndex;
    }

    public static int MoveForward(List<int> houses, int currentIndex, int spaces)
    {
        bool isInsideArray = currentIndex + spaces < houses.Count() && spaces > 0;
        if (!isInsideArray)
        {
            return currentIndex;
        }

        currentIndex += spaces;
        houses.RemoveAt(currentIndex);

        return currentIndex;
    }
}