// 16. Write a C# program to create a new string from a given string where the first and last characters will change their positions.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(swap_string("W3resource"));
    }
    public static string swap_string(string s)
    {
        return s.Length > 1
            ? s.Substring(s.Length - 1) + s.Substring(1, s.Length - 2) + s.Substring(0,1) : s;
    }
}
