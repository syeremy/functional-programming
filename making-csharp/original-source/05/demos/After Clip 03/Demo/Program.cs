using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Amount amt = new Amount(Currency.USD, 100);

            Console.Write($"Have {amt}: ");
            Amount taken = amt.Of(Currency.USD).Take(50).Item1;
            Console.WriteLine($"can take {taken}");

            Console.Write($"Have {amt}: ");
            taken = amt.Of(Currency.USD).Take(50).Item1;
            Console.WriteLine($"can take {taken}");

            Console.ReadLine();
        }
    }
}
