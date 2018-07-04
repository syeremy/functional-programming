using System;
using System.Threading;

namespace Demo
{
    class BankCard
    {
        public DateTime ValidBefore { get; }
        public decimal Balance { get; }

        public BankCard(DateTime validBefore, decimal balance)
        {
            this.ValidBefore = validBefore;
            this.Balance = balance;
        }

        public decimal GetAvailableAmount(decimal desired, DateTime at)
        {
            if (at.CompareTo(this.ValidBefore) >= 0)
                return 0;
            return Math.Min(this.Balance, desired);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankCard card = new BankCard(DateTime.Now.AddSeconds(2), 100);

            DateTime queryTime = DateTime.Now;
            decimal available1 = 
                card.GetAvailableAmount(20, queryTime); // returns 20

            decimal available2 = 
                card.GetAvailableAmount(20, queryTime.AddSeconds(3)); // returns 0

            decimal available3 =
                card.GetAvailableAmount(20, queryTime); // returns 20

            // Previous implementation - does not compile
            //BankCard card = new BankCard()
            //{
            //    ValidBefore = DateTime.Now.AddSeconds(2),
            //    Balance = 100
            //};

            //decimal available1 = card.GetAvailableAmount(20); // returns 20

            //card.Balance = 15;
            //decimal available2 = card.GetAvailableAmount(20); // returns 15

            //Thread.Sleep(3000); // three seconds later...
            //decimal available3 = card.GetAvailableAmount(20); // returns 0
        }
    }
}
