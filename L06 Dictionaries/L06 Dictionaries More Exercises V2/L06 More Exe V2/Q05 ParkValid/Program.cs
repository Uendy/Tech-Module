using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //SoftUni just got a huge, shiny new parking lot in a super-secret location (under the Code Ground hall).
        //It’s so fancy, it even has online parking validation. Except, the online service doesn’t work.
        //It can only receive users’ data, but doesn’t know what to do with it.
        //Good thing you’re on the dev team and know how to fix it, right?
        //Write a program, which validates parking for an online service.Users can register to park and unregister to leave.

        //The system supports license plate validation.A valid license plate has the following 3 distinct characteristics: 
        //•	It is always exactly 8 characters long.
        //•Its first 2 and last 2 characters are always uppercase Latin letters
        //•	The 4 characters in the middle are always digits
        //If any of the aforementioned conditions fails, the license plate is invalid.

        //The program receives 2 commands:

        //•	“register { username} { licensePlateNumber}”: The system only supports one car per user at the moment,
        //so if a user tries to register another license plate, using the same username, the system should print:
        //“ERROR: already registered with plate number { licensePlateNumber}”
        ////o If the license plate is invalid, the system should print:
        //“ERROR: invalid license plate { licensePlateNumber}“
        ////o If the user tries to register someone else’s license plate, the system should print:
        //“ERROR: license plate { licensePlateNumber} is busy”
        ////o If the aforementioned checks pass successfully, the plate can be registered, so the system should print:
        //“{ username} registered { licensePlateNumber} successfully”

        //•	“unregister { username}”:
        //o If the user is not present in the database, the system should print:
        ////“ERROR: user { username} not found”
        //o If the aforementioned check passes successfully, the system should print:
        //“user { username}unregistered successfully”

        //After you execute all of the commands, print all the currently registered users and their license plates in the format:
        //•	“{ username} => { licensePlateNumber}”

        var driversAndLicense = new Dictionary<string, string>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfInputs; i++)
        {
            var commandTokens = Console.ReadLine().Split(' ').ToList();

            string command = commandTokens[0];
            string userName = commandTokens[1];

            if (command == "register")
            {
                if (driversAndLicense.ContainsKey(userName))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {driversAndLicense[userName]}");
                    continue;
                }

                string license = commandTokens[2];
                bool exactLength = license.Length == 8;

                var firstAndLastChars = license.Take(2).Concat(license.Reverse().Take(2)); //getting first 2 and last 2 chars
                bool allCapitalLetters = true;
                foreach (var letter in firstAndLastChars)
                {
                    if (!(letter >= 65 && letter <= 90))
                    {
                        allCapitalLetters = false;
                    }
                }

                string middleFour = license.Substring(2, 4);
                bool middleFourAreDigits = int.TryParse(middleFour, out int digits);

                if (exactLength && allCapitalLetters && middleFourAreDigits)
                {
                    bool newDriver = !driversAndLicense.ContainsKey(userName);
                    if (newDriver)
                    {
                        bool triesAnAlreadyRegisteredCar = driversAndLicense.ContainsValue(license);
                        if (triesAnAlreadyRegisteredCar)
                        {
                            Console.WriteLine($"ERROR: license plate {license} is busy");
                            continue;
                        }
                        else // all checks passed -> you can log the driver and car into the system
                        {
                            driversAndLicense[userName] = license;
                            Console.WriteLine($"{userName} registered {license} successfully");
                        }
                    }
                }
                else //invalid license
                {
                    Console.WriteLine($"ERROR: invalid license plate {license}");
                }
            }
            else //unregister
            {
                bool isUserRegistered = driversAndLicense.ContainsKey(userName);
                if (!isUserRegistered)
                {
                    Console.WriteLine($"ERROR: user {userName} not found");
                }
                else // found the user and removing him from database
                {
                    driversAndLicense.Remove(userName);
                    Console.WriteLine($"user {userName} unregistered successfully");
                }


            }

        }

        //printing all drivers and their license plates
        foreach (var driver in driversAndLicense.Keys)
        {
            Console.WriteLine($"{driver} => {driversAndLicense[driver]}");
        }

    }
}