using System;
using System.Collections.Generic;

namespace HelloWorldFunctional
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<Currency, Money> moneys = new Dictionary<Currency, Money>();

            Money money = new Amount(Currency.USD, 100);
            moneys.Add(Currency.USD, money);
            Console.WriteLine($"Added {money}.");

            if (moneys.ContainsKey(Currency.USD))
            {
                Console.WriteLine($"Found {moneys[Currency.USD]}");
            }
            else
            {
                Console.WriteLine($"{Currency.USD} not found.");
            }

            Console.ReadLine();
        }
    }
}
