using System;

namespace HelloWorldFunctional
{
    public sealed class Currency : IEquatable<Currency>
    {
        public string Symbol { get; }

        private Currency(string symbol)
        {
            this.Symbol = symbol;
        }
        
        public static Currency USD => new Currency("USD");
        public static Currency EUR => new Currency("EUR");
        public static Currency JPY => new Currency("JPY");


        public override bool Equals(object obj) => this.Equals(obj as Currency);

        public override int GetHashCode()
        {
            return (Symbol != null ? Symbol.GetHashCode() : 0);
        }

        public static bool operator ==(Currency a, Currency b) =>
            a?.Equals(b) ?? ReferenceEquals(b, null);

        public static bool operator !=(Currency a, Currency b) => !(a == b);

        public override string ToString() => this.Symbol;

        public bool Equals(Currency other) => other != null && Symbol == other.Symbol;
    }
    
}