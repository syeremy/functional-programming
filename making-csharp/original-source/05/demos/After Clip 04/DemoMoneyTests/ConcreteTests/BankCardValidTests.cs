using System;
using Demo;
using DemoMoneyTests.AbstractTests;

namespace DemoMoneyTests.ConcreteTests
{
    public class BankCardValidTests : ValidMoneyTests
    {
        protected override Timestamp TimeWithinValidity =>
            new Timestamp(new DateTime(2017, 1, 2, 3, 4, 5, DateTimeKind.Utc));

        protected override Money CreateMoney(Currency currency, decimal amount) =>
            new BankCard(new Month(2017, 6));
    }
}
