using System;

namespace Demo
{
    public class InvoiceLine
    {
        private Amount BasePrice { get; }
        private Func<Amount, Amount> PriceCalculator { get; }

        public InvoiceLine(Amount basePrice, Func<Amount, Amount> priceCalculator)
        {
            BasePrice = basePrice ?? 
                throw new ArgumentNullException(nameof(basePrice));
            PriceCalculator = priceCalculator ??
                throw new ArgumentNullException(nameof(priceCalculator));
        }

        public Amount Price => 
            this.PriceCalculator(this.BasePrice);
    }
}