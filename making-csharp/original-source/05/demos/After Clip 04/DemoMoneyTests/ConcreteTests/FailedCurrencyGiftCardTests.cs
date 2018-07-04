using System;
using Demo;
using DemoMoneyTests.AbstractTests;

namespace DemoMoneyTests.ConcreteTests
{
    public class FailedCurrencyGiftCardTests : CurrencyFailMoneyTests
    {
        protected override Timestamp TimeWithinValidity =>
            new Timestamp(new DateTime(2017, 1, 2, 3, 4, 5, DateTimeKind.Utc));

        protected override Money CreateMoney(Currency currency, decimal amount) =>
            new GiftCard(base.TestCurrency, amount, new Date(2017, 3, 4));
    }
}
