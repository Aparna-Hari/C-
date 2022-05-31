// Write a C# program to convert from celsius degrees to Kelvin and Fahrenheit

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the amount of Celsius :");
        int celsius = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Kelvin = {0}", celsius + 273);
        Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);
    }

}