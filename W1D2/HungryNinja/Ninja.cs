using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    // add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();

    }

    // add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories

    bool IsFull
    {
        get 
        { 
            return calorieIntake>1200;
        }
    }

    // Build out the Eat method of the Ninja class so that if the Ninja is not full, it adds the calories to the calorieIntake,
    // it adds the food to the Food History, and it prints out the name of the food and whether or not it is Spicy or Sweet to the console.
    // if the Ninja is full, a warning prints to the console.
    public void Eat(Food item)
    {
        if (IsFull == false)
        {
            calorieIntake = calorieIntake + item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine("Ninja ate {0}", item.Name);
            if (item.IsSpicy)
            {
                Console.WriteLine("{0} is spicy", item.Name);
            }
            if (item.IsSweet)
            {
                Console.WriteLine("{0} is sweet", item.Name);
            }
        }
        else
            Console.WriteLine("Ninja is too full");
                

        
    }
}


