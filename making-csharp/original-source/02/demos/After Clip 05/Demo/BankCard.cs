﻿using System;

namespace Demo
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            if (validBefore == null)
                throw new ArgumentNullException(nameof(validBefore));

            this.ValidBefore = validBefore;
        }

        public override decimal Withdraw(Currency currency, decimal amount)
        {
            if (this.ValidBefore.CompareTo(DateTime.Now) <= 0)
                return 0;
            return amount;
        }
    }
}
