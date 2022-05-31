
using System; 
//namespace declaration -  namespace is a collection of classes (where rest of the program uses code that is inside the namespacs System)

// Any piece of code we write should be  present inside class
class Program 
{
    //Main method is entry point to your application
    static void Main() 
    {
        //Console class is present inside the namespace System
        //WriteLine is used to write something to console
        Console.WriteLine("Please enter your Name");

        //ReadLine is used to read or enter the input
        string UserName = Console.ReadLine();

        //Console.WriteLine("Hello " + UserName);
        Console.WriteLine("Hello {0}", UserName);
    }
}

// A namespace is used to organize your code and is collection of classes,interfaces,structs,enums and delegates
