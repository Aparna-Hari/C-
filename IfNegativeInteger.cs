// 18. Write a C# program to check two given integers and return true if one is negative and one is positive

using System;

class Program
{
    static void  Main()
    {
        Console.WriteLine("Enter first integer");

        int firstInteger = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second integer");

        int secondInteger = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Checking if one is negative and one is positive");

        Console.WriteLine((firstInteger >= 0 && secondInteger <= 0) || (firstInteger <= 0 && secondInteger >= 0));
            
            

    }
}
