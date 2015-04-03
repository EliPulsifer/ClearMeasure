using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullSequence()
        {
            var result = FizzBuzz.Run(null, new Rule<int>[] { });
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNullRules()
        {
            var result = FizzBuzz.Run(Enumerable.Range(1, 10), null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestEmptyRules()
        {
            var result = Enumerable.Range(1, 10).FizzBuzz(new Rule<int>[] { });
        }

        [TestMethod]
        public void TestSingleRuleMatchAll()
        {
            var result = Enumerable.Range(1, 10)
                .Select(n => n * 10)
                .FizzBuzz(new Rule<int>(n => true, "true"));
            Assert.IsTrue(result.All(v => v == "true"));
        }

        [TestMethod]
        public void TestSingleRuleMatchNone()
        {
            var result = Enumerable.Range(1, 10)
                .Select(n => n * 10)
                .FizzBuzz(new Rule<int>(n => false, "false"));
            Assert.IsFalse(result.Any(v => v == "false"));
        }

        [TestMethod]
        public void TestSingleRuleMatchSome()
        {
            var result = Enumerable.Range(1, 10)
                .Select(n => n * 5)
                .FizzBuzz(new Rule<int>(n => 0 == n % 10, "mod"));
            var expected = new string[] { "5", "mod", "15", "mod", "25", "mod", "35", "mod", "45", "mod" };
            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestMultiRuleOrder()
        {
            var result = Enumerable.Range(1, 10)
                .Select(n => n * 5)
                .FizzBuzz(
                    new Rule<int>(n => 0 == n % 10, "10"),
                    new Rule<int>(n => 0 == n % 5, "5"));

            var expected = new string[] { "5", "10", "5", "10", "5", "10", "5", "10", "5", "10" };
            Assert.IsTrue(result.SequenceEqual(expected));

            result = Enumerable.Range(1, 10)
                .Select(n => n * 5)
                .FizzBuzz(
                    new Rule<int>(n => 0 == n % 5, "5"),
                    new Rule<int>(n => 0 == n % 10, "10"));

            Assert.IsTrue(result.All(v => v == "5"));
        }
    }
}
