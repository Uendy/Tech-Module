using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //You are given a sequence of access logs in format <IP> <user> <duration>. For example:
        //•	192.168.0.11 peter 33
        //•	10.10.17.33 alex 12
        //•	10.10.17.35 peter 30
        //•	10.10.17.34 peter 120
        //•	10.10.17.34 peter 120
        //•	212.50.118.81 alex 46
        //•	212.50.118.81 alex 4

        // Write a program to aggregate the logs data and print for each user the total duration of his sessions
        //and a list of unique IP addresses in format "<user>: <duration> [<IP1>, <IP2>, …]".
        //Order the users alphabetically.
        //Order the IPs alphabetically.In our example, the output should be the following:
        //•	alex: 62[10.10.17.33, 212.50.118.81]
        //•	peter: 303[10.10.17.34, 10.10.17.35, 192.168.0.11]
        var listOfUsers = new List<string>();
        var usersAndIps = new SortedDictionary<string, List<string>>();
        var usersAndTotal = new Dictionary<string, int>();

        int numberOfInputs = int.Parse(Console.ReadLine());
        for (int index = 0; index < numberOfInputs; index++)
        {
            var inputTokens = Console.ReadLine().Split(' ').ToArray();
            string iPAdrress = inputTokens[0];
            string user = inputTokens[1];
            int value = int.Parse(inputTokens[2]);

            bool newUser = !listOfUsers.Contains(user);
            if (newUser)
            {
                listOfUsers.Add(user);
                usersAndIps[user] = new List<string>();
                usersAndIps[user].Add(iPAdrress);
                usersAndTotal[user] = value;
            }
            else
            {
                usersAndIps[user].Add(iPAdrress);
                usersAndTotal[user] += value;
            }
        }

        foreach (var user in listOfUsers) // removing repeat string adressess and order values
        {
            usersAndIps[user] = usersAndIps[user].Distinct().OrderBy(x => x).ToList();
        }
        
        foreach (var item in usersAndIps.Keys)
        {
            string outPut = string.Join(", ", usersAndIps[item]);
            Console.WriteLine($"{item}: {usersAndTotal[item]} [{outPut}]");
        }
    }
}