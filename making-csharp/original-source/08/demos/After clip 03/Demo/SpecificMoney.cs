using System;

namespace Demo
{
    public abstract class SpecificMoney  : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}