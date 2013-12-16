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
                var inputHandler = GetInputHandler();
                var result = FibonacciCalculator.Calculate(inputHandler.GetNumber());

                var outputHandler = GetOutputHandler();
                outputHandler.Write(result);
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

        private static IInputHandler GetInputHandler()
        {
            IInputHandler result = null;

            if (_options.UseInteractiveMode())
            {
                result = new ConsoleIOHandler();
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
                        result = new XmlIOHandler(_options.InputFile);
                        break;
                    
                }
            }

            return result;
        }

        private static IOutputHandler GetOutputHandler()
        {
            IOutputHandler result = new ConsoleIOHandler();

            if (!string.IsNullOrWhiteSpace(_options.OutputFile))
            {
                result = new TextFileIOHandler(_options.OutputFile);
            }

            return result;
        }
    }
}
