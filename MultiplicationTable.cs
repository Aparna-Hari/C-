//  Write a C# Sharp program that takes a number as input and print its multiplication table

using System;
class Program
{
    static void Main()
    {
        int product;
        Console.WriteLine(" Enter the number for its multiplication table");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Multiplication table of {0} is :",number);
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("{0} * {1} = {2}",number,i ,product = number * i );
        }
    }
}