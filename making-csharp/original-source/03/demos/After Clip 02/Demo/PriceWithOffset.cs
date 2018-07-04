using System;

namespace Demo
{
    public class PriceWithOffset : IPriceCurve
    {
        private Amount BasePrice { get; }
        private Amount PricePerUnit { get; }

        public PriceWithOffset(Amount basePrice, Amount pricePerUnit)
        {
            if (basePrice != null && pricePerUnit != null && basePrice.Currency != pricePerUnit.Currency)
                throw new ArgumentException("Currencies do not match.");

            BasePrice = basePrice ?? throw new ArgumentNullException(nameof(basePrice));
            PricePerUnit = pricePerUnit ?? throw new ArgumentNullException(nameof(pricePerUnit));
        }

        public Amount GetPrice(decimal atPoint) =>
            this.BasePrice.Add(this.PricePerUnit.Scale(atPoint));
    }
}
