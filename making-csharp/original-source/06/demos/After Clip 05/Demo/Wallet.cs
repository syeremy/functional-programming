using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class Wallet
    {
        private IList<Money> Content { get; set; } = new List<Money>();

        public void Add(Money money)
        {
            this.Content.Add(money ?? throw new ArgumentNullException(nameof(money)));
        }

        public Amount Charge(Currency currency, Amount toCharge)
        {
            IEnumerable<(Amount taken, Money remaining)> split =
                this.Content
                    .On(Timestamp.Now)
                    .Of(toCharge.Currency)
                    .Take(toCharge.Value)
                    .ToList();

            this.Content = split.Select(tuple => tuple.remaining).ToList();

            decimal total = split.Sum(tuple => tuple.taken.Value);
            return new Amount(toCharge.Currency, total);
        }
    }
}
