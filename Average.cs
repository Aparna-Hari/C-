// 9. Write a C# Sharp program that takes four numbers as input to calculate and print the average

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine(" Enter 4 numbers :");
        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());
        double number3 = double.Parse(Console.ReadLine());
        double number4 = double.Parse(Console.ReadLine());
        double avg = (number1 + number2 + number3 + number4) / 4;
        Console.WriteLine("Average is {0}: ",avg);
    }
}
