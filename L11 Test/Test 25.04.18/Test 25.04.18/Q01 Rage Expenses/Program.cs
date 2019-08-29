using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        //link to check questions: https://judge.softuni.bg/Contests/Practice/Index/996#0

        #region
        //Problem 1 – Rage Expenses
        //As a MOBA challenger player, Pesho has the bad habit to trash his PC when he loses a game and rage quits.
        //His gaming setup consists of headset, mouse, keyboard and display. You will receive Pesho`s lost games count. 

        //Every second lost game, Pesho trashes his headset.
        //Every third lost game, Pesho trashes his mouse.
        //When Pesho trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
        //Every second time, when he trashes his keyboard, he also trashes his display.
        //You will receive the price of each item in his gaming setup.
        //Calculate his rage expenses for renewing his gaming equipment.

        //Input / Constraints
        //•	On the first input line - lost games count – integer in the range[0, 1000].
        //•	On the second line – headset price - floating point number in range[0, 1000].
        //•	On the third line – mouse price - floating point number in range[0, 1000].
        //•	On the fourth line – keyboard price - floating point number in range[0, 1000].
        //•	On the fifth line – display price - floating point number in range[0, 1000].

        //Output
        //•	As output you must print Pesho`s total expenses: "Rage expenses: {expenses} lv."
        #endregion

        int lostGames = int.Parse(Console.ReadLine());
        float headsetCost = float.Parse(Console.ReadLine());
        float mouseCost = float.Parse(Console.ReadLine());
        float keyboardCost = float.Parse(Console.ReadLine());
        float displayCost = float.Parse(Console.ReadLine());

        float totalCost = 0;

        int trashedKeyboardTimes = 0;

        for (int i = 2; i <= lostGames; i++)
        {
            bool headsetTrashed = i % 2 == 0; // every second game -> headset
            if (headsetTrashed)
            {
                totalCost += headsetCost;
            }

            bool mouseTrashed = i % 3 == 0; // every third game -> mouse
            if (mouseTrashed)
            {
                totalCost += mouseCost;
            }

            bool keyboardTrashed = headsetTrashed && mouseTrashed; // both headset & mouse -> keyboard
            if (keyboardTrashed)
            {
                totalCost += keyboardCost;
                trashedKeyboardTimes++;
            }

            bool display = keyboardTrashed && trashedKeyboardTimes == 2; // every 2nd time the keyboard is trashed -> display
            if (display)
            {
                totalCost += displayCost;
                trashedKeyboardTimes = 0;
            }
        }

        Console.WriteLine($"Rage expenses: {totalCost:f2} lv.");
    }
}