using Demo.Common;
using Demo.Functional;

namespace Demo.Finance
{
    static class MoneyPaymentExtensions
    {
        public static (Amount paid, Option<Money> remaining) Withdraw(
            this Option<Money> money, Amount toPay) =>
            money is Some<Money> some
                ? ((Money) some).Withdraw(toPay)
                    .Map(tuple => (tuple.paid, (Option<Money>)tuple.remaining))
                : (Amount.Zero(toPay.Currency), None.Value);

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

        public static Money Subtract(this Money from, Amount amount) =>
            amount.Value > 0 && from is Amount amt ? amt.Subtract(amount) : from;
    }
}
