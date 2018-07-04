using System;

namespace Demo
{
    public class InvoiceLine
    {
        private Amount BasePrice { get; }
        private ITax Tax { get; }

        public InvoiceLine(Amount basePrice, ITax tax)
        {
            BasePrice = 
                basePrice ?? throw new ArgumentNullException(nameof(basePrice));
            Tax = tax ?? throw new ArgumentNullException(nameof(tax));
        }

        public Amount Price => 
            this.Tax.ApplyTo(this.BasePrice);
    }
}