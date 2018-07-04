using System;

namespace Demo
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            this.ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }

        public override Money On(Timestamp time) =>
            this.CardOn(time);

        public BankCard CardOn(Timestamp time) =>
            time.CompareTo(this.ValidBefore) >= 0
                ? (BankCard)new CardExpired(this.ValidBefore)
                : this;

        public override SpecificMoney Of(Currency currency) =>
            new SpecificCard(currency, this);

        public virtual (Amount taken, Money remaining) Take(Currency currency, decimal amount) =>
            (new Amount(currency, amount), this);
    }
}
