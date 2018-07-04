using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Caching;

namespace Demo
{
    class Program
    {
        static long NaiveFibonacci(int n) =>
            n < 2
                ? n
                : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);

        static IDictionary<int, long> dynamicCache = new Dictionary<int, long>();

        static long DynamicFibonacci(int n)
        {
            long value;
            if (!dynamicCache.TryGetValue(n, out value))
            {
                value = n < 2
                    ? n
                    : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);
                dynamicCache[n] = value;
            }

            return value;
        }

        static IList<long> forwardCache = new List<long>() {0, 1};

        static long ForwardFibonacci(int n)
        {
            while (forwardCache.Count <= n)
            {
                forwardCache.Add(
                    forwardCache[forwardCache.Count - 1] +
                    forwardCache[forwardCache.Count - 2]);
            }
            return forwardCache[n];
        }

        static long QuickFibonacci(int n)
        {
            if (n < 2) return n;

            long a = 0;
            long b = 1;

            for (int k = 2; k <= n; k++)
            {
                long c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        [Cache]
        static long MemoizedFibonacci(int n) =>
            n < 2
                ? n
                : MemoizedFibonacci(n - 1) + MemoizedFibonacci(n - 2);

        static void Demonstrate(Func<int, long> fibonacci)
        {
            int offset = 38;
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{offset + i}\t{fibonacci(offset + i)}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            CachingServices.DefaultBackend =
                new PostSharp.Patterns.Caching.Backends.MemoryCachingBackend();

            Demonstrate(NaiveFibonacci);
            Demonstrate(DynamicFibonacci);
            Demonstrate(ForwardFibonacci);
            Demonstrate(QuickFibonacci);
            Demonstrate(MemoizedFibonacci);

            Console.ReadLine();
        }
    }
}
