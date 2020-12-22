using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: 
        // Admit it – the СРЪБСКО is your favorite sort of music.You never miss a concert and you have become quite the geek concerning everything involved with СРЪБСКО.You can’t decide between all the singers you know who your favorite one is.One way to find out is to keep statistics of how much money their concerts make. Write a program that does all the boring calculations for you.
        // On each input line you’ll be given data in format: "singer @venue ticketsPrice ticketsCount".There will be no redundant whitespaces anywhere in the input.Aggregate the data by venue and by singer.For each venue, print the singer and the total amount of money his / her concerts have made on a separate line.Venues should be kept in the same order they were entered; the singers should be sorted by how much money they have made in descending order. If two singers have made the same amount of money, keep them in the order in which they were entered. 
        // Keep in mind that if a line is in incorrect format, it should be skipped and its data should not be added to the output.Each of the four tokens must be separated by a space, everything else is invalid.The venue should be denoted with @ in front of it, such as @Sunny Beach
        // SKIP THOSE: Ceca @Belgrade125 12378, Ceca @Belgrade12312 123
        // The singer and town name may consist of one to three words. 

        // Input:
        // •	The input data should be read from the console.
        // •	It consists of a variable number of lines and ends when the command “End" is received.
        // •	The input data will always be valid and in the format described.There is no need to check it explicitly.

        // Output:
        // •	The output should be printed on the console.
        // •	Print the aggregated data for each venue and singer in the format shown below.
        // •	Format for singer lines is #{2*space}{singer}{space}->{space}{total money}

        // Example: 
        // Input                                                Output:
        // Lepa Brena @Sunny Beach 25 3500                      Sunny Beach
        // Dragana @Sunny Beach 23 3500                         #  Saban Saolic -> 4200000
        // Ceca @Sunny Beach 28 3500                            #  Ceca -> 1270500
        // Mile Kitic @Sunny Beach 21 3500                      #  Lepa Brena -> 87500
        // Ceca @Sunny Beach 35 3500                            #  Dragana -> 80500
        // Ceca @Sunny Beach 70 15000                           #  Mile Kitic -> 73500
        // Saban Saolic @Sunny Beach 120 35000
        // End

        #endregion
    }
}