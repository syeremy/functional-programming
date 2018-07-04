using System;

namespace Demo
{
    public class Currency
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            this.Symbol = symbol;
        }

        public static Currency USD => new Currency("USD");
        public static Currency EUR => new Currency("EUR");
        public static Currency JPY => new Currency("JPY");

        public override string ToString() => this.Symbol;
    }
}
