using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public static class FizzBuzz
    {
        public static IEnumerable<string> Run<T>(IEnumerable<T> values, params Rule<T>[] rules)
        {
            return Run(values, rules as IEnumerable<Rule<T>>);
        }

        public static IEnumerable<string> Run<T>(IEnumerable<T> values, IEnumerable<Rule<T>> rules)
        {
            if (null == values)
                throw new ArgumentNullException("values");
            if (null == rules)
                throw new ArgumentNullException("rules");
            if (rules.Any() == false)
                throw new ArgumentException("Empty rules sequence not allowed", "rules");

            return values.Select(n => rules.FirstOrDefault(rule => rule.Predicate(n)).Value ?? n.ToString());
        }
    }
}
