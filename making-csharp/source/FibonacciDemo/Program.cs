using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FibonacciDemo
{
    class Program
    {
        static long NaiveFibonacci(int n) => n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);
        private static IDictionary<int, long> dynamicCache = new Dictionary<int, long>();
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Demostarte(NaiveFibonacci);
            Demostarte(DynamicFibonacci);

            Console.ReadLine();
        }

        static void Demostarte(Func<int, long> fibonacci)
        {
            var offset = 30;
            for (var i = 0; i < 12; i++)
            {
                Console.WriteLine($"{offset + i}\t{fibonacci(offset + i)}");
            }
            Console.WriteLine("");
        }

        static long DynamicFibonacci(int n)
        {
            if (dynamicCache.TryGetValue(n, out var value)) return value;
            
            value = n < 2 ? n : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);
            dynamicCache[n] = value;

            return value;
        }
    }
}
