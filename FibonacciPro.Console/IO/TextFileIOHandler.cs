using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class TextFileIOHandler : IInputHandler, IOutputHandler
    {
        private string _path;
        private int _number;

        public TextFileIOHandler(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path must not be an empty string", "path");

            _path = path;
        }

        private void ReadFile()
        {
            if (!File.Exists(_path))
                throw new ArgumentException("path for input files must be to an actual path to a file", "path");

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

        public void Write(double[] results)
        {
            try
            {

                using (var writer = new StreamWriter(_path, append: false))
                {
                    foreach (var result in results)
                    {
                        writer.WriteLine(result);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new ApplicationException("There was an error writing to the output file.", ex);
            }
        }
    }
}
