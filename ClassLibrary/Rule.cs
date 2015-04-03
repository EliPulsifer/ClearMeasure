using System;

namespace ClassLibrary
{
    public static class Rule
    {
        public static Rule<T> Create<T>(Predicate<T> predicate, string value)
        {
            return new Rule<T>(predicate, value);
        }
    }

    public struct Rule<T>
    {
        public Predicate<T> Predicate;
        public string Value;

        public Rule(Predicate<T> predicate, string value)
        {
            Predicate = predicate;
            Value = value;
        }
    }
}
