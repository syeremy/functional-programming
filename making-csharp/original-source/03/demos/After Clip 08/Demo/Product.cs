using System;

namespace Demo
{
    public class Product
    {
        private IPriceCurve Curve { get; }
        private ITax Tax { get; }
        private IPriceDeduction Deduction { get; }

        public Product(IPriceCurve curve, ITax tax, IPriceDeduction deduction)
        {
            Curve = curve;
            Tax = tax;
            Deduction = deduction;
        }

        private Amount GetPrice(decimal quantity) =>
            this.Curve.GetPrice(quantity);

        private Amount PartialPriceCalculator(Amount basePrice) =>
            this.Tax.ApplyTo(this.Deduction.ApplyTo(basePrice));

        public InvoiceLine Buy(decimal quantity) =>
            new InvoiceLine(this.GetPrice(quantity), this.PartialPriceCalculator);

        public Func<decimal, Amount> PriceCalculator =>
            quantity => this.Buy(quantity).Price;
    }
}
