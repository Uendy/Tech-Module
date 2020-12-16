using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Marian is a famous system administrator. The person to overcome the security of his servers has not yet been born. However, there is a new type of threat where users flood the server with messages and are hard to be detected since they change their IP address all the time. Well, Marian is a system administrator and is not so into programming. Therefore, he needs a skillful programmer to track the user logs of his servers. You are the chosen one to help him!
        // You are given an input in the format:
        // •	IP = (IP.Address)message = (A & sample & message) user = (username)

        // Your task is to parse the IP and the username from the input and for every user, you have to display every IP from which the corresponding user has sent a message and the count of the messages sent with the corresponding IP.In the output, the usernames must be sorted alphabetically while their IP addresses should be displayed in the order of their first appearance. The output should be in the following format:
        // username: IP => count, IP => count.
        // For example, given the following input:
        // •	“IP = 192.23.30.40 message = 'Hello&derps.' user = destroyer”,
        // You will have to get the username destroyer and the IP 192.23.30.40 and display it in the following format:
        // destroyer : 192.23.30.40 => 1.
        // The username destroyer has sent a message from IP 192.23.30.40 once.
        // Check the examples below. They will further clarify the assignment.

        // Input
        // The input comes from the console as varying number of lines.You have to parse every command until the command that follows is end.The input will be in the format displayed above, there is no need to check it explicitly.

        // Output
        // For every user found, you have to display each log in the format:
        // username: IP => count, IP => count…
        // The IP addresses must be split with a comma, and each line of IP addresses must end with a dot.

        // Constraints
        //  •	The number of commands will be in the range[1..50]
        //  •	The IP addresses will be in the format of either IPv4 or IPv6.
        //  •	The messages will be in the format: This &is &a & message
        //  •	The username will be a string with length in the range[3..50]
        //  •	Time limit: 0.3 sec.Memory limit: 16 MB.

        // Example: 
        // IP=FE80:0000:0000:0000:0202:B3FF:FE1E:8329 message='Hey&son' user=mother             child0: 192.23.33.40 => 1.
        // IP = 192.23.33.40 message = 'Hi&mom!' user = child0                                  child1: 192.23.30.40 => 1.
        // IP = 192.23.30.40 message = 'Hi&from&me&too' user = child1                           destroyer: 192.23.30.42 => 2.
        // IP = 192.23.30.42 message = 'spam' user = destroyer                                  mother: FE80: 0000:0000:0000:0202:B3FF: FE1E: 8329 => 1.
        // IP = 192.23.30.42 message = 'spam' user = destroyer                                  unknown: 192.23.155.40 => 1.
        // IP = 192.23.50.40 message = '' user = yetAnotherUsername
        // IP = 192.23.50.40 message = 'comment' user = yetAnotherUsername
        // IP = 192.23.155.40 message = 'Hello.' user = unknown
        // end

        #endregion

        // Initializing dict, key = username, value = logs (Ip's)
        var usersAndLog = new SortedDictionary<string, List<string>>();

        // Reading input
        string input = Console.ReadLine();
        while (input!="end")
        {
            // Split the input and update dict
            var elements = input.Split(' ').ToList();

            string ip = elements.First().Split('=').Last();
            string user = elements.Last().Split('=').Last();

            bool newUser = !usersAndLog.ContainsKey(user);
            if (newUser)
            {
                usersAndLog[user] = new List<string>() { ip };
            }
            else
            {
                usersAndLog[user].Add(ip);
            }

            // Read next input
            input = Console.ReadLine();
        }

        // Print output
    }
}