using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication
{
    class Program
    {
        private static Options _options;

        static void Main(string[] args)
        {
            _options = ParseOptions(args);

            if (_options.InteractiveMode)
            {
                Interact();
            }
        }

        private static void Interact()
        {
            var result = 0;

            do
            {
                Console.Write("Please enter the number of sequences to calculate: ");
                var input = Console.ReadLine();
                int.TryParse(input, out result);

            } while (result == 0);

            _options.InputNumber = result;
        }

        private static Options ParseOptions(string[] args) {
            var options = new Options();
            CommandLine.Parser.Default.ParseArguments(args, options);

            return options;
        }
    }
}
