using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public static class MoneyEnumerableExtensions
    {
        public static IEnumerable<Money> On(this IEnumerable<Money> moneys, 
                                            Timestamp time) =>
            moneys.Select(money => money.On(time));

        public static IEnumerable<SpecificMoney> Of(this IEnumerable<Money> moneys,
                                                    Currency currency) =>
            moneys.Select(money => money.Of(currency));

        public static IEnumerable<(Amount taken, Money remaining)> Take(
            this IEnumerable<SpecificMoney> moneys, decimal amount)
        {
            decimal rest = amount;
            foreach (SpecificMoney money in moneys)
            {
                (Amount taken, Money remaining) current = money.Take(rest);
                yield return current;
                rest -= current.taken.Value;
            }
        }
    }
}
