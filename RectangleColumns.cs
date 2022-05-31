// 13. Write a C# program that takes a number as input and then displays a rectangle of 3 columns wide and 5 rows tall using that digit.

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a digit to display a rectangle of 3 columns and 5 rows tall");
        int digit = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{0}{0}",digit);
        Console.WriteLine("{0} {0}",digit);
        Console.WriteLine("{0} {0}", digit);
        Console.WriteLine("{0} {0}", digit);
        Console.WriteLine("{0}{0}{0}", digit);

    }
}
