namespace Demo
{
    public class Empty : Amount
    {
        public Empty(Currency currency) : base(currency, 0)
        {
        }

        public override string ToString() => "0";
    }
}