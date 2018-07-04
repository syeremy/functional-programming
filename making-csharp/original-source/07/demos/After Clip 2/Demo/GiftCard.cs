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
    }
}
