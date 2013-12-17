using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class ConsoleIOHandler : IInputHandler, IOutputHandler
    {
        public int GetNumber()
        {
            var result = 0;

            do
            {
                Console.Write("Please enter the number of sequences to calculate: ");
                var input = Console.ReadLine();
                int.TryParse(input, out result);

            } while (result == 0);

            return result;
        }

        public void Write(BigInteger[] results)
        {
            for (var i=0; i< results.Length; i++)
            {
                Console.Write(
                    string.Format("{0}{1}", results[i].ToString("R0"), i < results.Length - 1 ? " " : string.Empty)
                    );
                
            }
        }
    }
}
