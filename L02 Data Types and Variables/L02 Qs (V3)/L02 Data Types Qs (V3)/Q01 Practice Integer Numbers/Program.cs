using System;
public class Program
{
    public static void Main()
    {
        //Instructions:
        //Create a new C# project and create a program that assigns integer values to variables. Be sure that each value is stored in the correct variable type (try to find the most suitable variable type in order to save memory). Finally, you need to print all variables to the console.
        //Ex inputs:
        //- 100
        //128
        //- 3540
        //64876
        //2147483648
        //- 1141583228
        //- 1223372036854775808 
    
        //Reading integers
        sbyte sbyteNum = sbyte.Parse(Console.ReadLine());
        byte byteNum = byte.Parse(Console.ReadLine());
        short shortNum = short.Parse(Console.ReadLine());
        ushort ushortNum = ushort.Parse(Console.ReadLine());
        int intNum = int.Parse(Console.ReadLine());
        uint uintNum = uint.Parse(Console.ReadLine());
        long longNum = long.Parse(Console.ReadLine());
        ulong ulongNum = ulong.Parse(Console.ReadLine());

    
        //Printing integers
        Console.WriteLine(sbyteNum);
        Console.WriteLine(byteNum);
        Console.WriteLine(shortNum);
        Console.WriteLine(ushortNum);
        Console.WriteLine(intNum);
        Console.WriteLine(uintNum);
        Console.WriteLine(longNum);
        Console.WriteLine(ulongNum);
    }
}
