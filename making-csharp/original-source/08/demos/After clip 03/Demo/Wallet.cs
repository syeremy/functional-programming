using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class Wallet
    {
        private IEnumerable<Money> Moneys { get; }

        public Wallet(IEnumerable<Money> moneys)
        {
            this.Moneys = moneys.ToList();
        }

        public (Amount paid, Wallet remaining) Pay(Amount expense)
        {
            Amount remainder = expense;
            Amount paid = Amount.Zero(expense.Currency);
            IList<Money> rests = new List<Money>();

            foreach (Money money in this.Moneys)
            {
                (Amount stepPaid, Money stepRemaining) = money.Pay(remainder);
                remainder = remainder.Subtract(stepPaid);
                paid = paid.Add(stepPaid);
                rests.Add(stepRemaining);
            }

            return (paid, new Wallet(rests.Where(item => !(item is Empty))));
        }
    }
}
