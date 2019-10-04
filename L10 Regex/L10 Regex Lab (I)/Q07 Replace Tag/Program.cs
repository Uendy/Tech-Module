using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static string Main()
    {
        //Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> with corresponding tags [URL href=…>…[/URL].
        //Read an input, until you receive “end” command. Print the result on the console. 

        //ex input: <ul> <li> <a href="http://softuni.bg">SoftUni</a>    
        //</ li > </ ul >
        //end

        //ex output: 
        //<ul> <li>
        //[URL href="http://softuni.bg">SoftUni[/URL]
        // </li>
        //</ul>
        // </li> </ul>

        var text = "< ul > < li > < a href = ""http://softuni.bg"" > SoftUni </ a > </ li > </ ul > end";


    }
}