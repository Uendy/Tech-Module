using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            var userLogs = new SortedDictionary<string, List<string>>();
            var dictOfLogs = new SortedDictionary<string, int>();

            for (int index = 0; index < numberOfInputs; index++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var iP = input[0];
                var userName = input[1];
                int timeLogged = int.Parse(input[2]);

                bool containsUserName = userLogs.ContainsKey(userName);
                if (containsUserName == true)
                {
                    bool containsIp = userLogs[userName].Contains(iP);
                    if (containsIp == false)
                    {
                        userLogs[userName].Add(iP);
                    }
                    dictOfLogs[userName] += timeLogged;
                }
                else
                {
                    userLogs[userName] = new List<string>();
                    userLogs[userName].Add(iP);
                    dictOfLogs[userName] = timeLogged;
                }
            }

            // order the ips which are the value in the list which is the value of the userLogs
            foreach (var name in userLogs.Keys)
            {
                Console.Write($"{name}: {dictOfLogs[name]} ");

                var listOfIps = new List<string>(userLogs[name]);
                listOfIps = listOfIps.Distinct().OrderBy(x => x).ToList(); // this was so hard to write

                string output = "[" + String.Join(", ", listOfIps) + "]"; // + mixed up String.Join with .Format and was like??
                Console.WriteLine(output);
            }
        }
    }
}
