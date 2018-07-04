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

        public override Money On(Timestamp time) =>
            time.CompareTo(this.ValidBefore) >= 0
                ? Amount.Zero(base.Currency)
                : this;
    }
}
