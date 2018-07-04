using System;
using Demo.Finance;

namespace Demo
{
    class Program
    {
        static bool CanPay(Money money, Amount expense)
        {
            Timestamp now = Timestamp.Now;
            switch (money)
            {
                case Amount amount 
                    when amount.Currency == expense.Currency:
                    return amount.Currency == expense.Currency && amount.Value >= expense.Value;
                case GiftCard gift 
                    when gift.ValidBefore.CompareTo(now) >= 0 && gift.Currency == expense.Currency:
                    return gift.Value >= expense.Value;
                case BankCard card
                    when card.ValidBefore.CompareTo(now) >= 0:
                    return true;
                default:
                    return false;
            }
        }

        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }
}
