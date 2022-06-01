//15. Write a C# program remove specified a character from a non-empty string using index of a character.

using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(remove_char("W3resource", 1));
        Console.WriteLine(remove_char("W3resource", 2));
        Console.WriteLine(remove_char("W3resource", 0));
    }
    public static string remove_char(string str, int n)
    {
        return str.Remove(n,1);
    }
}
