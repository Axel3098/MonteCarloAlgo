using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarloAlgo
{
    public class CL_croupier : CL_player
    {
        public CL_croupier() : base(true, "Bank")
        {
        }

        public void CountScore(CL_player player)
        {
            player.Score = player.Hand.Sum(c => c.Value);
            CL_cards firstCard = player.Hand.First();
            if (player.IsCroupier)
            {
                if (player.Hand.All(c => c.Value == firstCard.Value))
                {
                    player.IsWinner = true;
                }
                else if (player.Hand.All(c => c.Symbol == firstCard.Symbol))
                {
                    player.Score += 35;
                }
            }
            else if (player.Hand.All(c => c.Symbol == firstCard.Symbol))
            {
                player.Score += 20;
            }
            Console.WriteLine("Score de {0} : {1}.", player.Name, player.Score);
        }

        public void GiveCards(List<CL_cards> deck, List<CL_player> players)
        {
            int dealtCards;
            foreach (CL_player player in players)
            {
                if (player.IsCroupier)
                {
                    dealtCards = 3;
                    //Console.WriteLine("{0} receives {1} cards.", player.Name, dealtCards);
                    player.ReceiveCards(deck, dealtCards);
                }
                else
                {
                    dealtCards = 2;
                    //Console.WriteLine("{0} receives {1} cards.", player.Name, dealtCards);
                    player.ReceiveCards(deck, dealtCards);
                }
                deck.RemoveRange(0, dealtCards);
            }
        }

        public void NameWinner(List<CL_player> players)
        {
            CL_player winner = players.Find(p => p.IsWinner);
            if (!players.Exists(p => p.IsWinner))
            {
                int maxScore = players.Max(p => p.Score);
                winner = players.Find(p => p.Score == maxScore);
            }
            winner.VictoryCount++;
            winner.IsWinner = false;
            //Console.WriteLine("And the winner is... {0} with {1} points.", winner.Name, winner.Score);
        }

        public List<CL_cards> Shuffle(List<CL_cards> deck)
        {
            //Console.WriteLine("Deck is being shuffling.");
            return deck.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}