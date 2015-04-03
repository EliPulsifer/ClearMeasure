using ClassLibrary;
using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = Enumerable.Range(1, 100).FizzBuzz(
                new Rule<int>(n => 0 == n % 15, "FizzBuzz"),
                new Rule<int>(n => 0 == n % 3, "Fizz"),
                new Rule<int>(n => 0 == n % 5, "Buzz"));

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
