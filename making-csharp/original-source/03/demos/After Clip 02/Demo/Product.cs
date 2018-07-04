using System;

namespace Demo
{
    public class Product
    {
        private IPriceCurve Curve { get; }
        private ITax Tax { get; }

        public Product(IPriceCurve curve, ITax tax)
        {
            Curve = curve;
            Tax = tax;
        }

        private Amount GetPrice(decimal quantity) =>
            this.Curve.GetPrice(quantity);

        public InvoiceLine Buy(decimal quantity) =>
            new InvoiceLine(this.GetPrice(quantity), this.Tax);

        public Func<decimal, Amount> PriceCalculator =>
            quantity => this.Buy(quantity).Price;
    }
}
