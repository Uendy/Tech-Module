using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Your task is to parse the IP and the username from the input and for every user,
        //you have to display every IP from which the corresponding user has sent a message and the count of the messages sent with the corresponding IP.
        //In the output, the usernames must be sorted alphabetically while their IP addresses should be displayed in the order of their first appearance.
        //output should be in the following format:

        //username:IP => count, IP => count.
        //For example, given the following input:
        //•	“IP = 192.23.30.40 message = 'Hello&derps.' user = destroyer”,
        //You will have to get the username destroyer and the IP 192.23.30.40 and display it in the following format:
        //    destroyer: 192.23.30.40 => 1.
        //The username destroyer has sent a message from IP 192.23.30.40 once.
        //Check the examples below. They will further clarify the assignment.

        var usersAndIPS = new SortedDictionary<string, List<string>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                break;
            }

            var inputTokens = input.Split(' ', '=').ToArray();
            string user = inputTokens.Last();
            string IPAdress = inputTokens[1];

            bool newUser = !usersAndIPS.ContainsKey(user);
            if (newUser == true)
            {
                usersAndIPS[user] = new List<string>();
                usersAndIPS[user].Add(IPAdress);
            }
            else
            {
                usersAndIPS[user].Add(IPAdress);
            }
        }

        foreach (var user in usersAndIPS.Keys)
        {
            Console.WriteLine($"{user}: ");
            var temporaryDict = new Dictionary<string, int>();
            foreach (var iPAdress in usersAndIPS[user]) // to put them in dict to count their occurances
            {
                bool alreadyContained = temporaryDict.ContainsKey(iPAdress);
                if (alreadyContained == false) // new key
                {
                    temporaryDict[iPAdress] = 1;
                }
                else
                {
                    temporaryDict[iPAdress]++;
                }
            }

            foreach (var address in temporaryDict.Keys) // to print out adress => occurances
            {
                bool lastAddress = address == temporaryDict.Keys.Last();
                if (!lastAddress)
                {
                    Console.Write($"{address} => {temporaryDict[address]}, ");
                }
                else
                {
                    Console.WriteLine($"{address} => {temporaryDict[address]}.");
                }
            }
        }
    }
}