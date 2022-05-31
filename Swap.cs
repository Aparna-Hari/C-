//  5. Write a C# Sharp program to swap two numbers

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first number :");

        int firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number :");
        
        int secondNumber = int.Parse(Console.ReadLine());
        int temp;
        temp = firstNumber;
        firstNumber = secondNumber;
        secondNumber = temp;
        Console.WriteLine("Numbers after swapping are : \nfirst number is {0} \nsecond number is {1}",firstNumber,secondNumber);

    }
}
