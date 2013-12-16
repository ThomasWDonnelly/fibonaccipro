using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication
{
    public class FibonacciCalculator
    {
        /// <summary>
        /// Computes the first n digits of the fibonacci sequence
        /// </summary>
        /// <param name="n">number of digits of the fibonacci sequence to compute</param>
        /// <returns>an array containing the first n numbers in the fibonacci sequence</returns>
        public static BigInteger[] Calculate(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n must be greater than 0", "n");

            //By definition
            if (n == 1)
            {
                return new BigInteger[1] { 0 };
            }

            //By definition
            if (n == 2)
            {
                return new BigInteger[2] { 0, 1 };
            }

            var result = new BigInteger[n];

            var a = result[0] = 0;
            var b = result[1] = 1;


            for (var i = 0; i < n-2; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
                result[i + 2] = b;
            }

            return result;
        }
    }
}
