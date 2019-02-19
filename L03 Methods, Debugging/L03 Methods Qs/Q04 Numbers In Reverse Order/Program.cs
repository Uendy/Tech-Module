using System;

namespace Q04_Number_In_Reverse_Order
{
    class Program
    {
        //Really did not understand this one
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
        
            Console.WriteLine(NumberReverser(inputNumber));
        }
         static string NumberReverser(string inputNumber)
         {
            char[] stringToCharArray = inputNumber.ToCharArray();
            char[] result = new char[stringToCharArray.Length];

            for (int i = stringToCharArray.Length - 1; i >= 0; i--)
            {
                result[result.Length - 1 - i] = stringToCharArray[i];
            }
            
            return new string (result);

         }
    }
}
