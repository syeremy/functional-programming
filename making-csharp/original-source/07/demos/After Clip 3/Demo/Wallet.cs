using System;
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
                (Amount stepPaid, Money stepRemaining) = this.Pay(money, remainder);
                paid = paid.Add(stepPaid);
                rests.Add(stepRemaining);
            }

            return (paid, new Wallet(rests.Where(item => !(item is Empty))));
        }

        private (Amount paid, Money remaining) Pay(Money money, Amount remainder)
        {
            Timestamp now = Timestamp.Now;
            switch (money)
            {
                case Amount amt when amt.Currency != remainder.Currency:
                    return (Amount.Zero(remainder.Currency), money);
                case Amount amt when amt.Value <= remainder.Value:
                    return (new Amount(amt.Currency, amt.Value), Amount.Zero(amt.Currency));
                case GiftCard gift when gift.Currency != remainder.Currency:
                    return (Amount.Zero(remainder.Currency), gift);
                case GiftCard gift when gift.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(remainder.Currency), Amount.Zero(gift.Currency));
                case GiftCard gift when gift.Value <= remainder.Value:
                    return (new Amount(gift.Currency, gift.Value), Amount.Zero(gift.Currency));
                case Amount amt:
                    return (remainder, amt.Subtract(remainder));
                case BankCard card when card.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(remainder.Currency), Amount.Zero(remainder.Currency));
                case BankCard _:
                    return (remainder, money);
                default:
                    throw new ArgumentException("Money type not supported.");
            }
        }
    }
}
