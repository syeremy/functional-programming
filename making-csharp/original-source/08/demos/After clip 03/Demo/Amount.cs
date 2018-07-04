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

        public virtual Amount Add(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != this.Currency ? throw new ArgumentException("Mismatched currency.")
            : new Amount(this.Currency, this.Value + other.Value);

        public virtual Amount Subtract(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != this.Currency ? throw new ArgumentException("Mismatched currency.")
            : other.Value > this.Value ? throw new ArgumentException("Insufficient funds.")
            : new Amount(this.Currency, this.Value - other.Value);

        public Money PayableAt(Money money, Amount expense, Timestamp time) =>
            money is GiftCard gift && gift.ValidBefore.CompareTo(time) < 0 ? Amount.Zero(expense.Currency)
            : money is BankCard card && card.ValidBefore.CompareTo(time) < 0 ? Amount.Zero(expense.Currency)
            : money;

        public override string ToString() =>
            $"{this.Value} {base.Currency}";
    }
}
