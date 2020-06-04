namespace MonteCarloAlgo
{
    public class CL_cards
    {
        public Symbol Symbol { get; private set; }
        public int Value { get; private set; }

        public CL_cards(Symbol symbol, int value)
        {
            this.Symbol = symbol;
            this.Value = value;
        }
    }
}