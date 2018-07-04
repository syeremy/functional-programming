using System;

namespace Demo
{
    public class Amount : SpecificMoney
    {
        public decimal Value { get; }

        public Amount(Currency currency, decimal amount) : base(currency)
        {
            if (amount < 0)
                throw new ArgumentException("Negative amount.");
            this.Value = amount;
        }

        public static Amount Zero(Currency currency) =>
            new Amount(currency, 0);

        public override string ToString() =>
            $"{this.Value} {base.Currency}";
    }
}
