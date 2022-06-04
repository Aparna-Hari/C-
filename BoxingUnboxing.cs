
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create an empty List of type object
        List<object> list = new List<object>();

        //Add the following values to the list: 7, 28, -1, true, "chair"
        
        list.Add(7);
        list.Add(28);
        list.Add(-1);
        list.Add(true);
        list.Add("chair");

        //Loop through the list and print all values
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }


        //Add all values that are Int type together and output the sum
        int sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] is int)
            {
                
                sum += (int)list[i];
            }
        }
        Console.WriteLine("\nsum of integer values is : {0} ", sum);
    }
}