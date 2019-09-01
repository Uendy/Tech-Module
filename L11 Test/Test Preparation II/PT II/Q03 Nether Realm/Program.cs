using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
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

        var listOfDemons = new List<Demon>();

        var inputedDemons = Console.ReadLine().Split(',').ToArray();
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
        for (int index = 0; index < nameAsArray.Count(); index++)
        {
            bool isNotDigit = !char.IsDigit(nameAsArray[index]);
            if (isNotDigit)
            {
                continue;
            }

            double currentNum = double.Parse(nameAsArray[index].ToString());

            if (index >= 1)
            {
                bool isNegative = nameAsArray[index - 1] == '-';
                if (isNegative)
                {
                    damage -= currentNum;
                    continue;
                }
            }
            damage += currentNum;
        }

        //multiplication and division
        //int multiplications = 0;
        //int divisions = 0;

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

        }
        else if(operations < 0) // divide

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