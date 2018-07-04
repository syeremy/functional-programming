using System;

namespace Demo.Common
{
    public static class CompositionExtensions
    {
        public static TResult Map<T, TResult>(this T input, Func<T, TResult> map) =>
            map(input);
    }
}
