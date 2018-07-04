namespace Demo.Finance
{
    public class Empty : Amount
    {
        public Empty(Currency currency) : base(currency, 0)
        {
        }

        public override Amount Scale(decimal factor) => this;

        public override string ToString() => "0";
    }
}