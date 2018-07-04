using Demo.Functional;
using System.Collections.Generic;

namespace Demo.Finance
{
    public static class MoneyFilters
    {
        public static Option<Money> At(this Money money, Timestamp time)
        {
            switch (money)
            {
                case GiftCard gift when gift.ValidBefore.CompareTo(time) < 0:
                    return None.Value;
                case BankCard card when card.ValidBefore.CompareTo(time) < 0:
                    return None.Value;
                default: return money;
            }
        }

        public static IEnumerable<Money> At(
            this IEnumerable<Money> moneys, Timestamp time) =>
            moneys.Flatten(money => money.At(time));

        public static Option<Money> Of(this Money money, Currency currency)
        {
            switch (money)
            {
                case SpecificMoney specific when specific.Currency == currency:
                    return specific;
                case BankCard _: return money;
                default: return None.Value;
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
    }
}