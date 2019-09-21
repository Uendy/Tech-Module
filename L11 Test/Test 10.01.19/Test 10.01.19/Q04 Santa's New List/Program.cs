using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Santa needs to start creating his new list for the next Christmas. Your job is to help him receive and keep the incoming information.
        //He will receive information about the names of the children, the type of present they want (toy, candy, clothing) and the wanted amount in the following format:
        //{ childName}->{ typeOfToy}->{ amount}

        //You can receive a command “Remove->{ childName}”.
        //In this case, you need to exclude the child from the new list with good children,
        //but don’t change the information about the type of present he or she wanted and the wanted amount.
        //Santa has already gotten the presents, so he might give them to another very good child.

        //When you receive the “END” command, you need to process it and print it, ordered descending by the total amount of presents for a child and then by their names.The format is given bellow. 

        var kidsAndPresents = new Dictionary<string, int>();
        var presentsAndAmounts = new Dictionary<string, int>();

        string input = Console.ReadLine();
        while (input != "END")
        {
            var inputTokens = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            bool removeCommand = input.Contains("Remove");
            if (removeCommand)
            {
                string name = inputTokens[1];

                bool childExists = kidsAndPresents.ContainsKey(name);
                if (childExists)
                {
                    kidsAndPresents.Remove(name);
                }

                input = Console.ReadLine();
                continue;
            }

            string child = inputTokens[0];
            string present = inputTokens[1];
            int amount = int.Parse(inputTokens[2]);

            bool newPresent = !presentsAndAmounts.ContainsKey(present);
            if (newPresent)
            {
                presentsAndAmounts[present] = 0;
            }
            presentsAndAmounts[present] += amount;

            bool newChild = !kidsAndPresents.ContainsKey(child);
            if (newChild)
            {
                kidsAndPresents[child] = 0;
            }
            kidsAndPresents[child] += amount;


            input = Console.ReadLine();
        }

        Console.WriteLine("Children:");
        foreach (var kid in kidsAndPresents.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) // see if correct sorting
        {
            Console.WriteLine($"{kid.Key} -> {kid.Value}");
        }

        Console.WriteLine("Presents:");
        foreach (var present in presentsAndAmounts)
        {
            Console.WriteLine($"{present.Key} -> {present.Value}");
        }
    }
}