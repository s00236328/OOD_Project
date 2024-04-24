using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitare
{
    internal class Table
    {
        SpiderCardDeck[] spiderCardDecks = new SpiderCardDeck[10];
        CardDeck stock = new CardDeck();
        bool wasDoubled = false;

        public void Start()
        {
            for (int i = 0; i < spiderCardDecks.Length; i++)
            {
                spiderCardDecks[i] = new SpiderCardDeck();
            }
            stock = new CardDeck();
            stock.Shuffle();

            for (int i = 0; i < 5; i++)
            {
                foreach (SpiderCardDeck spiderCardDeck in spiderCardDecks)
                {
                    spiderCardDeck.AddCovered(stock.Pop());
                    CheckToDouble();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                spiderCardDecks[i].AddUncovered(stock.Pop());
                CheckToDouble();
            }

            for (int i = 4; i < 10; i++)
            {
                spiderCardDecks[i].Uncover();
            }
        }

        void CheckToDouble()
        {
            if (stock.deck.Count == 0)
            {
                stock = new CardDeck();
                stock.Shuffle();
                wasDoubled = true;
            }
        }

        public override string ToString()
        {
            string s = "";
            int deckNum = 1;
            foreach (SpiderCardDeck spiderCardDeck in spiderCardDecks)
            {
                s += deckNum + ": " + spiderCardDeck.ToString() + "\n";
                deckNum++;
            }

            s += stock.deck.Count;

            return s;
        }
    }
}
