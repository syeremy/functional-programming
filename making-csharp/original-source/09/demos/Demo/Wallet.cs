using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;
using Demo.Finance;

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

        private (Amount paid, Amount expense, List<Money> moneys)
            InitializePaymentResult(Amount expense) =>
            (Amount.Zero(expense.Currency), expense, new List<Money>());

        private static (Amount paid, Amount remaining, List<Money> moneys) Withdraw(
            (Amount paid, Amount remaining, List<Money> moneys) state, Money money) =>
            money.Of(state.remaining.Currency)
                .Withdraw(state.remaining)
                .paid
                .Map(paid => (
                    state.paid.Add(paid),
                    state.remaining.Subtract(paid),
                    new List<Money>(state.moneys)
                        {paid.Value > 0 && money is Amount amt ? amt.Subtract(paid) : money}));
    }
}
