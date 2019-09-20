using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        //After the successful second Christmas, Santa needs to gather information about the behavior of children to plan the presents for next Christmas. 
        //He has a secret helper, who is sending him encrypted information. Your task is to decrypt it and create a list of the children who have been good. 

        //You will receive an integer, which represents a key and afterwards some messages, which you must decode by subtracting the key from the value of each character.
        //After the decryption, to be considered a valid match, a message should:
        //-Have a name, which starts after '@' and contains only letters from the Latin alphabet
        //- Have a behaviour type - "G"(good) or "N"(naughty) and must be surrounded by "!"(exclamation mark).

        //The order in the message should be: child’s name -> child’s behavior. They can be separated from the others by any character except: '@', '-', '!', ':' and '>'.
        //You will be receiving message until you are given the “end” command.Afterwards, print the names of the children, who will receive a present, each on a new line.

        var helpers = new List<string>();

        int decrypt = int.Parse(Console.ReadLine());

        string input = Console.ReadLine();
        while (input != "end")
        {
            var asArray = input.ToCharArray().Select(x => x-decrypt).Select(x => (char)x).ToList();

            //Have a name, which starts after '@'
            bool containsStart = asArray.Contains('@');
            if (!containsStart)
            {
                input = Console.ReadLine();
                continue;
            }
            int indexOfStart = asArray.IndexOf('@') + 1; // find where the name starts and cycle from there

            // contains only letters from the Latin alphabet
            var sb = new StringBuilder();
            for (int index = indexOfStart; index < asArray.Count(); index++)
            {
                char currentChar = asArray[index];
                bool isLetter = char.IsLetter(currentChar);
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

            //Have a behaviour type - "G"(good) or "N"(naughty) and must be surrounded by "!"(exclamation mark).
            var desiredSubstringAsList = "!G!".Select(x => x + decrypt).Select(x => (char)x).ToList();
            string desiredString = string.Join("", desiredSubstringAsList);

            bool isGoodAndValid = input.Contains(desiredString);
            if (isGoodAndValid)
            {
                //They can be separated from the others by any character except: '@', '-', '!', ':' and '>'.
                int indexOfDesiredString = input.IndexOf(desiredString);

                var listOfInvalidSeparators = new List<char>() { '@', '-', '!', ':', '>' };

                int separatorStart = indexOfStart + name.Length;
                int separatorLength = indexOfDesiredString - separatorStart;

                if (separatorLength <= 0) //The order in the message should be: child’s name -> child’s behavior
                {
                    input = Console.ReadLine();
                    continue;
                }
                var separatorRange = asArray.GetRange(separatorStart, separatorLength).ToList(); // get everything between name and behavious

                bool isValid = true;
                foreach (var separator in listOfInvalidSeparators) // check if any invalid separator is contained in the range
                {
                    bool invalidSeparator = separatorRange.Contains(separator);
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