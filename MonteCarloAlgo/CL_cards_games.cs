using System;
using System.Collections.Generic;

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
            Symbol[] symbols = (Symbol[])Enum.GetValues(typeof(Symbol));
            for (int i = 0; i < symbols.Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Deck.Add(new CL_cards(symbols[i], j + 1));
                }
            }
            Console.WriteLine("New deck created.");
        }
    }
}