

using System;
using System.Collections.Generic;
using System.Linq;


//instantiate a Buffet and Ninja object, and have the Ninja eat until they are full!
class Program
{
    static void Main()
    {
        Buffet buffet = new Buffet();
        Ninja ninja = new Ninja();
        ninja.Eat(buffet.Serve());
    }
}








