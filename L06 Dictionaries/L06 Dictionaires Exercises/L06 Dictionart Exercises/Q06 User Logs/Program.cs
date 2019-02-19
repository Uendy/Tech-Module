using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabetSortedDictionary = new SortedDictionary<string, List<string>>(); // userName = key IP, address(s) = value;
            
            var logCountDictionary = new SortedDictionary<string, int>(); // IP address= Key,  value = counter of log ins

            var input = Console.ReadLine().Split(' ', '=').ToList();
            while (input[0] != "end")
            {
                string userName = input[input.Count-1]; // the last bit of input
                string addressIP = input[1];

                bool containsKeyUserName = alphabetSortedDictionary.ContainsKey(userName);
                bool containedKeyIP = logCountDictionary.ContainsKey(addressIP);

                if (containsKeyUserName == true)
                {
                    if (containedKeyIP == true)
                    {
                        logCountDictionary[addressIP]++;
                    }
                    else
                    {
                        alphabetSortedDictionary[userName].Add(addressIP); 
                        logCountDictionary[addressIP] = 1;
                    }
                }
                else
                {
                    alphabetSortedDictionary[userName] = new List<string>(); // very important or you cant use list
                    alphabetSortedDictionary[userName].Add(addressIP); 

                    logCountDictionary[addressIP] = 1;
                }

                input = Console.ReadLine().Split(' ', '=').ToList();
            }

            foreach (var item in alphabetSortedDictionary)
            {
                Console.WriteLine($"{item.Key}: ");
                int counterForIndex = 0;
                foreach (var IPAddress in item.Value)
                {
                    int lastIpAddress = item.Value.Count - 1;
                    if (counterForIndex == lastIpAddress)
                    {
                        Console.Write($"{item.Value[counterForIndex]} => {logCountDictionary[IPAddress]}.\n");
                    }
                    else
                    {
                        Console.Write($"{item.Value[counterForIndex]} => {logCountDictionary[IPAddress]}, ");
                    }
                    counterForIndex++;
                }
            }
        }
    }
}
