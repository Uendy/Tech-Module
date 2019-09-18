using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Your task is to implement chat logger which works with commands.
        //You may receive the following commands:
        //•	Chat { message} -add the message at last position in the chat
        //•	Delete { messageToDelete}-delete the message if it exists
        //•	Edit { messageToEdit}{ editedVersion} -update the message with the edited version
        //•	Pin { message}-find the given message and move it to the last index
        //•	Spam { message1}{ message2}{ messageN} -add all messages at the end of the chat
        //•	end - stop receiving commands
        //After the stop command, you should print the chat history starting from the first message.

        var messages = new List<string>();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(' ').ToArray();

            string command = inputTokens[0];

            switch (command)
            {
                case "Chat":
                    messages.Add(inputTokens[1]);
                    break;

                case "Delete":
                    string message = inputTokens[1];
                    messages = DeleteMessage(messages, message);
                    break;

                case "Edit":
                    messages = EditMessages(messages, inputTokens);
                    break;

                case "Pin":
                    string currentMessage = inputTokens[1];
                    messages = PinMessage(messages, currentMessage);
                    break;

                case "Spam":
                    messages = SpamMessages(messages, inputTokens);
                    break;

                default:
                    break;
            }

            input = Console.ReadLine();
        }

        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }
    }

    public static List<string> SpamMessages(List<string> messages, string[] inputTokens)
    {
        var spam = inputTokens.Skip(1).ToList();
        messages.AddRange(spam);

        return messages;
    }

    public static List<string> PinMessage(List<string> messages, string currentMessage)
    {
        bool exists = messages.Contains(currentMessage);
        if (exists)
        {
            messages.Remove(currentMessage);
            messages.Add(currentMessage);
        }

        return messages;
    }

    public static List<string> EditMessages(List<string> messages, string[] inputTokens)
    {
        string oldMessage = inputTokens[1];
        string newMessage = inputTokens[2];

        bool exists = messages.Contains(oldMessage);
        if (exists)
        {
            int indexOfOld = messages.IndexOf(oldMessage);
            messages[indexOfOld] = newMessage;
        }

        return messages;
    }

    public static List<string> DeleteMessage(List<string> messages, string message)
    {
        bool exists = messages.Contains(message);
        if (exists)
        {
            messages.Remove(message);
        }

        return messages;
    }
}