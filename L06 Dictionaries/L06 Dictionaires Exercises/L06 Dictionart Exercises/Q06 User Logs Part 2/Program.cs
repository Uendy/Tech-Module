using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_User_Logs_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
