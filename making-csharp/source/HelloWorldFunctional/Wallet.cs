using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldFunctional
{
    public class Wallet
    {
        private IList<Money> Content { get; set; } = new List<Money>();

        public void Add(Money money)
        {
            this.Content.Add(money);
        }

        public Amount Charge(Currency currency, Amount toCharge)
        {
            IEnumerable<(Amount taken, Money remaining)> split = Content.On(Timestamp.Now)
                .Of(toCharge.Currency)
                .Take(toCharge.Value);

            this.Content = split.Select(tuple => tuple.remaining).ToList();
            
            decimal total = split.Sum(tuple => tuple.taken.Value);
            return new Amount(toCharge.Currency, total);
        }
    }
}