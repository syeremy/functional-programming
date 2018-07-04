using System;

namespace Demo.Functional
{
    public static class EitherAdapters
    {
        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either, Func<TRight, TNewRight> map) =>
            either is Right<TLeft, TRight> right
                ? (Either<TLeft, TNewRight>)map(right)
                : (TLeft)(Left<TLeft, TRight>)either;

        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either,
            Func<TRight, Either<TLeft, TNewRight>> map) =>
            either is Right<TLeft, TRight> right
                ? map(right)
                : (TLeft)(Left<TLeft, TRight>)either;

        public static TRight Reduce<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TLeft, TRight> map) =>
            either is Left<TLeft, TRight> left
                ? map(left)
                : (Right<TLeft, TRight>)either;
    }
}
