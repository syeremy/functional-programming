
using System;

namespace HelloWorldFunctional
{
    public abstract class SpecificMoney : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentException(nameof(Currency));
        }

        public override SpecificMoney Of(Currency currency)
        {
            if (currency.Equals(this.Currency))
                return this;

            return new Empty(currency);
        }
        
        public static SpecificMoney Of(SpecificMoney @this, Currency currency)
        {
            if (currency.Equals(@this.Currency))
                return @this;

            return new Empty(currency);
        }


        
        public abstract (Amount taken, Money remaining) Take(decimal amount);

        
    }
}