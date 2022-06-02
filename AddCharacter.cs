// 17. Write a C# program to create a new string from a given string (length 1 or more ) with the first character added at the front and back

using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(add_char("The quick brown fox jumps over the lazy dog."));
    }
    public static string add_char(string s)
    {
        
        return s.Length > 0
            ? s.Substring(0,1) + s + s.Substring(0, 1) /* Substring(startIndex, length) */ :s;

    }
}