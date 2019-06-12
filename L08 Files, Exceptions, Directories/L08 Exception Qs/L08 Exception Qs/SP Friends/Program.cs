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

            Console.WriteLine("Would you like to add a new friend? => input = \"Add\"");
            Console.WriteLine("Would you like to update an existing friends last conversation date => input = \"Update\"");

            string input = Console.ReadLine();

            if (input == "Add")
            {
                Console.Write("Please input your friend's name: ");
                string newFriendName = Console.ReadLine();

                Console.Write("Input date of last conversation (format dd-MM-yyyy): ");
                string lastConversationDate = Console.ReadLine();

                Console.WriteLine("Input how often you would like to talk (in days): ");
                try
                {
                    int daysBetween = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                    Console.WriteLine("Please input a valid number: ");
                    int dateBetween = int.Parse(Console.ReadLine());
                }
            }
            else if (input == "Update")
            {

            }
            //else
            //{

            //}
            //To DO:
            //Add new friend
            //check who is most critical to talk to and order them on top
            //update someones last convo date

            // Return all the updated data into the text file

            Console.ReadKey();
        }
    }
}
