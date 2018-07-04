using System;
using Demo;
using DemoMoneyTests.AbstractTests;

namespace DemoMoneyTests.ConcreteTests
{
    public class GiftCardValidTests : FixedAmountValidTests
    {
        protected override Timestamp TimeWithinValidity => 
            new Timestamp(new DateTime(2017, 1, 2, 3, 4, 5, DateTimeKind.Utc));

        protected override Money CreateMoney(Currency currency, decimal amount) =>
            new GiftCard(currency, amount, new Date(2017, 6, 7));
    }
}
