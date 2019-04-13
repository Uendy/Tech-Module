using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Ely likes to play Pokemon Go a lot. But Pokemon Go bankrupted …
        //So the developers made Pokemon Don’t Go out of depression. 
        //And so Ely now plays Pokemon Don’t Go. 
        //In Pokemon Don’t Go, when you walk to a certain pokemon, those closer to you, naturally get further, and those further from you, get closer.

        //You will receive a sequence of integers, separated by spaces – the distances to the pokemons.
        //Then you will begin receiving integers, which will correspond to indexes in that sequence.
        //When you receive an index, you must remove the element at that index from the sequence (as if you’ve captured the pokemon).
        //•	You must increase the value of all elements in the sequence, which are less or equal to the removed element, with the value of the removed element.
        //•	You must decrease the value of all elements in the sequence, which are greater than the removed element, with the value of the removed element.
        //If the given index is less than 0, remove the first element of the sequence, and copy the last element to its place.
        //If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
        //The increasing and decreasing of elements should be done in these cases, also. The element, whose value you should use is the removed element.
        //The program ends when the sequence has no elements(there are no pokemons left for Ely to catch).

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        int sum = 0;
        while (true)
        {
            if (list.Count() == 0)
            {
                break;
            }

            int index = int.Parse(Console.ReadLine());

            var currentNum = 0;

            if (index < 0)
            {
                currentNum = list[0];
                list.RemoveAt(0);
                list.Insert(0, list.Last());
            }
            else if (index > list.Count() - 1)
            {
                currentNum = list[list.Count() - 1];
                list.RemoveAt(list.Count() - 1);
                list.Add(list[0]);
            }
            else
            {
                currentNum = list[index];
                list.RemoveAt(index);
            }

            for (int indexOfList = 0; indexOfList < list.Count(); indexOfList++)
            {
                bool lowerOrEqual = currentNum >= list[indexOfList];
                if (lowerOrEqual == true)
                {
                    list[indexOfList] += currentNum;
                }
                else
                {
                    list[indexOfList] -= currentNum;
                }
            }

            sum += currentNum;
        }

        Console.WriteLine(sum);
    }
}