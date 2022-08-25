using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Wizard: Human
{
    public Wizard(string name) :base(name)
    {
        Intelligence = 25;
        Health = 50;
    }

    public override int Attack(Human target)
    {
        int damage = 5* Intelligence;
        target.Health = target.Health - damage;
        return target.Health;
    }

    public void Heal(Human target)
    {
        target.Health = 10* Intelligence;
    }
}