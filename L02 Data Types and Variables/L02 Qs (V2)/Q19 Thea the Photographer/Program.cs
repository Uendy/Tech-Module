using System;

public class Program
{
    public static void Main()
    {
        //On the first line you will receive an integer N – the amount of pictures Thea had taken.
        //On the second line you will receive an integer FT – the amount of time(filter time) in seconds that Thea will require to filter every single picture.
        //On the third line you will receive an integer FF – the filter factor or the percentage of the total pictures that are considered “good” to be uploaded.
        //On the fourth line you will receive an integer UT – the amount of time needed for every filtered picture to be uploaded to her storage.

        long totalPictures = long.Parse(Console.ReadLine());
        int singlePictureFilter = int.Parse(Console.ReadLine());
        sbyte percentageOfGoodPics = sbyte.Parse(Console.ReadLine());
        long singleUploadTimeForPics = long.Parse(Console.ReadLine());

        long totalTime = totalPictures * singlePictureFilter;

        double leftoverPics = Math.Ceiling((double)totalPictures * ((double)percentageOfGoodPics / 100));

        totalTime += (long)leftoverPics * singleUploadTimeForPics;

        long daysInSeconds = 60 * 60 * 24; //84000
        long days = totalTime / daysInSeconds;
        if (days >= 1)
        {
            totalTime -= daysInSeconds * days;
        }

        long hoursInSeconds = 60 * 60; //3600
        long hours = totalTime / hoursInSeconds;
        if (hours >= 1)
        {
            totalTime -= hoursInSeconds * hours;
        }

        long minutesInSeconds = 60;
        long minutes = totalTime / minutesInSeconds;
        if (minutes >= 1)
        {
            totalTime -= minutesInSeconds * minutes;
        }

        long seconds = totalTime; // or just put totaltime as {3} instead of seconds

        Console.WriteLine($"{days}:{hours:D2}:{minutes:D2}:{seconds:D2}");

    }
}
