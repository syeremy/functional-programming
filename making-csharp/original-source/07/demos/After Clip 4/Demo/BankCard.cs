using System;

namespace Demo
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            this.ValidBefore = validBefore ?? throw new ArgumentNullException(nameof(validBefore));
        }
    }
}
