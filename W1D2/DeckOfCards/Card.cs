using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//create a class card
class Card
{
    public string Name;
    public string Suit;
    public int Value;


    public Card(string suit , int val)
    {
        switch (val)
        {
            case 11:
                Name = "Jack";
                break;
            case 12:
                Name = "Queen";
                break;
            case 13:
                Name = "King";
                break;
            case 1:
                Name = "Ace";
                break;
            default:
                Name = val.ToString();
                break;

        }
        this.Suit = suit;
        this.Value = val;
    }

    
    public override string ToString()
    {
        return $"{Name} {Suit} {Value}";
    }
}

