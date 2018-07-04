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
            new Empty(currency);

        public (Amount paid, Money remaining) Pay(Amount expense)
        {
            if (expense.Currency != this.Currency)
                return (Amount.Zero(expense.Currency), this);
            if (expense.Value >= this.Value)
                return (this, Amount.Zero(this.Currency));
            return (expense, this.Subtract(expense));
        }

        public virtual Amount Add(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != this.Currency ? throw new ArgumentException("Mismatched currency.")
            : new Amount(this.Currency, this.Value + other.Value);

        public virtual Amount Subtract(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != this.Currency ? throw new ArgumentException("Mismatched currency.")
            : other.Value > this.Value ? throw new ArgumentException("Insufficient funds.")
            : new Amount(this.Currency, this.Value - other.Value);

        public override string ToString() =>
            $"{this.Value} {base.Currency}";
    }
}
