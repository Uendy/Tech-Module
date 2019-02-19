using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var bannedWords = Console.ReadLine();
        var listOfBannedWords = bannedWords.Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var dictOfBannedWords = new Dictionary<string, int>();
        foreach (var word in listOfBannedWords)
        {
            dictOfBannedWords[word] = word.Length;
        }


        var text = Console.ReadLine();

        foreach (var word in dictOfBannedWords.Keys)
        {
            var censor = new string('*', dictOfBannedWords[word]);
            text = text.Replace(word, censor.ToString());
        }

        Console.WriteLine(text);

    }
}
