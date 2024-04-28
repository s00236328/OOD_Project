using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitare
{
    class Card
    {
        public Suit Suit { get; private set; }
        public string Value { get; private set; }
        public bool Uncovered { get;private set; }
        public Card(Suit suit, string value, bool uncovered)
        {
            this.Suit = suit;
            this.Value = value;
            Uncovered = uncovered;
        }
        public string GetCardImagePath()
        {
            if (Uncovered == false)
            {
                return $"/images/Hearts/Back.png";
            }
            
            string ValueToImage = Value;
            if (Value == "11")
            {
                ValueToImage = "J";
            }
            else if (Value == "12")
            {
                ValueToImage = "Q";
            }
            else if (Value == "13")
            {
                ValueToImage = "K";
            }
            else if (Value == "1")
            {
                ValueToImage = "A";
            }
            // Example: "Images/Hearts/Ace.png"
            return $"/images/Hearts/{Suit.EToString()}{ValueToImage}.png";
            
        }
        public void Uncover()
        {
            Uncovered = true ;
        }
    }
}
