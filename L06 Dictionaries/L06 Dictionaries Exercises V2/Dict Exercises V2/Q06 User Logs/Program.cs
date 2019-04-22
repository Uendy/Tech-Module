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

    //    username:IP => count, IP => count.
    //For example, given the following input:
    //•	“IP = 192.23.30.40 message = 'Hello&derps.' user = destroyer”,
    //You will have to get the username destroyer and the IP 192.23.30.40 and display it in the following format:
    //    destroyer: 192.23.30.40 => 1.
    //The username destroyer has sent a message from IP 192.23.30.40 once.
    //Check the examples below. They will further clarify the assignment.

        SortedDictionary<string, Dictionary<string, int>> usersAndIps = new SortedDictionary<string, Dictionary<string, int>>();
        // key = string = userName, key = Dict <key (string) = IPAddress, value (int) = countOfUsages>

        var input = Console.ReadLine()
            .Split(' ', '=')
            .ToArray();

        while (input[0] != "end")
        {
            int lastItemOfInput = input.Count() - 1;
            var userName = input[lastItemOfInput];
            var IPAddress = input[1];

            bool containsKeyUserName = usersAndIps.ContainsKey(userName);
            //bool containsIPAddress = usersAndIps[userName].ContainsKey(IPAddress);

            if (containsKeyUserName == false)
            {
                usersAndIps.Add(userName, new Dictionary<string, int>());
                usersAndIps[userName].Add(IPAddress, 1);
            }
            else if (!usersAndIps[userName].ContainsKey(IPAddress))
            {
                usersAndIps[userName].Add(IPAddress, 1);
            }
            else
            {
                usersAndIps[userName][IPAddress] += 1;
            }

            input = Console.ReadLine()
                .Split(' ', '=')
                .ToArray();
        }

        foreach (var item in usersAndIps)
        {
            Console.WriteLine($"{item.Key}: ");
            int counterForIndex = 0;
            foreach (var IPAddress in item.Value)
            {
                int lastIpAddress = item.Value.Count - 1;
                if (counterForIndex == lastIpAddress)
                {
                    Console.Write($"{IPAddress.Key} => {IPAddress.Value}.\n");
                }
                else
                {
                    Console.Write($"{IPAddress.Key} => {IPAddress.Value}, ");
                }
                counterForIndex++;
            }
        }
    }
}