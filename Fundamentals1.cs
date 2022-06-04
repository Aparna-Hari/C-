
using System;

class Program
{
     static void Main()
    {
        ForValues();
        ForDivisible();
        ForBuzzFizz();
        WhileValues();
        WhileDivisible();
        WhileBuzzFizz();


    }
    // Create a Loop that prints all values from 1-255
    public static void ForValues()
    {
        for (int i = 1; i < 256; i++)
        {
            Console.WriteLine(i);
        }
    }
    //Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
    public static void ForDivisible()
    {
        for (int i = 1; i < 101; i++)
        {
            if ((i % 3 == 0 || i % 5 == 0) && !(i % 3 == 0 && i % 5 == 0))
            {
                Console.WriteLine(i);
            }
        }
    }
    //Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
    public static void ForBuzzFizz()
    {
        for (int i = 1; i < 101; i++)
        {
            if (i % 3 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" Fizz");
            }
            if (i % 5 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" Buzz");
            }
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" FizzBuzz");
            }
            
        }
    }

    //(Optional) If you used "for" loops for your solution, try doing the same with "while" loops.Vice-versa if you used "while" loops!
    public static void WhileValues()
    {
        int i = 1;
        while(i < 256)
        {
            Console.WriteLine(i);
            i++;
        }
    }

    public static void WhileDivisible()
    {
        int i = 1;
        while(i < 101)
        {
            if ((i % 3 == 0 || i % 5 == 0) && !(i % 3 == 0 && i % 5 == 0))
            {
                Console.WriteLine(i);
            }
            i++;
        }
    }

    public static void WhileBuzzFizz()
    {
        int i = 1;
        while(i < 101)
        {
            if (i % 3 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" Fizz");
            }
            if (i % 5 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" Buzz");
            }
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.Write(i);
                Console.WriteLine(" FizzBuzz");
            }
            i++;
        }
    }

}
