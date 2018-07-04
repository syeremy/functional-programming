using System;
using Demo.Finance;

namespace Demo
{
    public static class MoneyPaymentExtensions
    {
        public static (Amount paid, Money remaining) Pay(this Money money, Amount expense)
        {
            switch (money)
            {
                case CashProxy proxy:
                    (Amount partPaid, Money partRemaining) =
                        proxy.Implementation.Pay(expense.Scale(1 + proxy.PercentageFee));
                    return (partPaid.Scale(1 - proxy.PercentageFee), partRemaining);
                default:
                    return Finance.MoneyPaymentExtensions.Pay(money, expense);
            }
        }
    }
}
