using System.Collections.Generic;

namespace ClassLibrary
{
    public static class FizzBuzzExtensions
    {
        public static IEnumerable<string> FizzBuzz<T>(this IEnumerable<T> values, params Rule<T>[] rules)
        {
            return ClassLibrary.FizzBuzz.Run<T>(values, rules as IEnumerable<Rule<T>>);
        }

        public static IEnumerable<string> FizzBuzz<T>(this IEnumerable<T> values, IEnumerable<Rule<T>> rules)
        {
            return ClassLibrary.FizzBuzz.Run<T>(values, rules as IEnumerable<Rule<T>>);
        }
    }
}
