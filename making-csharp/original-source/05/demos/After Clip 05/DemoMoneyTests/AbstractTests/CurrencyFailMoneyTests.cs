using Demo;
using Xunit;

namespace DemoMoneyTests.AbstractTests
{
    public abstract class CurrencyFailMoneyTests : MoneyTests
    {
        [Fact]
        public void Of_MismatchedCurrencyWithSufficientAmount_TakesZeroAmount()
        {
            decimal amount = 100;
            Money sut = this.CreateMoney(base.TestCurrency, amount);

            decimal take = 1;
            decimal taken = sut.On(this.TimeWithinValidity).Of(base.DifferentTestCurrency).Take(take).Item1.Value;

            Assert.Equal(0, taken);
        }
    }
}
