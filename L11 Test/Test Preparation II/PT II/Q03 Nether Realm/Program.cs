using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
    public static void Main()
    {
        #region
        //Mighty battle is coming. In the stormy nether realms, demons are fighting against each other for supremacy in a duel from which only one will survive. 

        //Your job, however is not so exciting.You are assigned to sign in all the participants in the nether realm's mighty battle's demon book,
        //which of course is sorted alphabetically. 

        //A demon's name contains his health and his damage. 
        //The sum of the asci codes of all characters(excluding numbers(0 - 9), arithmetic symbols('+', '-', '*', '/') and delimiter dot('.'))
        //gives a demon's total health. 

        //The sum of all numbers in his name forms his base damage.
        //Note that you should consider the plus '+' and minus '-' signs(e.g. + 10 is 10 and - 10 is -10).
        //However, there are some symbols('*' and '/') that can further alter the base damage by multiplying or dividing it by 2
        //(e.g. in the name "m15*/c-5.0", the base damage is 15 + (-5.0) = 10 and then you need to multiply it by 2(e.g. 10 * 2 = 20),
        //then divide it by 2(e.g. 20 / 2 = 10)).

        //So, multiplication and division are applied only after all numbers are included in the calculation and in the order they appear in the name. 

        //You will get all demons on a single line, separated by commas and zero or more blank spaces.
        //Sort them in alphabetical order and print their names along their health and damage.
        #endregion


        var listOfDemons = new List<Demon>();

        var inputedDemons = Console.ReadLine().Split(new[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
        foreach (var demon in inputedDemons)
        {
            var newDemon = new Demon();

            newDemon.Name = demon;

            //get his health
            newDemon.Health = CalculateHealth(demon);

            //get his damage
            newDemon.Damage = CalculateDamage(demon);

            listOfDemons.Add(newDemon);
        }


        var result = listOfDemons.OrderBy(x => x.Name);
        foreach (var currentDemon in result)
        {
            Console.WriteLine($"{currentDemon.Name} - {currentDemon.Health} health, {currentDemon.Damage:f2} damage");
        }
    }

    //The sum of all numbers in his name forms his base damage.
    //Note that you should consider the plus '+' and minus '-' signs(e.g. +10 is 10 and -10 is -10). 
    //However, there are some symbols('*' and '/') that can further alter the base damage by multiplying or dividing it by 2 
    //(e.g. in the name "m15*/c-5.0", the base damage is 15 + (-5.0) = 10 and then you need to multiply it by 2 
    //(e.g. 10 * 2 = 20) and then divide it by 2 (e.g. 20 / 2 = 10)). 
    public static double CalculateDamage(string demon)
    {
        double damage = 0.0;

        var nameAsArray = demon.ToCharArray();

        //the simple arythmetics

        var sb = new StringBuilder(); // recive only the numbers and the decimal places and negative signs
        for (int index = 0; index < nameAsArray.Count(); index++)
        {
            bool wanted = char.IsDigit(nameAsArray[index]) || nameAsArray[index] == '-' || nameAsArray[index] == '.';
            if (wanted)
            {
                sb.Append(nameAsArray[index]);
            }
            else
            {
                sb.Append('X');
            }
        }

        var sbAsString = sb.ToString();

        var importantInfo = sbAsString.Split(new[] {'X'}, StringSplitOptions.RemoveEmptyEntries).ToArray().Select(double.Parse).ToArray();
        foreach (var num in importantInfo)
        {
            damage += num;
        }

        //see how many multiplications or divions you will need
        int operations = 0;

        for (int index = 0; index < demon.Length; index++)
        {
            if (nameAsArray[index] == '*')
            {
                operations++;
            }
            else if (nameAsArray[index] == '/')
            {
                operations--;
            }
        }

        if (operations > 0) // muttiply
        {
            for (int i = operations; i >= 1; i--)
            {
                damage *= 2;
            }
        }
        else if (operations < 0) // divide
        {
            for (int i = operations; i >= 1; i--)
            {
                damage /= 2;
            }
        }

        return damage;
    }


    //The sum of the asci codes of all characters (excluding numbers (0-9), arithmetic symbols ('+', '-', '*', '/'),
    //delimiter dot ('.')) gives a demon's total health. 
    public static int CalculateHealth(string demon)
    {
        int health = 0;

        var listOfBannedSymbols = new List<char>() { '+', '-', '*', '/', '.' };

        var nameAsArray = demon.ToCharArray();
        foreach (var character in nameAsArray)
        {
            bool isNumber = char.IsDigit(character);
            if (isNumber)
            {
                continue;
            }

            bool isBanned = listOfBannedSymbols.Contains(character);
            if (isBanned)
            {
                continue;
            }

            //is acceptable so add to totalHealth
            health += character;
        }

        return health;
    }
}