using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Given an input integer, you must determine which primitive data types are capable of properly storing that input.
        // my method would be much better if I could do a recursion, but I don't know how to do it with data types ex <T> number = <T>.Parse...
        string input = Console.ReadLine();
        var firstChar = input.ToCharArray().First();

        if (firstChar == '-') // its a negative (signed)
        {
            var listOfSignedDataTypes = new List<string>(new string[] { "sbyte", "short", "int", "long" });

            try
            {
                sbyte number = sbyte.Parse(input);
                Console.WriteLine($"{number} can fit in:");
                PrintUnsignedDataTypes(listOfSignedDataTypes);
            }
            catch (Exception)
            {
                listOfSignedDataTypes.Remove("sbyte");
                try
                {
                    short number = short.Parse(input);
                    Console.WriteLine($"{number} can fit in:");
                    PrintUnsignedDataTypes(listOfSignedDataTypes);
                }
                catch (Exception)
                {
                    listOfSignedDataTypes.Remove("short");
                    try
                    {
                        int number = int.Parse(input);
                        Console.WriteLine($"{number} can fit in:");
                        PrintUnsignedDataTypes(listOfSignedDataTypes);
                    }
                    catch (Exception)
                    {
                        listOfSignedDataTypes.Remove("int");
                        try
                        {
                            long number = long.Parse(input);
                            Console.WriteLine($"{number} can fit in:");
                            PrintUnsignedDataTypes(listOfSignedDataTypes);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"{input} Can't fit in any type");
                        }
                    }
                }
            }
        }
        else // any integer Data Type
        {
            var listOfDataTypes = new List<string>(new string[] {"sbyte", "byte", "short", "ushort", "int", "uint", "long" });

            try
            {
                sbyte number = sbyte.Parse(input);
                Console.WriteLine($"{number} can fit in:");
                PrintAllDataTypes(listOfDataTypes);
            }
            catch (Exception)
            {
                listOfDataTypes.Remove("sbyte");
                try
                {
                    byte number = byte.Parse(input);
                    Console.WriteLine($"{number} can fit in:");
                    PrintAllDataTypes(listOfDataTypes);
                }
                catch (Exception)
                {
                    listOfDataTypes.Remove("byte");
                    try
                    {
                        short number = short.Parse(input);
                        Console.WriteLine($"{number} can fit in:");
                        PrintAllDataTypes(listOfDataTypes);
                    }
                    catch (Exception)
                    {
                        listOfDataTypes.Remove("short");
                        try
                        {
                            ushort number = ushort.Parse(input);
                            Console.WriteLine($"{number} can fit in:");
                            PrintAllDataTypes(listOfDataTypes);
                        }
                        catch (Exception)
                        {
                            listOfDataTypes.Remove("ushort");
                            try
                            {
                                int number = int.Parse(input);
                                Console.WriteLine($"{number} can fit in:");
                                PrintAllDataTypes(listOfDataTypes);
                            }
                            catch (Exception)
                            {
                                listOfDataTypes.Remove("int");
                                try
                                {
                                    uint number = uint.Parse(input);
                                    Console.WriteLine($"{number} can fit in:");
                                    PrintAllDataTypes(listOfDataTypes);
                                }
                                catch (Exception)
                                {
                                    listOfDataTypes.Remove("uint");
                                    try
                                    {
                                        long number = long.Parse(input);
                                        Console.WriteLine($"{number} can fit in:");
                                        PrintAllDataTypes(listOfDataTypes);
                                    }
                                    catch (Exception)
                                    {
                                        listOfDataTypes.Remove("long");
                                        try
                                        {
                                            ulong number = ulong.Parse(input);
                                            Console.WriteLine($"{number} can fit in:");
                                            PrintAllDataTypes(listOfDataTypes);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine($"{input} can't fit in any type");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    public static void PrintUnsignedDataTypes(List<string> listOfUnsignedDataTypes)
    {
        foreach (var dataType in listOfUnsignedDataTypes)
        {
            Console.WriteLine($"* {dataType}");
        }
    }

    public static void PrintAllDataTypes(List<string> listOfDataTypes)
    {
        foreach (var dataType in listOfDataTypes)
        {
            Console.WriteLine($"* {dataType}");
        }
    }
}
