using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //You will be given a key string and a text string. The key string will contain a start key and an end key.

        //The start key starts at the beginning of the string and ends at the first occurrence of one of the symbols – “|”, “<” or “\”.
        //The end key starts at the last occurrence of one of these symbols and ends when the string ends. Both keys can contain only Latin alphabet letters.

        //When you extract both keys search for them in the text string and extract every string, which is between them. 
        //Concatenate all collected strings and print the result.If the result string is empty print “Empty result”.

        string key = Console.ReadLine(); // why havent I used the key?
        string text = Console.ReadLine();

        string patern = $@"^([a-zA-Z]+)[\|\<\\](.+)[\|\<\\]([a-zA-Z]+)$";
        Regex regex = new Regex(patern);

        Match match = regex.Match(key);
        string start = match.Groups[1].Value;
        string end = match.Groups[3].Value;

        string wordPattern = $@"{start}(?!{end})(.*?){end}";
        MatchCollection matchCollection = Regex.Matches(text, wordPattern);

        if (matchCollection.Count > 0)
        {
            foreach (Match item in matchCollection)
            {
                Console.Write(item.Groups[1].Value);
            }
            Console.WriteLine();
        }
    }
}