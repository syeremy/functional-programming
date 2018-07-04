using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    class Wallet
    {
        private IList<Money> Content { get; } = new List<Money>();

        public void Charge(Currency currency, decimal amount)
        {
            decimal remaining = amount;

            using (IEnumerator<Money> money = this.Content.GetEnumerator())
            {
                while (money.MoveNext() && remaining > 0)
                {
                    decimal paid = money.Current.Withdraw(currency, remaining);
                    remaining -= paid;
                }
            }
        }
    }
}
