using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Parking_Valid
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            var dictOfLicences = new Dictionary<string, string>();

            for (int index = 0; index < numberOfInputs; index++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                switch (input[0])
                {
                    case "register":
                        string userName = input[1];
                        string licensePlate = input[2];
                        bool invalidLicence = false;

                        // test 1: if it is exactly 8 char long
                        bool exactlyEightCharLong = licensePlate.Length == 8;
                        if (exactlyEightCharLong == false)
                        {
                            invalidLicence = true;
                        }


                        // test 2: if the first and last two chars are capital latin letters
                        var arrayOfPlate = licensePlate.ToArray();
                        var testing = arrayOfPlate.Take(2).ToList();
                        var lastCharTest = arrayOfPlate.Reverse().Take(2).ToList();
                        testing = testing.Concat(lastCharTest).ToList();
                        
                        foreach (var charecter in testing)
                        {
                            bool capitalLatinLetter = charecter >= 65 && charecter <= 90;
                            if (capitalLatinLetter == false)
                            {
                                invalidLicence = true;
                            }
                        }

                        // test 3: if the middle 4 chars are numbers
                        var testOfMiddleChars = arrayOfPlate
                            .Skip(2)
                            .Take(4);
                        foreach (var number in testOfMiddleChars)
                        {
                            bool aNumber = number >= 48 && number <= 57;
                            if (aNumber == false)
                            {
                                invalidLicence = true;
                            }
                        }


                        // see which route to take 
                        if (invalidLicence == true)
                        {
                            // the next 5 lines were just because I screwed the order of the checks
                            bool alreadyContainsKey = dictOfLicences.ContainsKey(userName);
                            if (alreadyContainsKey == true)
                            {
                                Console.WriteLine($"ERROR: already registered with plate number {dictOfLicences[userName]}");
                                continue;
                            }

                            Console.WriteLine($"ERROR: invalid license plate {licensePlate}");
                        }
                        else
                        {
                            bool alreadyContainsKey = dictOfLicences.ContainsKey(userName); // more than one car
                            bool alreadyContainsValue = dictOfLicences.ContainsValue(licensePlate); // car already registered
                            if (alreadyContainsKey == true)
                            {
                                Console.WriteLine($"ERROR: already registered with plate number {dictOfLicences[userName]}");
                            }
                            else if (alreadyContainsValue == true)
                            {
                                Console.WriteLine($"ERROR: license plate {licensePlate} is busy");
                            }
                            else // both are right 
                            {
                                dictOfLicences[userName] = licensePlate;
                                Console.WriteLine($"{userName} registered {licensePlate} successfully");
                            }
                        }
                        break;

                    case "unregister":

                        userName = input[1];
                        
                        bool alreadyInTheSystem = dictOfLicences.ContainsKey(userName);
                        if (alreadyInTheSystem == false)
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else // in database
                        {
                            dictOfLicences.Remove(userName);
                            Console.WriteLine($"user {userName} unregistered successfully");
                        }
                        break;
                }

            }
            foreach (var item in dictOfLicences.Keys)
            {
                Console.WriteLine($"{item} => {dictOfLicences[item]}");
            }
        }
    }
}
