// 2.Write a C# Sharp program to print the sum of two numbers


using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("Enter two numbers");
		 int a = Convert.ToInt32(Console.ReadLine());
		 int b = Convert.ToInt32(Console.ReadLine());
		int sum = a + b;
		int div = a / b;	
		Console.WriteLine("Sum of two numbers is {0}: ", sum);
		Console.WriteLine("Division  of two numbers is {0}: ", div);
	}
}

