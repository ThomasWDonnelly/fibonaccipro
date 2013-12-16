using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class TextFileInputHandler : IInputHandler
    {
        private string _path;
        private int _number;

        public TextFileInputHandler(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path must not be an empty string", "path");

            if (!File.Exists(path))
                throw new ArgumentException("path must be to an actual path to a file", "path");

            _path = path;
        }

        private void ReadFile()
        {
            try
            {
                using (var fileReader = new StreamReader(_path))
                {
                    if (!int.TryParse(fileReader.ReadLine(), out _number))
                    {
                        throw new ApplicationException("Input file did not contain a valid number on the first line.");
                    }
                }
            }
            catch (IOException ex)
            {
                throw new ApplicationException("There was a problem reading the file", ex);
            }
        }

        public int GetNumber()
        {
            ReadFile();
            return _number;
        }
    }
}
