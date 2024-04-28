using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Solitare
{
    class Table
    {
        public List<Stack<Card>> SpiderStacks = new List<Stack<Card>>(10);  
        public List<Card> Stock;

        public Table()
        {
            for (int i = 0; i < 10; i++)
            {
                SpiderStacks.Add(new Stack<Card>());
            }
            var (stock,spider) = CardDeck.TwoDeck().SplitDeck();
            Stock = stock;
            int counter = 0; 
            
            foreach (Card card in spider)
            {
                SpiderStacks[counter].Push(card);
                if (counter == 9)
                {
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }
            foreach (var stack  in SpiderStacks)
            {
                var topcard = stack.Pop();
                    topcard.Uncover();
                stack.Push(topcard);
                 
            }

        }






       



















    //   public SpiderCardDeck[] spiderCardDecks = new SpiderCardDeck[10];
    //    CardDeck stock = new CardDeck();
    //    bool wasDoubled = false;

    //    public void Start()
    //    {
    //        for (int i = 0; i < spiderCardDecks.Length; i++)
    //        {
    //            spiderCardDecks[i] = new SpiderCardDeck();
    //        }
    //        stock = new CardDeck();
    //        stock.Shuffle();

    //        for (int i = 0; i < 5; i++)
    //        {
    //            foreach (SpiderCardDeck spiderCardDeck in spiderCardDecks)
    //            {
    //                spiderCardDeck.AddCovered(stock.Pop());
    //                CheckToDouble();
    //            }
    //        }

    //        for (int i = 0; i < 4; i++)
    //        {
    //            spiderCardDecks[i].AddUncovered(stock.Pop());
    //            CheckToDouble();
    //        }

    //        for (int i = 4; i < 10; i++)
    //        {
    //            spiderCardDecks[i].Uncover();
    //        }
    //    }

    //    void CheckToDouble()
    //    {
    //        if (stock.deck.Count == 0)
    //        {
    //            stock = new CardDeck();
    //            stock.Shuffle();
    //            wasDoubled = true;
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        string s = "";
    //        int deckNum = 1;
    //        foreach (SpiderCardDeck spiderCardDeck in spiderCardDecks)
    //        {
    //            s += deckNum + ": " + spiderCardDeck.ToString() + "\n";
    //            deckNum++;
    //        }

    //        s += stock.deck.Count;

    //        return s;
    //    }
    }
}
