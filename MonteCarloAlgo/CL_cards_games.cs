using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarloAlgo
{
    public class CL_cards_games
    {
        public List<CL_cards> Deck { get; private set; }

        public CL_cards_games()
        {
        }

        public void CreateDeck()
        {
            this.Deck = new List<CL_cards>();
            foreach (Symbol symbol in (Symbol[]) Enum.GetValues(typeof(Symbol)))
            {
                for (int j = 0; j < 13; j++)
                {
                    Deck.Add(new CL_cards(symbol, j + 1));
                }
            }
            //Console.WriteLine("New deck created.");
        }
    }
}