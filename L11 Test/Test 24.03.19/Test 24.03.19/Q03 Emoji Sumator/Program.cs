using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
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

    }
}