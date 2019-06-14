using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace SP_Friends
{
    public class Program
    {
        public static void Main()
        {
            //To help you stay in touch with the people that matter - FriendsList
            //this is a program to keep track of how long it has been since you talked to a friend

            var fileName = "friendsAndDates.txt";

            var fileContents = File.ReadAllLines(fileName);

            var listOfFriends = FileToList(fileContents);
            PrintFeed(listOfFriends);

            Console.WriteLine("Add a new friend? => input = \"Add\"");
            Console.WriteLine("Update an existing friends last conversation date => input = \"Update\"");

            string input = Console.ReadLine();

            if (input == "Add")
            {
                listOfFriends.Add(AddNewFriend());
            }
            else if (input == "Update")
            {
                // change 
            }
            //else


            ////To DO:
            //check who is most critical to talk to and order them on top
            //update someones last convo date
            // Return all the updated data into the text file
            // the actual calendar that keeps ticking 

            Console.ReadKey();
        }

        ////unpack all friend info from text file to list
        public static List<Friend> FileToList(string[] fileContents) 
        {
            var listOfFriends = new List<Friend>();

            foreach (var line in fileContents)
            {
                var lineTokens = line.Split(' ');
                var currentFriend = new Friend()
                {
                    Name = lineTokens[0],
                    LastTalk = DateTime.ParseExact(lineTokens[1], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    TalkFrequency = TimeSpan.FromDays(double.Parse(lineTokens[2])),
                };

                listOfFriends.Add(currentFriend);
            }

            return listOfFriends;
        }

        public static void PrintFeed(List<Friend> listOfFriends)
        {
            var listOfCriticalFriends = new List<Friend>();
            var listOfFineFriends = new List<Friend>();

            foreach (var friend in listOfFriends)
            {
                friend.DaysUntilTalk = DateTime.Today.Subtract(friend.LastTalk);

                friend.NeedToTalk = friend.DaysUntilTalk >= friend.TalkFrequency;

                if (friend.NeedToTalk == true)
                {
                    listOfCriticalFriends.Add(friend);
                }
                else
                {
                    listOfFineFriends.Add(friend);
                }
            }

            //printing the critical friends
            listOfCriticalFriends = listOfCriticalFriends.OrderByDescending(f => f.DaysUntilTalk).ToList();
            Console.WriteLine("Friends you haven't caught up with:");
            foreach (var friend in listOfCriticalFriends)
            {
                Console.WriteLine($"{friend.Name} is {friend.DaysUntilTalk.TotalDays} days overdue," +
                    $" haven't talked since {friend.LastTalk.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}");
            }
            Console.WriteLine(new string('-', 60));

            //printing the not critical friends

        }

        public static Friend AddNewFriend()
        {
            var newFriend = new Friend();

            // get friends name
            Console.Write("Please input your friend's name: ");
            string newFriendName = Console.ReadLine().Trim();

            //get last convo date + catch any bugs
            Console.Write("Input date of last conversation (format dd-MM-yyyy): ");
            string lastConversationDate = Console.ReadLine();

            var lastConvo = new DateTime();
            bool succesfullyParsedDate = DateTime.TryParse(lastConversationDate, out lastConvo);
            while (succesfullyParsedDate != true)
            {
                Console.WriteLine("Invalid Date!");
                Console.Write("Input last conversationd date again: ");
                lastConversationDate = Console.ReadLine();
                succesfullyParsedDate = DateTime.TryParse(lastConversationDate, out lastConvo);
            }

            //get desired frequency of reminders + catch any bugs
            Console.Write("Input how often you would like to talk (in days): ");
            string daysInBetweenString = Console.ReadLine();
            bool successfullyParse = int.TryParse(daysInBetweenString, out int daysInBetween);
            while (successfullyParse != true || daysInBetween <= 0)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Please input a valid number: ");
                daysInBetweenString = Console.ReadLine();
                succesfullyParsedDate = int.TryParse(daysInBetweenString, out daysInBetween);
            }


            newFriend.Name = newFriendName;
            newFriend.LastTalk = lastConvo;
            newFriend.TalkFrequency = TimeSpan.FromDays(daysInBetween);

            return newFriend;
        }
    }
}
