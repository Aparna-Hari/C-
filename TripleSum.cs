// 19. Write a C# program to compute the sum of two given integers, if two values are equal then return the triple of their sum

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first Integer");

        int firstNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second Integer");

        int secondNumber = Convert.ToInt32(Console.ReadLine());


        if (firstNumber == secondNumber)
            Console.WriteLine("Sum is {0}", 3 * firstNumber);
        else
            Console.WriteLine("sum is {0}", firstNumber + secondNumber);

    }
}
