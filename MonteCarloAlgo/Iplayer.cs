using System.Collections.Generic;

namespace MonteCarloAlgo
{
    public interface IPlayer
    {
        List<CL_cards> Hand { get; set; }

        bool IsCroupier { get; set; }

        bool IsWinner { get; set; }

        string Name { get; set; }

        int Score { get; set; }

        int VictoryCount { get; set; }

        void ReceiveCards(List<CL_cards> deck, int number);
    }
}