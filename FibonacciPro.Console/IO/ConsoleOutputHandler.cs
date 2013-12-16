using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void Write(double[] results)
        {
            foreach (var number in results)
            {
                Console.Write(number + " ");
            }
        }
    }
}
