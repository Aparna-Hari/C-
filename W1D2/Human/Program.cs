using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Human human1 = new Human("Alex");
        Console.WriteLine("Name of Human1: {0}", human1.Name);

        Human human2 = new Human("sree", 15, 5, 5, 100);
        Console.WriteLine("Name of Human2: {0}", human2.Name);

        
        Console.WriteLine(human1.Attack(human2));

    }
}