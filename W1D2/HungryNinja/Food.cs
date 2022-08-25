using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Food
{
    public string Name;
    public int Calories;
    public bool IsSpicy;
    public bool IsSweet;

    public Food(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}