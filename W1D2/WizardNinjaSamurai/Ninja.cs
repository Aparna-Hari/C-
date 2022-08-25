using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ninja :Human
{
    //Ninja should have a default dexterity of 175
    public Ninja(string name) :base(name)
    {
        Dexterity = 175;
    }

    //Provide an override Attack method to Ninja, which reduces the target by 5 * Dexterity
    //and a 20% chance of dealing an additional 10 points of damage.
    public override int Attack(Human target)
    {
        
        int damage = 5 * Dexterity;
        Random rand = new Random();
        int randomNumber = rand.Next(1,11);
        if (randomNumber < 3)
        {
            damage += 10;
        }
        target.Health -= damage;
        return target.Health;
    }

    //Ninja should have a method called Steal, reduces a target Human's health by 5 and adds this amount to its own health.
    public void Steal(Human target)
    {
        target.Health -= -5;
        Health = Health + 5;
    }
}