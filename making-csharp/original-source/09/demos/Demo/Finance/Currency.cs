using System;

namespace Demo.Finance
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

        public bool Equals(Currency obj) =>
            !object.ReferenceEquals(obj, null) && obj.Symbol == this.Symbol;

        public override int GetHashCode() =>
            this.Symbol?.GetHashCode() ?? 0;

        public static bool operator ==(Currency a, Currency b) =>
            object.ReferenceEquals(a, b) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(Currency a, Currency b) => !(a == b);

        public override string ToString() => this.Symbol;
    }
}
