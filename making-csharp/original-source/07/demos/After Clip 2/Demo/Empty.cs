using System;

namespace Demo
{
    public class Empty : SpecificMoney
    {
        public Empty(Currency currency) : base(currency)
        {
        }

        public override string ToString() => "0";
    }
}