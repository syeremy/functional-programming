namespace Demo
{
    public class PercentageDeduction : IPriceDeduction
    {
        private decimal Relative { get; }

        public PercentageDeduction(decimal relative)
        {
            this.Relative = relative;
        }

        public Amount ApplyTo(Amount price) =>
            price.Scale(1 - this.Relative);
    }
}
