using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitare
{
    class SpiderCardDeck : CardDeck
    {
        int changeIndex = -1;

        public SpiderCardDeck()
        {
            deck = new List<Card>();
        }

        public void AddCovered(Card c)
        {
            deck.Add(c);
        }

        public void AddUncovered(Card c)
        {
            deck.Add(c);
            if (changeIndex == -1)
            {
                changeIndex = deck.Count - 1;
            }
        }

        public void Uncover()
        {
            if (changeIndex == -1)
            {
                changeIndex = deck.Count - 1;
            }
        }
        //method to write cards to string

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < deck.Count; i++)
            {
                if (i < changeIndex)
                {
                    s += "*,";
                }
                else
                {
                    s += deck[i].Suit + ":" + deck[i].Value + " ";
                }
            }

            return s;
        }
    }
}
