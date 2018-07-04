using System;

namespace HelloWorldFunctional
{
    public abstract class Money
    {
        public abstract SpecificMoney Of(Currency currency);
        public abstract Money On(Timestamp time);
    }
}