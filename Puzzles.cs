
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
        RandomArray();
        TossCoin();
        Names();

    }


    //Random Array 
    //Required:
    //    Create a function called RandomArray() that returns an integer array

    //    Create an empty array that will hold 10 integer values.  
    //    Loop through the array and assign each index a random integer value between 5 and 25.
    //    Print the min and max values of the array
    //    Print the sum of all the values
    static int[] RandomArray()
    {
        int[] numArray = new int[10] ;

        Random random = new Random();

        int max = 4;
        int min = 25;
        
        int sum = 0;

        for (int i=0;i< numArray.Length;i++)
        {
            numArray[i] = random.Next(5, 25);
             

            if (numArray[i] >= max)
            {
                max = numArray[i];
            }
            if (numArray[i] <= min)
            {
                min = numArray[i];
            }
            sum = sum + numArray[i];

        }
        Console.WriteLine(String.Join(",", numArray));
        int avg = sum / numArray.Length;
        Console.WriteLine("Max is :{0} ", max);
        Console.WriteLine("Min is :{0} ", min);
        Console.WriteLine("average is :{0}", avg);
        return numArray;
    }

    //Coin Flip
    //Required:
    //Create a function called TossCoin() that returns a string

        //Have the function print "Tossing a Coin!"
        //Randomize a coin toss with a result signaling either side of the coin
        //Have the function print either "Heads" or "Tails"
        //Finally, return the result

    //Optional:
    //Create another function called TossMultipleCoins(int num) that returns a Double

    //Have the function call the tossCoin function multiple times based on num value
    //Have the function return a Double that reflects the ratio of head toss to total toss

    static string TossCoin()
    {
        Console.WriteLine("Tossing a coin!");
        Random random = new Random();
        int heads = 0;
        int tails = 0;
        int result = random.Next(0,2);
        if (result == 0)
        {
            heads++;
            Console.WriteLine("Heads");
        }
        else
        {
            tails++;
            Console.WriteLine("Tails");
        }

        return result.ToString();
    }

    

//Names
//Build a function Names that returns a list of strings.In this function:

//Required: 
        //Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        //Return a list that only includes names longer than 5 characters
//Optional:
        //Shuffle the list and print the values in the new order

    static List<string> Names()
    {
        List<string> names = new List<string>();
        names.Add("Todd");
        names.Add("Tiffany");
        names.Add("Charlie");
        names.Add("Geneva");
        names.Add("Sydney");

        Console.WriteLine(String.Join(",", names));


        for (int i = 0; i < names.Count; i++)
        {
            if (names[i].Length <= 5)
            {
                names.RemoveAt(i);
            }
        }

        Console.WriteLine(String.Join(",", names));
        return names;
    }




}