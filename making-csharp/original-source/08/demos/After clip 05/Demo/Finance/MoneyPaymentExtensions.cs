using System;

namespace Demo.Finance
{
    public static class MoneyPaymentExtensions
    { 
        public static (Amount paid, Money remaining) Pay(this Money money, Amount expense)
        {
            Timestamp now = Timestamp.Now;
            switch (money)
            {
                case Amount amt when amt.Currency != expense.Currency:
                    return (Amount.Zero(expense.Currency), money);
                case Amount amt when amt.Value <= expense.Value:
                    return (amt, Amount.Zero(amt.Currency));
                case GiftCard gift when gift.Currency != expense.Currency:
                    return (Amount.Zero(expense.Currency), gift);
                case GiftCard gift when gift.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(expense.Currency), Amount.Zero(gift.Currency));
                case GiftCard gift when gift.Value <= expense.Value:
                    return (new Amount(gift.Currency, gift.Value), Amount.Zero(gift.Currency));
                case Empty _:
                    return (Amount.Zero(expense.Currency), money);
                case Amount amt:
                    return (expense, amt.Subtract(expense));
                case BankCard card when card.ValidBefore.CompareTo(now) < 0:
                    return (Amount.Zero(expense.Currency), Amount.Zero(expense.Currency));
                case BankCard _:
                    return (expense, money);
                default:
                    throw new ArgumentException(
                        $"Unsupported money type {money.GetType().Name}.");
            }
        }
    }
}