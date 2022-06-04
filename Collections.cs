



using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // Create an array to hold integer values 0 through 9
        int[] numArray2 = new int[10];
        for (int i = 0; i < numArray2.Length; i++)
        {
            numArray2[i] = i;
        }
        Console.WriteLine("Array:");
        Console.WriteLine(String.Join(",", numArray2));

        //Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
        string[] strArray = { "Tim", "Martin", "Nikki", "Sara" };
        Console.WriteLine(String.Join(",", strArray));

        //Create an array of length 10 that alternates between true and false values, starting with true
        bool[] boolArray = { true, false, true, false, true, false, true, false, true, false };
        Console.WriteLine(String.Join(",", boolArray));

        
        //List

        //Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
        
        
        Console.WriteLine("\nList starts here:");
        List<string> flavors = new List<string>();
        flavors.Add("Vanilla");
        flavors.Add("Chocolate");
        flavors.Add("Butterscotch");
        flavors.Add("CookiesNcreme");
        flavors.Add("PeanutButter");

        flavors.ForEach(Console.WriteLine);

        //Output the length of this list after building it

        Console.WriteLine("\nLength of this list is :{0}",flavors.Count);

        //Output the third flavor in the list, then remove this value
        Console.WriteLine("\nThird flavor of list is :{0}",flavors[2]);
        flavors.RemoveAt(2);
        Console.WriteLine("\nList after removing third flavor is :");
        flavors.ForEach(Console.WriteLine);


        //Output the new length of the list(It should just be one fewer!)
        Console.WriteLine( "\nLength of new list is :{0} ",flavors.Count);


        //Create a dictionary that will store both string keys as well as string values
        Console.WriteLine("\nDictionary is :");
        Dictionary<string, string> dict = new Dictionary<string, string>();

        //Add key / value pairs to this dictionary where:
        //each key is a name from your names array
        //each value is a randomly elected flavor from your flavors list.
        dict.Add("Tim", "Vanilla");
        dict.Add("Martin", "Chocolate");
        dict.Add("Nikki", "CookiesNcreme");
        dict.Add("Sara", "Peanutbutter");


        //Loop through the dictionary and print out each user's name and their associated ice cream flavor
        foreach (var entry in dict)
        {
            Console.WriteLine(entry.Key +"-" +entry.Value);
        }





    }
}
