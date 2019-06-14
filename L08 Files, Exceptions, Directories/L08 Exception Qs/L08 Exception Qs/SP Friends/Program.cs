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

            string input = Console.ReadLine().ToLower();

            if (input == "add")
            {
                listOfFriends.Add(AddNewFriend());
            }
            else if (input == "update")
            {
                UpdateFriend(listOfFriends);
            }
            //else


            ////To DO:
            // Return all the updated data into the text file
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

        ////Split and order friends to give a clear view of who needs to be contacted now and how can wait, then print
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
            listOfFineFriends = listOfFineFriends.OrderBy(f => f.DaysUntilTalk).ToList();
            Console.WriteLine("Upcoming friends you should talk to:");
            foreach (var friend in listOfFineFriends)
            {
                Console.WriteLine($"{friend.Name} is {friend.DaysUntilTalk.TotalDays} days away from desired correspondence");
            }
            Console.WriteLine(new string('-', 60));
        }

        //// Add new Friend to listOfFriends
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

            Console.Write($"Added new friend!");
            string outputInfo = $"{newFriend.Name}'s last conversation" +
                $" {newFriend.LastTalk.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}" +
                $" and desired talk frequency of {newFriend.TalkFrequency.Days} days.";
            Console.WriteLine(outputInfo);

            return newFriend;
        }

        //// input a friends name and change when your last talk was
        public static List<Friend> UpdateFriend(List<Friend> listOfFriends)
        {
            Console.Write("Which person would you like to update? ");
            string searchedFriend = Console.ReadLine();

            bool friendExists = listOfFriends.Any(f => f.Name == searchedFriend);
            while (!friendExists)
            {
                Console.WriteLine("Name not contained in list of friends!");
                Console.Write("Please input a correct name: ");
                searchedFriend = Console.ReadLine();
                friendExists = listOfFriends.Any(f => f.Name == searchedFriend);
            }

            var currentFriend = listOfFriends.Find(f => f.Name == searchedFriend);
            Console.WriteLine("Bastard found!");

            Console.Write("Input last conversation (in dd-MM-yyyy format please): ");
            string newLastConvo = Console.ReadLine();
            bool validDateTime = DateTime.TryParse(newLastConvo, out DateTime LastConvo);
            while (!validDateTime)
            {
                Console.WriteLine("Inputed date was invalid!");
                Console.Write("Please use correct format (dd-MM-yyyy): ");
                newLastConvo = Console.ReadLine();
                validDateTime = DateTime.TryParse(newLastConvo, out LastConvo);
            }

            currentFriend.LastTalk = LastConvo;
            Console.WriteLine($"Updated {currentFriend.Name}'s last conversation to" +
                $" {currentFriend.LastTalk.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}");

            return listOfFriends;
        }
    }
}
