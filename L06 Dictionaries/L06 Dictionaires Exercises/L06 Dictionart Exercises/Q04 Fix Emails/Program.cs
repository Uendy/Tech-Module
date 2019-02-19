using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailBook = new Dictionary<string, string>();

            for (int index = 0; index < int.MaxValue; index++)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    StopProtocalEngaged(emailBook);
                }

                string email = Console.ReadLine();

                emailBook[input] = email;
            }
        }

        static void StopProtocalEngaged(Dictionary<string, string> emailBook)
        {
            RemoveUndesiredEmails(emailBook);

            foreach (var item in emailBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Environment.Exit(0);
        }

        static void RemoveUndesiredEmails(Dictionary<string, string> emailBook)
        {
            //// gets rid of .uk, .us domained emails

            foreach (var item in emailBook.ToList())
            {
                var arrayOfChars = item.Value
                    .Reverse()
                    .Take(2)
                    .ToArray();

                bool rightDomain = arrayOfChars[0] == 'g' && arrayOfChars[1] == 'b';
                if (rightDomain == false)
                {
                    emailBook.Remove(item.Key);
                }
            }
        }
    }
}
