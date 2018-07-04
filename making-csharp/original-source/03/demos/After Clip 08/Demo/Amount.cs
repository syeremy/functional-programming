using System;

namespace Demo
{
    public class Amount
    {
        public Currency Currency { get; }
        public decimal Value { get; }

        public Amount(Currency currency, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Negative amount.");

            this.Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            this.Value = amount;
        }

        public Amount Scale(decimal factor) =>
            new Amount(this.Currency, factor * this.Value);

        public Amount Add(Amount other)
        {
            switch (other)
            {
                case null: throw new ArgumentNullException(nameof(other));
                case Amount am when am.Currency != this.Currency: throw new ArgumentException("Mismatched currencies.");
                default: return new Amount(this.Currency, this.Value + other.Value);
            }
        }

        public static Amount Zero(Currency currency) =>
            new Amount(currency, 0);

        public override string ToString() => $"{this.Value} {this.Currency}";
    }
}
