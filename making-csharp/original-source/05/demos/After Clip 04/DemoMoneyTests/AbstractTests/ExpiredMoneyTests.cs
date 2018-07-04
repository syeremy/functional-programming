using Demo;
using Xunit;

namespace DemoMoneyTests.AbstractTests
{
    public abstract class ExpiredMoneyTests : MoneyTests
    {
        [Fact]
        public void On_ExpiredMoneyWithSufficientAmount_ReturnsZero()
        {
            Money sut = this.CreateMoney(base.TestCurrency, 100);
            decimal taken = sut.On(this.TimeOutsideValidity).Of(base.TestCurrency).Take(1).Item1.Value;

            Assert.Equal(0, taken);
        }

        protected abstract Timestamp TimeOutsideValidity { get; }
    }
}
