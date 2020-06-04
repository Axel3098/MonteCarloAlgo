using System;
using System.Collections.Generic;

namespace MonteCarloAlgo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CL_cards_games deck = new CL_cards_games();
            CL_croupier croupier = new CL_croupier();
            CL_player player1 = new CL_player(false, "Player 1");
            CL_player player2 = new CL_player(false, "Player 2");
            List<CL_player> players = new List<CL_player>
            {
                player1,
                player2,
                croupier
            };
            deck.CreateDeck();
            List<CL_cards> shuffledDeck = croupier.Shuffle(deck.Deck);
            croupier.GiveCards(shuffledDeck, players);
            foreach (CL_player player in players)
            {
                croupier.CountScore(player);
            }
            CL_player winner = croupier.NameWinner(players);

            Console.WriteLine("And the winner is... {0} with {1} points.", winner.Name, winner.Score);
            Console.ReadLine();
        }
    }
}