//12. Write a C# program to that takes a number as input and display it four times in a row (separated by blank spaces),
//and then four times in the next row, with no separation. 

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number to display :");

        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Output is :\n{0} {0} {0} {0}",number);
        Console.WriteLine("{0}{0}{0}{0}", number);
    }
}