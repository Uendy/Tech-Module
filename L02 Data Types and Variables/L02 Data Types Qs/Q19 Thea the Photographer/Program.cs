using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q19_Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long totalPictures = long.Parse(Console.ReadLine());
            int singlePictureFilter = int.Parse(Console.ReadLine());
            sbyte percentageOfGoodPics = sbyte.Parse(Console.ReadLine());
            long singleUploadTimeForPics = long.Parse(Console.ReadLine());

            long totalTime = totalPictures * singlePictureFilter;

            double leftoverPics = Math.Ceiling((double)totalPictures * ((double)percentageOfGoodPics/100));

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

            //Console.WriteLine("{0}:{1:d2}:{2:d2}:{3:d2}", days, hours, minutes, seconds);
            Console.WriteLine($"{days}:{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
