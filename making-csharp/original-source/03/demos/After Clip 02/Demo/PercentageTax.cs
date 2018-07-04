using System;

namespace Demo
{
    public class PercentageTax : ITax
    {
        public decimal Relative { get; }

        public PercentageTax(decimal relative)
        {
            if (relative < 0 || relative > 1)
                throw new ArgumentException("Relative tax must be within range 0-1 inclusive.");
            Relative = relative;
        }

        public Amount ApplyTo(Amount price) =>
            price.Scale(1 + this.Relative);
    }
}
