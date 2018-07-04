using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Currency usd = Currency.USD;

            Amount amt = new Amount(usd, 100);

            Console.Write($"Have {amt}: ");
            Amount taken = amt.Of(usd).Take(50).Item1;
            Console.WriteLine($"can take {taken}");

            Console.Write($"Have {amt}: ");
            taken = amt.Of(usd).Take(50).Item1;
            Console.WriteLine($"can take {taken}");

            Console.ReadLine();
        }
    }
}
