using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a text, split it into words and distribute them into 3 lists.
        //	Lower -case words like “programming”, “at” and “databases” – consist of lowercase letters only.
        //	Upper -case words like “PHP”, “JS” and “SQL” – consist of uppercase letters only.
        //	Mixed -case words like “C#”, “SoftUni” and “Java” – all others.
        //Use the following separators between the words: , ; : . !( ) " ' \ / [ ] space

        var array = Console.ReadLine()
            .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var lowerCaseList = new List<string>();
        var upperCaseList = new List<string>();
        var mixedCaseList = new List<string>();

        foreach (var section in array)
        {
            bool lowerCase = false;
            bool upperCase = false;

            var secToCharArr = section.ToCharArray();
            foreach (var charecter in secToCharArr)
            {
                if (charecter >= 97 && charecter <= 122)
                {
                    lowerCase = true;
                }
                else if (charecter >= 65 && charecter <= 90)
                {
                    upperCase = true;
                }
                else
                {
                    upperCase = true;
                    lowerCase = true;
                    break;
                }

            }

            if (lowerCase == true && upperCase == true)
            {
                mixedCaseList.Add(section);
            }
            else if (lowerCase == true)
            {
                lowerCaseList.Add(section);
            }
            else if (upperCase == true)
            {
                upperCaseList.Add(section);
            }
        }

        string lowerCaseOutput = string.Join(", ", lowerCaseList);
        Console.WriteLine($"Lower-case: {lowerCaseOutput}");
        
        string middleCaseOutput = string.Join(", ", mixedCaseList);
        Console.WriteLine($"Mixed-case: {middleCaseOutput}");

        string upperCaseOutput = string.Join(", ", upperCaseList);
        Console.WriteLine($"Upper-case: {upperCaseOutput}");
    }
}