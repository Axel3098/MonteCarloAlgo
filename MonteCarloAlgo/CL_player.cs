using System.Collections.Generic;

namespace MonteCarloAlgo
{
    public class CL_player : IPlayer
    {
        public List<CL_cards> Hand { get; set; }
        public bool IsCroupier { get; set; }
        public bool IsWinner { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public int VictoryCount { get; set; } = 0;

        public CL_player(bool isCroupier, string name)
        {
            this.Name = name;
            this.IsCroupier = isCroupier;
            this.IsWinner = false;
        }

        public void ReceiveCards(List<CL_cards> deck, int number)
        {
            this.Hand = deck.GetRange(0, number);
            /*foreach (CL_cards card in Hand)
            {
                Console.WriteLine("{0} of {1}.", card.Value, card.Symbol);
            }*/
        }
    }
}