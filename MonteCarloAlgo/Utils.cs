using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloAlgo
{
    public class Utils
    {
        public void OddsRatioCalculation(List<CL_player> players)
        {
            int playersVictories = players.Where(p => !p.IsCroupier).Sum(p => p.VictoryCount);
            int bankVictories = players.Where(p => p.IsCroupier).Select(p => p.VictoryCount).First();
            int gcd = GCD(bankVictories, playersVictories);
            Console.WriteLine("Odds ratio -> (Bank) {0} : {1} (Players).", bankVictories / gcd, playersVictories / gcd);
        }

        private int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }
    }
}
