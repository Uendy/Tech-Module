using System;

class Program
{
    static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var pattern = Console.ReadLine();

        while (true)
        {
            var firstOccurance = text.IndexOf(pattern);
            var lastOccurance = text.LastIndexOf(pattern);

            bool contained = firstOccurance != -1 && lastOccurance != -1 && firstOccurance != lastOccurance && pattern.Length != 0;
            if (contained == true)
            {
                text = text.Remove(lastOccurance, pattern.Length);
                text = text.Remove(firstOccurance, pattern.Length);

                var removedIndex = pattern.Length / 2;
                pattern = pattern.Remove(removedIndex, 1);
                Console.WriteLine("Shaked it.");
            }
            else
            {
                EndingRemarks(text);
            }
        }
    }

    static void EndingRemarks(string text)
    {
        Console.WriteLine("No shake.");
        Console.WriteLine(text);
        Environment.Exit(0);
    }
}
