using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //Create a program, that finds all of the emojis in a given message and makes some calculations.
        //You will receive a few lines of input. On the first line, you will receive a single line of text (ASCII symbols).

        //On the next line, you will receive an emoji code in the following format:
        //“number: number: number: (…)”
        //Each number is the value of an ASCII symbol and if you decrypt all of the symbols, you will receive a name of an emoji.

        //An emoji is valid when:
        //-It is surrounded by colons and consists of at least 4 lowercase letters from the English alphabet.
        //- Before the emoji there is a white space and after it there is a white space or any of the following punctuation marks: ‘,’, ‘.’, ‘!’, ‘?’. 
        //Example for valid emojis: 
        //I hope you have a :sunny: day :smiley: :smiley:.

        //You must find all of the emojis and after that, calculate their total power.It is calculated by summing the ASCII value of all letters between the colons.
        //Check if any of the valid emoji names is equal to the name received form the emoji code and if it is – multiply the total emoji power by 2.
        //In the end print on the console all valid emojis, separated by а comma and a white space in order of finding and the total emoji power, each on a separate line.
        //Example:
        //Emojis found: :sunny:, :smiley:, :smiley:
        //Total Emoji Power: { sum}
        #endregion

        string text = Console.ReadLine();

        //to find the special emoji
        var emojiArray = Console.ReadLine().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var sb = new StringBuilder();
        foreach (var character in emojiArray)
        {
            char currentChar = (char)character;
            sb.Append(currentChar);
        }

        var specialEmoji = sb.ToString();

        //get the regex right and find any matches
        string pattern = @"\s:[a-z]{4,}:(\s|\,|\.|\!|\?)";
        var regex = new Regex(pattern);
        var matches = regex.Matches(text);

        var listOfExtendedEmojis = new List<string>(); //containing any the symbols around the 4+ smaller letters
        var listOfReducedEmojis = new List<string>(); // containing only the 4+ letters
        var sum = 0;
        var emojiPattern = @"[a-z]{4,}"; //[a-z]{4,}
        var emojiRegex = new Regex(emojiPattern);

        foreach (Match match in matches)
        {
            var matchAsString = match.ToString();
            listOfExtendedEmojis.Add(matchAsString);

            var emojiOnly = emojiRegex.Match(matchAsString); // removes anything but the letters we need to calculate sum
            var emoji = emojiOnly.ToString();

            listOfExtendedEmojis.Add(emoji);

            int currentSum = 0; //getting the ASCII value of the emoji
            var emojiCharArray = emoji.ToCharArray();
            foreach (var character in emojiCharArray)
            {
                var asciiValue = (int)character;
                currentSum += asciiValue;
            }

            sum += currentSum;
        }

        //printing 
        string emojiOutput = string.Join(",", listOfExtendedEmojis);
        Console.WriteLine($"Emojis found: {emojiOutput}");

        bool isSpecial = listOfExtendedEmojis.Contains(specialEmoji); //If any of the valid emoji names is equal to the special emoji code and if it is – multiply the total emoji power by 2
        if (isSpecial)
        {
            sum *= 2;
        }
        Console.WriteLine($"Total Emoji Power: {sum}");
    }
}