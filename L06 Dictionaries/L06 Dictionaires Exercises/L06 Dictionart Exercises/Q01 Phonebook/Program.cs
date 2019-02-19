using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q01_Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            bool foundEnd = false;
            while (foundEnd == false)
            {
                var inputLine = Console.ReadLine().Split(' ').ToArray();

                if (inputLine[0] == "END")
                {
                    foundEnd = true;
                    Environment.Exit(0);
                    return;
                }
                else
                {
                    if (inputLine[0] == "A")
                    {
                            phoneBook[inputLine[1]] = inputLine[2];
                    }
                    else if (inputLine[0] == "S")
                    {
                        bool containsKey = phoneBook.ContainsKey(inputLine[1]);
                        if (containsKey == false)
                        {
                            Console.WriteLine($"Contact {inputLine[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{inputLine[1]} -> {phoneBook[inputLine[1]]}");
                        }
                    }
                }
            }
        }
    }
}
