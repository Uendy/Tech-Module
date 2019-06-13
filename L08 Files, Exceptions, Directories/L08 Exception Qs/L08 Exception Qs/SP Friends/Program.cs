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

            //unpack all friend info from text file to list

            var listOfFriends = new List<Friend>();
            foreach (var line in fileContents)
            {
                var lineTokens = line.Split(' ');
                var currentFriend = new Friend()
                {
                    Name = lineTokens[0],
                    LastTalk = DateTime.ParseExact(lineTokens[1], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    TalkFrequency = int.Parse(lineTokens[2])
                };

                listOfFriends.Add(currentFriend);
            }

            Console.WriteLine("Add a new friend? => input = \"Add\"");
            Console.WriteLine("Update an existing friends last conversation date => input = \"Update\"");

            string input = Console.ReadLine();

            if (input == "Add")
            {
                listOfFriends.Add(AddNewFriend());
            }
            else if (input == "Update")
            {

            }
            //else
            //{

            //}
            //To DO:
            //check who is most critical to talk to and order them on top
            //update someones last convo date
            // Return all the updated data into the text file

            Console.ReadKey();
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

            Console.WriteLine("Input how often you would like to talk (in days): ");
            int daysInBetween = 0;
            try
            {
                daysInBetween = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Please input a valid number: ");
                daysInBetween = int.Parse(Console.ReadLine());
            }


            newFriend.Name = newFriendName;
            newFriend.LastTalk = lastConvo;
            newFriend.TalkFrequency = daysInBetween;

            return newFriend;
        }
    }
}
