using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.Calculators
{
    public class GeneratorCalculator : IFibonacciCalculator
    {

        public IEnumerable<BigInteger> Calculate(int n)
        {
            return Calculate().Take(n);
        }

        /// <summary>
        /// Computes the fibonacci sequence as an enumeration of BigInteger
        /// </summary>
        /// <returns>the numerbs of the fibonacci sequence</returns>
        public IEnumerable<BigInteger> Calculate()
        {
            BigInteger penultimate;
            BigInteger previous;

            yield return (previous = BigInteger.Zero);

            yield return (penultimate = BigInteger.One);

            while (true)
            {
                var current = previous + penultimate;

                yield return current;

                previous = penultimate;
                penultimate = current;
            }
        }
    }
}
