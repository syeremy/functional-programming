using System;

namespace Demo
{
    public class FixedMoney : Money
    {
        public Currency Currency { get; }
        public decimal Amount { get; private set; }

        protected FixedMoney(Currency currency, decimal amount)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));
            if (amount <= 0)
                throw new ArgumentException("Negative amount.");

            this.Currency = currency;
            this.Amount = amount;
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            if (currency != this.Currency)
                return 0;
            decimal paid = Math.Min(this.Amount, amount);
            this.Amount -= paid;
            return paid;
        }
    }
}
