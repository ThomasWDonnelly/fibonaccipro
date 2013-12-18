using System;
using System.Numerics;

namespace FibonacciPro.ConsoleApplication
{
    public class FibonacciCalculator
    {
        /// <summary>
        /// Computes the first n digits of the fibonacci sequence
        /// </summary>
        /// <param name="n">number of digits of the fibonacci sequence to compute</param>
        /// <returns>an array containing the first n numbers in the fibonacci sequence</returns>
        public BigInteger[] Calculate(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n must be greater than 0", "n");

            //By definition
            if (n == 1)
            {
                return new BigInteger[] { 0 };
            }

            //By definition
            if (n == 2)
            {
                return new BigInteger[] { 0, 1 };
            }

            var result = new BigInteger[n];

            result[0] = 0;
            result[1] = 1;

            for (var i = 0; i < n - 2; i++)
            {
                result[i + 2] = result[i] + result[i + 1];
            }

            return result;
        }
    }
}
