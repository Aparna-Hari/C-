//1. Write a C# Sharp program to print Hello and your name in a separate line.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please Enter your name");
        string UserName = Console.ReadLine();
        Console.WriteLine("Hello \n{0} " ,UserName);
    }
}