using System;

namespace Demo.Finance
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
