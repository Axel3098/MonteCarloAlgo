﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

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

            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 10000; i++)
            //System.Threading.Tasks.Parallel.For(0, 10000, (int x) =>
            {
                deck.CreateDeck();
                List<CL_cards> shuffledDeck = croupier.Shuffle(deck.Deck);
                croupier.GiveCards(shuffledDeck, players);
                foreach (CL_player player in players)
                {
                    croupier.CountScore(player);
                }
                croupier.NameWinner(players);
            } // Parallel.For

            foreach (CL_player player in players)
            {
                decimal win = player.VictoryCount;
                decimal ratio = win / 10000 * 100;
                Console.WriteLine("{0} wins: {1} , win ratio: {2}%.", player.Name, player.VictoryCount, ratio);
            }
            watch.Stop();

            Utils utils = new Utils();
            utils.OddsRatioCalculation(players);

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms.");

            Console.ReadLine();
        }
    }
}