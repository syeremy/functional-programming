using System.Collections.Generic;
using System.Linq;
using Demo.Common;
using Demo.Finance;
using Demo.Functional;

namespace Demo
{
    public class Wallet
    {
        private IEnumerable<Money> Moneys { get; }

        public Wallet(IEnumerable<Money> moneys)
        {
            this.Moneys = moneys.ToList();
        }

        public (Amount paid, Wallet remaining) Pay(Amount expense, Timestamp time) =>
            this.Moneys
                .At(time)
                .Aggregate(InitializePaymentResult(expense), Withdraw)
                .Map(tuple => (tuple.paid, new Wallet(tuple.moneys.Payable())));

        private static (Amount paid, Amount remaining, List<Money> moneys) InitializePaymentResult(Amount expense) =>
            (Amount.Zero(expense.Currency), expense, new List<Money>());

        private static (Amount paid, Amount remainToPay, List<Money> remainingMoneys)
            Withdraw(
                (Amount paid, Amount remainToPay, List<Money> remainingMoneys) state,
                Money money) =>
            money.Of(state.remainToPay.Currency)
                .Withdraw(state.remainToPay)
                .paid
                .Map(paid => (
                    state.paid.Add(paid),
                    state.remainToPay.Subtract(paid),
                    new List<Money>(state.remainingMoneys) {money.Subtract(paid)}));
    }
}
