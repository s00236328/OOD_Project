using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitare
{
    internal class Card
    {
        public Suit suit { get; private set; }
        public int value { get; private set; }

        public Card(Suit suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

    }
}
