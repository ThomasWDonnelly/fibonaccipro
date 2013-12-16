using FibonacciPro.ConsoleApplication.IO;
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

            try
            {
                var ioHandler = GetInputHandler();
                var result = FibonacciCalculator.Calculate(ioHandler.GetNumber());
                foreach (var number in result)
                {
                    Console.Write(number + " ");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static Options ParseOptions(string[] args) {
            var options = new Options();
            
            if (!CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
                return options;

            return options;
        }

        private static IIOHandler GetInputHandler()
        {
            IIOHandler result = null;

            if (_options.UseInteractiveMode())
            {
                result = new InteractiveIOHandler();
            }
            else
            {
                switch (_options.InputFileType)
                {
                    default:
                    case Options.FileType.Undefined:
                    case Options.FileType.PlainText:
                        result = new TextFileIOHandler(_options.InputFile);
                        break;
                    case Options.FileType.Xml:
                        throw new NotImplementedException();
                        break;
                    
                }
            }

            return result;
        }
    }
}
