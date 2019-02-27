using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //      Write a program that checks if a given password is valid. Password rules are:
        //•	6 – 10 characters(inclusive)
        //•	Consists only of letters and digits
        //•	Have at least 2 digits
        //      If a password is valid print “Password is valid”. 
        //      If it is not valid, for every unfulfilled rule print a message:
        //•	"Password must be between 6 and 10 characters"
        //•	"Password must consist only of letters and digits"
        //•	"Password must have at least 2 digits"

        string password = Console.ReadLine();

        PasswordValidator(password);
    }

    public static void PasswordValidator(string password)
    {
        bool correctSize = password.Length >= 6 && password.Length <= 10;

        bool minTwoDigits = true;
        bool onlyCorrectChars = true;

        var passAsCharArray = password.ToCharArray();
        int numberOfDigits = 0;

        foreach (var character in passAsCharArray)
        {
            int charAsInt = character;
            bool inCorrectRange = !((charAsInt >= 48 && charAsInt <= 57) || (charAsInt >= 65 && charAsInt <= 90) || (charAsInt >= 97 && charAsInt <= 122));


            if (charAsInt >= 48 && charAsInt <= 57)
            {
                numberOfDigits++;
            }

            if (inCorrectRange == true)
            {
                onlyCorrectChars = false;
            }
        }

        if (numberOfDigits < 2)
        {
            minTwoDigits = false;
        }


        if (correctSize == true && minTwoDigits == true && onlyCorrectChars == true)
        {
            Console.WriteLine("Password is valid");
        }
        else
        {
            if (correctSize == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (minTwoDigits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (onlyCorrectChars == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
        }
    }
}
