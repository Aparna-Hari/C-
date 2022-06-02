// Write a C# program to get the absolute value of the difference between two given numbers.
// Return double the absolute value of the difference if the first number is greater than second number

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Result is {0} ", result());
    }
    public static int result()
    { 
        Console.WriteLine("Enter the first number");

         int firstNumber = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the second number");

         int secondNumber = Convert.ToInt32(Console.ReadLine());

        
        if (firstNumber > secondNumber)
            return 2*( firstNumber - secondNumber);
        else
            return secondNumber-firstNumber;
    }
}
