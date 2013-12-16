using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication.IO
{
    public class TextFileOutputHandler : IOutputHandler
    {

        private string _path;

        public TextFileOutputHandler(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path must not be an empty string", "path");

            if (File.Exists(path))
                throw new ArgumentException("file already exists", "path");

            _path = path;
        }

        public void Write(double[] results)
        {
            try {
                using(var writer = new StreamWriter(_path)) {
                    foreach(var result in results) {
                        writer.WriteLine(result);
                    }
                }
            } catch (IOException ex) {
                throw new ApplicationException("There was an error writing to the output file.", ex);
            }
        }
    }
}
