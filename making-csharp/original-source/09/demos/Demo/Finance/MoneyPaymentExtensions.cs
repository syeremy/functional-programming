using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo.Finance
{
    public static class MoneyPaymentExtensions
    {
        public static Money At(this Money money, Timestamp time)
        {
            switch (money)
            {
                case GiftCard gift when gift.ValidBefore.CompareTo(time) < 0:
                    return NonSpecificEmpty.Zero;
                case BankCard card when card.ValidBefore.CompareTo(time) < 0:
                    return NonSpecificEmpty.Zero;
                default: return money;
            }
        }

        public static IEnumerable<Money> At(
            this IEnumerable<Money> moneys, Timestamp time)
        {
            foreach (Money money in moneys)
            {
                switch (money.At(time))
                {
                    case NonSpecificEmpty _: break;
                    case Empty _: break;
                    default: yield return money; break;
                }
            }
        }

        public static IEnumerable<Money> Payable(this IEnumerable<Money> moneys)
        {
            foreach (Money money in moneys)
            {
                switch (money)
                {
                    case Amount amt when amt.Value > 0: yield return amt; break;
                    case BankCard card: yield return card; break;
                }
            }
        }

        public static Money Of(this Money money, Currency currency)
        {
            switch (money)
            {
                case SpecificMoney specific when specific.Currency == currency:
                    return specific;
                case BankCard _: return money;
                default: return Amount.Zero(currency);
            }
        }

        public static (Amount paid, Money remaining) Withdraw(
            this Money money, Amount expense)
        {
            switch (money)
            {
                case Amount amt when amt.Value > expense.Value:
                    return (expense, amt.Subtract(expense));
                case Amount amt when amt.Value > 0:
                    return (amt, Amount.Zero(amt.Currency));
                case BankCard _: return (expense, money);
                default: return (Amount.Zero(expense.Currency), money);
            }
        }
    }
}