using System;

namespace Demo
{
    class Program
    {
        static void PrintPriceTable(Product prod)
        {
            for (int quantity = 1; quantity <= 10; quantity++)
            {
                Console.WriteLine($"{quantity}\t{prod.Buy(quantity).Price}");
            }
            Console.WriteLine();
        }

        static void PrintPriceTable(Func<decimal, Amount> priceCalculator)
        {
            for (int quantity = 1; quantity <= 10; quantity++)
            {
                Console.WriteLine($"{quantity}\t{priceCalculator(quantity)}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Product prod = new Product(
                new PriceWithOffset(
                    new Amount(Currency.USD, 3), 
                    new Amount(Currency.USD, 2)), 
                new PercentageTax(.2M),
                new PercentageDeduction(.2M));

            PrintPriceTable(prod);
            Console.ReadLine();

            PrintPriceTable(prod.PriceCalculator);
            Console.ReadLine();
        }
    }
}
