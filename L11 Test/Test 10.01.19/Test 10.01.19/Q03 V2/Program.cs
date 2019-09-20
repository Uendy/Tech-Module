using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        // //After the successful second Christmas, Santa needs to gather information about the behavior of children to plan the presents for next Christmas. 
        //He has a secret helper, who is sending him encrypted information. Your task is to decrypt it and create a list of the children who have been good. 

        //You will receive an integer, which represents a key and afterwards some messages, which you must decode by subtracting the key from the value of each character.
        //After the decryption, to be considered a valid match, a message should:
        //-Have a name, which starts after '@' and contains only letters from the Latin alphabet
        //- Have a behaviour type - "G"(good) or "N"(naughty) and must be surrounded by "!"(exclamation mark).

        //The order in the message should be: child’s name -> child’s behavior. They can be separated from the others by any character except: '@', '-', '!', ':' and '>'.
        //You will be receiving message until you are given the “end” command.Afterwards, print the names of the children, who will receive a present, each on a new line.
        int decrypt = int.Parse(Console.ReadLine());

        var helpers = new List<string>();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var asArray = input.ToCharArray().Select(x => x - decrypt).Select(x => (char)x).ToList();

            bool containsNameStart = asArray.Contains('@'); //Have a name, which starts after '@'
            if (!containsNameStart)
            {
                input = Console.ReadLine();
                continue;
            }

            int indexOfNameStart = asArray.IndexOf('@') + 1;

            var sb = new StringBuilder();
            for (int index = indexOfNameStart; index < asArray.Count(); index++)
            {
                char currentChar = asArray[index];
                bool isLetter = char.IsLetter(currentChar); // contains only letters from the Latin alphabet
                if (isLetter)
                {
                    sb.Append(currentChar);
                }
                else
                {
                    break;
                }
            }

            string name = sb.ToString();
            int endOfNameIndex = indexOfNameStart + 1 + name.Length;

            var desiredSubstringAsList = "!G!".Select(x => x + decrypt).Select(x => (char)x).ToList(); //Have a behaviour type - "G"(good) or "N"(naughty) and must be surrounded by "!"(exclamation mark).
            string desiredString = string.Join("", desiredSubstringAsList);

            int indexOfDesiredString = input.IndexOf(desiredString);

            int distanceOfRange = indexOfDesiredString - endOfNameIndex;
            bool wrongOrientation = distanceOfRange < 0; //The order in the message should be: child’s name -> child’s behavior.
            if (wrongOrientation)
            {
                input = Console.ReadLine();
                continue;
            }

            var range = asArray.GetRange(endOfNameIndex, distanceOfRange);
            var separator = string.Join("", range);

            bool isGoodAndValid = input.Contains(desiredString);
            if (isGoodAndValid)
            {
                 var listOfInvalidSeparators = new List<char>() { '@', '-', '!', ':', '>' }; //They can be separated from the others by any character except: '@', '-', '!', ':' and '>'.

                bool isValid = true;
                foreach (var sep in listOfInvalidSeparators) // check if any invalid separator is contained in the range
                {
                    bool invalidSeparator = separator.Contains(sep);
                    if (invalidSeparator)
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    helpers.Add(name);
                }
            }

            input = Console.ReadLine();
        }

        foreach (var name in helpers)
        {
            Console.WriteLine(name);
        }
    }
}