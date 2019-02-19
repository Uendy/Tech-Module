using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Q10_Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;

            double days = Math.Floor((years * 365.2422));

            long hours = (long)days * 24;

            long minutes = hours * 60;

            long seconds = minutes * 60;

            long milliSeconds = seconds * 1000;

            long microSeconds = milliSeconds * 1000;

            BigInteger nanoSeconds = (BigInteger)microSeconds * 1000;

            
            
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = " +
                $"{seconds} seconds = {milliSeconds} milliseconds = {microSeconds} microseconds = {nanoSeconds} nanoseconds");
        }
    }
}
