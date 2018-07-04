using System;

namespace Demo
{
    public class CardExpired : BankCard
    {
        public CardExpired(Month validBefore) : base(validBefore)
        {
        }

        public override Money On(Timestamp time) => 
            this;

        public override SpecificMoney Of(Currency currency) =>
            new Empty(currency);

        public override (Amount taken, Money remaining) Take(Currency currency, decimal amount) =>
            (Amount.Zero(currency), this);
    }
}
