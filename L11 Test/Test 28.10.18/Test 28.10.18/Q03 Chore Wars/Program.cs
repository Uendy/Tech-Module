using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Your task is to help Pesho understand what his wife is telling him and calculate how much time it will take him to do all the chores. 
        //You will receive commands until you receive the "wife is happy" line.

        //Each valid command will give you information about a chore. You will have to calculate how much time each chore will take and how much time it will take him overall.
        //The command is valid if it follows one of the following rules:
        //•	A valid command for doing the dishes always starts with "<" and ends with ">" and has only lowercase letters and digits.
        //•	A valid command for cleaning the house always starts with "[" and ends with "]" and has only uppercase letters and digits.
        //•	A valid command for doing the laundry always starts with "{" and ends with "}" and has any character in the middle.
        //All other commands are invalid, and you should just skip them.You have to sum the numbers inside each command and add them to the total time for the chore. 

        //In the end you have to print the time it will take Pesho for the chores in the format:
        //"Doing the dishes - {timeDishes} min."
        //"Cleaning the house - {timeCleaning} min."
        //"Doing the laundry - {timeLaundry} min."
        //"Total - {totalMinutes} min."

        int dishes = 0;
        int cleaning = 0;
        int laundy = 0;

        var specialChars = new List<char[]>();
        var dishesChars = new char[] { '<', '>' };
        var cleaningChars = new char[] { '[', ']' };
        var laundryChars = new char[] { '{', '}' };

        specialChars.Add(dishesChars);
        specialChars.Add(cleaningChars);
        specialChars.Add(laundryChars);

        string input = Console.ReadLine();
        while (input != "wife is happy")
        {
            foreach (var charPair in specialChars)
            {
                var range = GetRange(input, charPair); 
                bool wrongRange = range.Count() == 0;
                if (wrongRange)
                {
                    continue;
                }

                switch (charPair[0])
                {
                    case '<':
                        bool firstIsValid = FirsValidation(range);
                        while (firstIsValid == false)
                        {
                            var rangeAsString = string.Join("", range);
                            range = GetRange(rangeAsString + ">", charPair); // this is a hack, not a job well done
                            firstIsValid = FirsValidation(range);
                        }

                        dishes += CalculateTime(range);
                        break;

                    case '[':
                        bool secondIsValid = SecondValidation(range); // and has only uppercase letters and digits.
                        cleaning += CalculateTime(range);
                        break;

                    case '{':
                        // no validation needed
                        laundy += CalculateTime(range);
                        break;

                    default:
                        break;
                }
            }


            input = Console.ReadLine();
        }

        Console.WriteLine($"Doing the dishes - {dishes} min.");
        Console.WriteLine($"Cleaning the house - {cleaning} min.");
        Console.WriteLine($"Doing the laundry - {laundy} min.");

        int totalTime = dishes + cleaning + laundy;

        Console.WriteLine($"Total - {totalTime} min.");
    }

    public static int CalculateTime(List<char> range)
    {
        int time = 0;

        foreach (var character in range)
        {
            bool isDigit = char.IsDigit(character);
            if (isDigit)
            {
                int currentTime = int.Parse(character.ToString());
                time += currentTime;
            }
        }

        return time;
    }

    public static bool SecondValidation(List<char> range)
    {
        bool isValid = true;

        foreach (var character in range)
        {
            bool correct = char.IsDigit(character) || character >= 65 && character <= 90;
            if (!correct)
            {
                isValid = false;
            }
        }

        return isValid;
    }

    public static bool FirsValidation(List<char> range)
    {
        bool isValid = true;

        foreach (var character in range)
        {
            bool correct = char.IsDigit(character) || character >= 97 && character <= 122;
            if (!correct)
            {
                return false;
            }
        }

        return isValid;
    }

    public static List<char> GetRange(string input, char[] charPair)
    {
        char start = charPair[0];
        char end = charPair[1];

        var indexOfStart = input.IndexOf(start);
        var indexOfEnd = input.IndexOf(end);

        if (indexOfStart == -1 || indexOfEnd == -1)
        {
            return new List<char>();
        }

        var inputAsArray = input.ToCharArray().ToList();

        var lengthOfRange = indexOfEnd - indexOfStart;

        var range = inputAsArray.GetRange(indexOfStart + 1, lengthOfRange - 1);
        return range;
    }
}