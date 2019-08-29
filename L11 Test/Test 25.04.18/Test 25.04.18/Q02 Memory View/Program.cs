using System;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //As a Gamer, Pesho is thrilled with source code and is excited to have deeper understanding of the games code,
        //so he started digging in the memory view.But because he can`t read it, 
        //you should write a programm which transforms the memory display in readable form. 

        //Until you receive "Visual Studio crash" you will be receiving lines from the memory view in 2 - byte integer unsigned display.
        //Each line consists of exactly 22 integers, separated by whitespace.
        //You should find every string in the whole input and print them on the console.

        //Every string starts with-> "32656 19759 32763"
        //After the pointer there is one zero and the size of the string -> "0 5"
        //After the size of string there is one more zero and on the next n columns are the integers for
        //each character -> " 0 80 101 115 104 111"
        //The above example is the string "Pesho".

        //You must find all strings and display them on the console, using the ASCII code for each character.
        #endregion

        //read all of it and combine into a single string
        var sb = new StringBuilder();

        string input = Console.ReadLine();

        while (input != "Visual Studio crash")
        {
            sb.Append(input);

            input = Console.ReadLine();
        }

        string totalInput = sb.ToString();

        // split and remove all the excess 0s
        var splitParameters = new string[] { " ", "\r\n", "\r", "\n" };
        var inputAsArray = totalInput.Split(splitParameters, StringSplitOptions.RemoveEmptyEntries).ToList();

        inputAsArray.RemoveAll(x => x == "0");

        //  find all the prefixs, remove everything before them and them
        string prefix = "32763";

        bool containsPreFix = inputAsArray.Contains(prefix); 
        while (containsPreFix)
        {
            int indexOfPreFix = inputAsArray.IndexOf(prefix) + 1; // to remove up to and including prefix

            inputAsArray.RemoveRange(0, indexOfPreFix); 

            // getting the size of the string and the seperate chars
            int numberOfChars = int.Parse(inputAsArray[0].ToString());
            var futureString = new char[numberOfChars];

            for (int index = 1; index <= numberOfChars; index++) // converting from int to ASCII Char
            {
                int currentNumber = int.Parse(inputAsArray[index]);
                char currentChar = (char)currentNumber;
                futureString[index - 1] = currentChar;
            }

            var actualString = string.Join("", futureString);
            Console.WriteLine(actualString);

            containsPreFix = inputAsArray.Contains(prefix); 
        }
    }
}