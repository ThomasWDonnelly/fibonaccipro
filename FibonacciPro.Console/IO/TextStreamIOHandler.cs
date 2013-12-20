using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class TextStreamIOHandler : IInputHandler, IOutputHandler
    {
        protected TextReader _inputStream;
        protected TextWriter _outputStream;

        public TextStreamIOHandler(TextReader inputStream, TextWriter outputStream)
        {
            _inputStream = inputStream;
            _outputStream = outputStream;
        }
    
        public void Write(IEnumerable<System.Numerics.BigInteger> results)
        {
            _outputStream.Write((string.Join(" ", results.Select(r => r.ToString("R0")))));
        }

        public int GetNumber()
        {
            var result = 0;

            do
            {
                _outputStream.Write("Please enter the number of sequences to calculate: ");
                var input = _inputStream.ReadLine();
                int.TryParse(input, out result);

            } while (result == 0);

            return result;
        }
    }
}
