
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //PrintNumbers();

        //PrintOdds();

        //PrintSum();

        int[] numArray1 = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        //LoopArray(numArray1);

        int[] numArray2 = { 0, -10, 20, -30, 40, -50, 60, -70, -80, -90 };
        //FindMax(numArray2);

        /*int[] array = { 2, 10, 3 };*/
        //GetAverage(numArray);

        //OddArray();

        //GreaterThanY(numArray1, 60);

        //SquareArrayValues(numArray2);

        //EliminateNegatives(numArray2);



        //MinMaxAverage(numArray1);

        ShiftValues(numArray1);

        NumToString(numArray2);

    }

    // Print all of the integers from 1 to 255.
    static void PrintNumbers()
    {
        for (int i = 1; i < 256; i++)
        {
            Console.WriteLine(i);
        }
    }

    // Print all odd integers from 1 to 255.

    static void PrintOdds()
    {
        for (int i = 1; i < 256; i++)
        {
            if (i % 2 == 1)
                Console.WriteLine(i);
        }

    }

    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:

    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New number: 2 Sum: 3
    static void PrintSum()
    {

        int sum = 0;
        for (int i = 0; i < 256; i++)

        {
            Console.Write("New number : {0},", i);


            Console.WriteLine("  sum : {0}", sum += i);
        }

    }

    //4. Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 
    static void LoopArray(int[] numbers)
    {
        Console.WriteLine("\nArray has :");
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    // 5.Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.
    static int FindMax(int[] numbers)
    {

        Console.WriteLine(numbers.Max());
        return numbers.Max();

    }

    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.
    static void GetAverage(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum = sum + numbers[i];

        }
        int avg = sum / numbers.Length;
        Console.WriteLine("Average of numbers is {0} ", avg);
    }

    // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
    // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
    static int[] OddArray()
    {


        int[] numArray = new int[256 / 2];
        int i = 1;
        //int arrayidx = 0;
        while (i < 256)
        {
            if (i % 2 == 1)
            {
                //Console.WriteLine(i);  
                numArray[i / 2] = i;

                //numArray[arrayidx] = i;

                // arrayidx++;
            }

            i++;

        }
        Console.WriteLine(String.Join(",", numArray));
        return numArray;

    }

    //8. Write a function that takes an integer array, and a integer "y" and returns the number of array values 
    // That are greater than the "y" value. 
    // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
    // (since there are two values in the array that are greater than 3).

    static int GreaterThanY(int[] numbers, int y)
    {
        int count = 0;
        foreach (var item in numbers)
        {
            if (item > y)
                count++;
        }
        Console.Write("\nNumber of array values greater than Y are : {0}\n", count);
        return count;
    }
    //9. Write a function that takes an integer array "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]
    static void SquareArrayValues(int[] numbers)
    {

        for (int i= 0 ; i < numbers.Length; i++)
        {
           numbers[i] = numbers[i] *numbers[i];
        }
        Console.WriteLine(String.Join(",",numbers));
    }

    // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
    static void EliminateNegatives(int[] numbers)
    {
        for (int i=0; i<numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                numbers[i] = 0;
            }
            
        }
        Console.WriteLine(String.Join(",", numbers));
    }

    // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
    // the minimum value in the array, and the average of the values in the array.
    static void MinMaxAverage(int[] numbers)
    {
        int max = numbers[0];
        int min = numbers[0];
        int sum = 0;

        for (int i=0; i< numbers.Length; i++)
        {
            
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
            else if (numbers[i] < min)
            {
                min = numbers[i];
            }
            sum = sum + numbers[i];
            
        }
        int avg = sum / numbers.Length;
        Console.WriteLine("Max is :{0} ", max);
        Console.WriteLine("Min is :{0} ", min);
        Console.WriteLine("average is :{0}", avg);

    }

    // Given an integer array, say [1, 5, 10, 7, -2], 
    // Write a function that shifts each number by one to the front and adds '0' to the end. 
    // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
    // it should become [5, 10, 7, -2, 0].
    static void ShiftValues(int[] numbers)
    {
        for (int i=0;i<numbers.Length-1 ; i++)
        {
            numbers[i] = numbers[i + 1];
            
        }
        numbers[numbers.Length - 1] = 0;
        Console.WriteLine(String.Join(",", numbers));

    }

    // Write a function that takes an integer array and returns an object array 
    // that replaces any negative number with the string 'Dojo'.
    // For example, if array "numbers" is initially [-1, -3, 2] 
    // your function should return an array with values ['Dojo', 'Dojo', 2].
    static object[] NumToString(int[] numbers)
    {
        object[] objects = new object[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
                objects[i] = "Dojo";
            else
                objects[i] = numbers[i];
        }
        Console.WriteLine(String.Join(",",objects));
        return objects;

    }
}


