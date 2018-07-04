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

        public override Money On(Timestamp time) => this;

        public override (Amount taken, Money remaining) Take(decimal amount)
        {
            decimal taken = Math.Min(this.Value, amount);
            decimal remaining = this.Value - taken;

            return new ValueTuple<Amount, Money>(
                new Amount(base.Currency, taken), 
                new Amount(base.Currency, remaining));
        }

        public static Amount Zero(Currency currency) =>
            new Amount(currency, 0);

        public override string ToString() => $"{this.Value} {base.Currency}";
    }
}
