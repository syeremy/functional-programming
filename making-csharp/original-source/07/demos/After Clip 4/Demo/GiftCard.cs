using System;

namespace Demo
{
    public class GiftCard : Amount
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore) : base(currency, amount)
        {
            this.ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(ValidBefore));
        }

        public override Amount Add(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != base.Currency ? throw new ArgumentException("Mismatched currency.")
            : new GiftCard(base.Currency, base.Value + other.Value, this.ValidBefore);

        public override Amount Subtract(Amount other) =>
            other == null ? throw new ArgumentNullException(nameof(other))
            : other.Currency != base.Currency ? throw new ArgumentException("Mismatched currency.")
            : other.Value > base.Value ? throw new ArgumentException("Insufficient funds.")
            : new GiftCard(base.Currency, base.Value - other.Value, this.ValidBefore);
    }
}
